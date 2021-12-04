using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using WildHackWebApp.Models;

namespace WildHackWebApp.BL
{
    public class ParseTool
    {
        private static Dictionary<SiteName, PageElement> siteDict = new Dictionary<SiteName, PageElement>
        {
            {SiteName.PoluostrovKamchatka, new PageElement() {
                                          SiteURL = "https://poluostrov-kamchatka.ru",
                                          RequestURL = "https://poluostrov-kamchatka.ru/pknews/english/",
                                          ArticlesPath = "//div[@class='article-info']",
                                          TitlePath = ".//h3",
                                          TimePath = ".//p[1]",
                                          LinkPath = ".//h3/a[@href]/@href"  } },
            {SiteName.Ria, new PageElement() {
                                         SiteURL = "https://ria.ru/",
                                         RequestURL = "https://ria.ru/organization_Kronockijj_zapovednik/",
                                         ArticlesPath = ".//div[@class='list-item']",
                                         TitlePath = ".//div[@class='list-item__content']",
                                         TimePath = ".//div[@class='list-item__date']",
                                         LinkPath = ".//div[@class='list-item__content']//a[@href]/@href" } },
            {SiteName.GoogleNews, new PageElement() {
                                         SiteURL = "https://news.google.com",
                                         RequestURL = "https://news.google.com/search?q=%D0%BA%D0%B0%D0%BC%D1%87%D0%B0%D1%82%D0%BA%D0%B0%20%D0%B7%D0%B0%D0%BF%D0%BE%D0%B2%D0%B5%D0%B4%D0%BD%D0%B8%D0%BA%20when%3A7d&hl=ru&gl=RU&ceid=RU%3Aru",
                                         ArticlesPath = ".//div[@class='xrnccd']",
                                         TitlePath = ".//h3[@class='ipQwMb ekueJc RD0gLb']",
                                         TimePath = ".//time[@class='WW6dff uQIVzc Sksgp']/@datetime",
                                         LinkPath = ".//h3/a[@href]/@href" } },
        };

        /// <summary>
        /// Возвращает список новых экологических событий.
        /// </summary>
        /// <returns>Список <see cref="EcologyEvent"/>.</returns>
        public static async Task<List<EcologyEvent>> GetLastUpdatesAsync()
        {
            List<EcologyEvent> resultList = new List<EcologyEvent>();
            HtmlWeb client = new HtmlWeb();

            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.45 Safari/537.36";
            foreach(var site in siteDict.Keys)
            {
                resultList.AddRange(await ParseSiteAsync(site, client));
            }
            
            return resultList;
        }

        private static async Task<List<EcologyEvent>> ParseSiteAsync(SiteName site, HtmlWeb client)
        {
            PageElement pageElement = siteDict[site];
            HtmlDocument page = client.Load(pageElement.RequestURL);

            var articles = page.DocumentNode.SelectNodes(pageElement.ArticlesPath);

            List<EcologyEvent> resultList = new List<EcologyEvent>();
            foreach (var article in articles)
            {
                EcologyEvent ecoEvent = new EcologyEvent();
                var navigator = article.CreateNavigator();
                ecoEvent.Title = navigator.SelectSingleNode(pageElement.TitlePath).Value;
                ecoEvent.Date = new Date(navigator.SelectSingleNode(pageElement.TimePath).Value).FullDate;

                string link = navigator.SelectSingleNode(pageElement.LinkPath).Value;
                if (!link.Contains(pageElement.SiteUrl))
                    ecoEvent.Link = pageElement.SiteURL + link.TrimStart('.');
                else
                    ecoEvent.Link = link;

                resultList.Add(ecoEvent);
            }

            await Task.Run(() => { });
            return resultList;
        }
    }
}
