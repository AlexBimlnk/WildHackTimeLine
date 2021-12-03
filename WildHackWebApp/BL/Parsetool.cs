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
        private static Dictionary<SiteName, string> keyValues = new Dictionary<SiteName, string>
        {
            {SiteName.SiteName1, "tag1|url" },
            {SiteName.SiteName2, "tag2|url" }
        };

        //Публичный метод возвращаюий модели
        public static void GetLastUpd()
        {
            foreach(var siteName in keyValues.Keys)
            {
                ParsLogic(siteName);
            }
        }

        //Закрытый метод выполняющий логику парса
        private static void ParsLogic(SiteName siteName)
        {
            var mas = keyValues[siteName].Split('|');
            string tag = mas[0];
            string url = mas[1];
            //Здесь будет прописана логика, которая подходит для всех сайтов
            //TODO
        }

        /// <summary>
        /// Возвращает список новых экологических событий.
        /// </summary>
        /// <returns>Список <see cref="EcologyEvent"/>.</returns>
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
