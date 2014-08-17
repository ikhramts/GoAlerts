using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAlertsServer.Model {
    public class GoStatus {
        public List<LineStatus> TrainStatuses { get; private set; }
        public List<LineStatus> BusStatuses { get; private set; }
    }
}
