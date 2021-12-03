using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using WildHackWebApp.Models;

namespace WildHackWebApp.BL
{
    public class Parsetool
    {
        /// <summary>
        /// Возвращает новые статьи
        /// </summary>
        public static List<EcologyEvent> GetLastUpdates()
        {
            List<EcologyEvent> resultList = new List<EcologyEvent>();
            string url = "https://poluostrov-kamchatka.ru/pknews/english/14/";
            string cls = "article-info";

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);

            var tags = doc.DocumentNode.SelectNodes($"//div[@class='{cls}']");

            int i = 0;
            foreach (HtmlNode node in tags)
            {
                EcologyEvent ecologyEvent = new EcologyEvent();
                ecologyEvent.Id = i;
                ecologyEvent.Title = node.SelectSingleNode("./p[1]").InnerText;
                resultList.Add(ecologyEvent);
                i++;
            }

            return resultList;
        }
    }
}
