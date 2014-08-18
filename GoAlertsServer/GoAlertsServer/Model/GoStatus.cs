using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAlertsServer.Model {
    public class GoStatus {
        public List<LineStatus> TrainStatusesByLineName { get; private set; }

        public List<LineStatus> BusStatusesByRouteId { get; private set; }

        public GoStatus() {
            TrainStatusesByLineName = new List<LineStatus>();
            BusStatusesByRouteId = new List<LineStatus>();
        }
    }
}
