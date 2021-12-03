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
        public static async Task<List<EcologyEvent>> GetLastUpdatesAsync()
        {
            List<EcologyEvent> resultList = new List<EcologyEvent>();
            HttpClient client = new HttpClient();
            foreach(var site in siteDict.Keys)
            {
                resultList.AddRange(await ParseSiteAsync(site, client));
            }
            
            return resultList;
        }

        private static async Task<List<EcologyEvent>> ParseSiteAsync(SiteName site, HttpClient client)
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
        private static Date DateParser(string time)
        {
            var ecologyEvents = ParseTool.GetLastUpdatesAsync().Result;
            string[] dateFromSiteArray = ecologyEvents[0].Title.Trim().Split(' ').
                                        Where(s => s.Contains('.')).First().Split('.');
            
            return new Date() { Day = int.Parse(dateFromSiteArray[0]), 
                                Month = int.Parse(dateFromSiteArray[1]), 
                                Year = int.Parse(dateFromSiteArray[2]) };
        }
    }
}
