using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Homework.Devices.Data
{
    public class TelemetryMessage
    {
        public int MessageId { get; set; }
        public string DeviceId { get; set; }

        public string PayLoad { get; set; }

        public string Units { get; set; }

        public DateTime TimeStamp { get; set; }
        
    }
}
