using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;

using GoAlertsServer.Model;

namespace GoAlertsServer.Scraper
{
    public class GoStatusScraper
    {
        public static GoStatus ScapeAll()
        {
            var status = new GoStatus();
            return status;
        }

        public static GoStatus ScrapeMainPage(string mainPageHtml)
        {
            var status = new GoStatus();
            return status;
        }

        /// <summary>
        /// Extract a bus status message from the bus status page.
        /// </summary>
        /// <param name="pageHtml"></param>
        /// <returns></returns>
        public static string ScrapeBusStatusMessage(string busStatusPageHtml)
        {
            return "";
        }

        public static List<LineStatus> ScrapeBusRoutes(string mainStatusPageHtml)
        {
            var statusPage = new HtmlDocument();
            statusPage.LoadHtml(mainStatusPageHtml);

            var busRoutesDiv = statusPage.GetElementbyId("ctl00_ContentPlaceHolder1_busAdvisories_busAdvListCombo");
            var routesList = busRoutesDiv.Descendants("li");
            var busRoutes = new List<LineStatus>();

            foreach (var li in routesList)
            {
                var innerText = li.InnerText;
                if (innerText.Contains("All Bus Routes"))
                    continue;

                var lineStatus = ParseBusRoute(innerText);
                busRoutes.Add(lineStatus);
            }

            return busRoutes;
        }

        public static List<LineStatus> ScrapeTrainStatuses(string statusPageHtml)
        {
            var trainLines = new List<LineStatus>();
            return trainLines;
        }

        public static List<LineStatus> ScrapeDelayedBusRoutes(string statusPageHtml)
        {
            var delayedRoutes = new List<LineStatus>();
            return delayedRoutes;
        }

        /// <summary>
        /// Converts bus route name in form of "90 - Newcastle Hwy 2 Train Meet Service"
        /// into a LineStatus object.
        /// </summary>
        /// <param name="busRouteString"></param>
        /// <returns></returns>
        public static LineStatus ParseBusRoute(string busRouteString)
        {
            var routeParts = busRouteString.Split(new char[] { '-' })
                                           .Select(s => s.Trim()).ToArray();

            var lineStatus = new LineStatus();
            lineStatus.RouteId = int.Parse(routeParts[0]);
            lineStatus.LineName = routeParts[1];
            return lineStatus;
        }
    }
}
