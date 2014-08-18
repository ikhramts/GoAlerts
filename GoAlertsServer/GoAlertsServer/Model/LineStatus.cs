using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAlertsServer.Model {
    public class LineStatus {

        /// <summary>
        /// Identifying name for train lines, and descriptive name for
        /// bus routes.
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// Only valid for GO buses; GO train lines are identified only by name.
        /// </summary>
        public int RouteId { get; set; }

        public bool IsOnTime { get; set; }

        /// <summary>
        /// Used only by trains.
        /// </summary>
        public int SecondsLate { get; set; }
        public string Message { get; set; }

        public LineStatus()
        {
            IsOnTime = true;
            SecondsLate = 0;
            Message = "";
        }

        public LineStatus(string name)
            : this() 
        {
            LineName = name;
        }

        public LineStatus(string name, int routeId)
            : this(name)
        {
            RouteId = routeId;
        }
    }
}
