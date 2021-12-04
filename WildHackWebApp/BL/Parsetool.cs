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
            {SiteName.SiteName1, new string[] { "https://poluostrov-kamchatka.ru/pknews/english/", "//div[@class='article-info']", "./h3", "./p[1]" } },
            {SiteName.SiteName2, new string[] { "https://ria.ru/organization_Kronockijj_zapovednik/", "//div[@class='list-item']", ".//div[@class='list-item__content']", ".//div[@class='list-item__date']" } },
        };

        /// <summary>
        /// Возвращает список новых экологических событий.
        /// </summary>
        /// <returns>Список <see cref="EcologyEvent"/>.</returns>
        public static async Task<List<EcologyEvent>> GetLastUpdatesAsync()
        {
            List<EcologyEvent> resultList = new List<EcologyEvent>();
            HtmlWeb client = new HtmlWeb();
            client.UserAgent = " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.45 Safari/537.36";
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

            var articles = page.DocumentNode.SelectNodes(articlesPath);

            List<EcologyEvent> resultList = new List<EcologyEvent>();
            foreach (var article in articles)
            {
                EcologyEvent ecoEvent = new EcologyEvent();
                ecoEvent.Title = article.SelectSingleNode(titlePath).InnerText;
                ecoEvent.Date = DateParser(article.SelectSingleNode(timePath).InnerText);
                resultList.Add(ecoEvent);
            }

            await Task.Run(() => { });
            return resultList;
        }

        //Парсит строку для даты
        private static Date DateParser(string time)
        {
            try
            {
                string[] dateFromSiteArray = time.Trim().Split(' ').
                                            Where(s => s.Contains('.')).First().Split('.');
                
                return new Date() { Day = int.Parse(dateFromSiteArray[0]), 
                                    Month = int.Parse(dateFromSiteArray[1]), 
                                    Year = int.Parse(dateFromSiteArray[2]) };
            }
            catch
            {
                return new Date() { Day = -1, Month = -1, Year = -1 };
            }
        }
    }
}
