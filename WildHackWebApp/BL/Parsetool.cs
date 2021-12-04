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
        private static Dictionary<SiteName, string[]> siteDict = new Dictionary<SiteName, string[]>
        {
            //{SiteName.PoluostrovKamchatka, new string[] { "https://poluostrov-kamchatka.ru/pknews/english/",
                                                          //"//div[@class='article-info']",
                                                          //".//h3",
                                                          //".//p[1]",
                                                          //".//h3/a[@href]/@href" } },
            //{SiteName.Ria, new string[] { "https://ria.ru/organization_Kronockijj_zapovednik/",
                                          //".//div[@class='list-item']",
                                          //".//div[@class='list-item__content']",
                                          //".//div[@class='list-item__date']",
                                          //".//div[@class='list-item__content']//a[@href]/@href" } },
            {SiteName.GoogleNews, new string[] { "https://news.google.com/search?q=%D0%BA%D0%B0%D0%BC%D1%87%D0%B0%D1%82%D0%BA%D0%B0%20%D0%B7%D0%B0%D0%BF%D0%BE%D0%B2%D0%B5%D0%B4%D0%BD%D0%B8%D0%BA%20when%3A7d&hl=ru&gl=RU&ceid=RU%3Aru",
                                                 "//div[@class='xrnccd']",
                                                 "//h3[@class='ipQwMb ekueJc RD0gLb']",
                                                 "//time[@class='WW6dff uQIVzc Sksgp']",
                                                 "//h3/a[@href]/@href" } },
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
            HtmlDocument page = client.Load(siteDict[site][0]);
            string articlesPath = siteDict[site][1];
            string titlePath = siteDict[site][2];
            string timePath = siteDict[site][3];
            string linkPath = siteDict[site][4];

            var articles = page.DocumentNode.SelectNodes(articlesPath);

            List<EcologyEvent> resultList = new List<EcologyEvent>();
            foreach (var article in articles)
            {
                EcologyEvent ecoEvent = new EcologyEvent();
                var navigator = article.CreateNavigator();
                ecoEvent.Title = navigator.SelectSingleNode(titlePath).Value;
                try
                {
                    ecoEvent.Date = new Date(navigator.SelectSingleNode(timePath).Value);
                }
                catch { }
                ecoEvent.Link = navigator.SelectSingleNode(linkPath).Value;
                resultList.Add(ecoEvent);
            }

            await Task.Run(() => { });
            return resultList;
        }
    }
}
