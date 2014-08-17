using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAlertsServer.Model {
    public class LineStatus {
        public string LineName { get; set; }
        public bool IsOnTime { get; set; }
        public int SecondsLate { get; set; }
        public string Message { get; set; }
    }
}
