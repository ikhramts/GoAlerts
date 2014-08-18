using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using GoAlertsServer.Model;
using GoAlertsServer.Scraper;

namespace TestGoAlerts.Scraper
{
    public class TestGoStatusScraper
    {
        [Test]
        [TestCase("11 - St. Catharines / Niagara on the Lake", "St. Catharines / Niagara on the Lake", 11)]
        [TestCase("\n    \t30 - Kitchener / Bramalea    \n\n    ", "Kitchener / Bramalea", 30)]
        [TestCase("46 - Oakville Hwy 407 Service", "Oakville Hwy 407 Service", 46)]
        [TestCase("93 - UOIT/Durham College Hwy 401 Express Ser", "UOIT/Durham College Hwy 401 Express Ser", 93)]
        [TestCase("96 - Oshawa Hwy 401 Service", "Oshawa Hwy 401 Service", 96)]
        [TestCase("98 - Pickering / Finch", "Pickering / Finch", 98)]
        public void ParseBusRoutes(string input, string name, int routeId)
        {
            var lineStatus = GoStatusScraper.ParseBusRoute(input);
            Assert.AreEqual(name, lineStatus.LineName);
            Assert.AreEqual(routeId, lineStatus.RouteId);
        }

        [Test]
        public void ScrapeBusRoutes()
        {
            var html = File.ReadAllText(@"TestPages\ServiceStatusPage - Two Bus Routes.html");
            var unorderedRoutes = GoStatusScraper.ScrapeBusRoutes(html);
            var routes = unorderedRoutes.OrderBy(l => l.RouteId).ToList();

            Assert.AreEqual(2, routes.Count);
            Assert.AreEqual(30, routes[0].RouteId);
            Assert.AreEqual("Kitchener / Bramalea", routes[0].LineName);
            Assert.AreEqual(67, routes[1].RouteId);
            Assert.AreEqual("Finch GO / Glenwoods", routes[1].LineName);
        }

        [Test]
        [TestCase("", 0, null, -1, null, -1)]
        [TestCase("", 90, "Newcastle Hwy 2 Train Meet Service", -1, null, -1)]
        public void ScrapeDelayedBusRoutes(string input, int numRoutes, string route1Name, int route1Id,
                                            string route2Name, int route2Id)
        {

        }
    }
}
