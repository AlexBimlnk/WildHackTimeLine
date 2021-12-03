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
            {SiteName.SiteName1, new string[] {"url", "articlesPath", "titlePath", "datePath"} },
            {SiteName.SiteName2, new string[] {"url", "articlesPath", "titlePath", "datePath"} }
        };

        /// <summary>
        /// Возвращает список новых экологических событий.
        /// </summary>
        /// <returns>Список <see cref="EcologyEvent"/>.</returns>
        public static async List<EcologyEvent> GetLastUpdates()
        {
            List<EcologyEvent> resultList = new List<EcologyEvent>();
            HttpClient client = new HttpClient();
            foreach(var site in siteDict)
            {
                resultList.Add(await ParseSite(site, client));
            }
            
            return resultList;
        }

        private static async List<EcologyEvent> ParseSite(SiteName site, HttpClient client)
        {
            string rawPage = await client.GetStringAsync(siteDict[site][0]);
            string articlesPath = siteDict[site][1];
            string titlePath = siteDict[site][2];
            string timePath = siteDict[site][3];

            HtmlDocument parsedPage = new HtmlDocument();
            parsedPage.LoadHtml(rawPage);

            var articles = parsedPage.DocumentNode.SelectNodes(articlesPath);

            List<EcologyEvent> resultList = new List<EcologyEvent>();
            foreach (var article in articles)
            {
                EcologyEvent ecoEvent = new EcologyEvent();
                ecoEvent.Title = article.SelectSingleNode(titlePath).InnerText;
                ecoEvent.Date = DateParser(article.SelectSingleNode(timePath).InnerText);
            }

            return resultList;
        }

        //Парсит строку для даты
        private static DateTime DateParser(string time)
        {
            return null;
        }
    }
}
