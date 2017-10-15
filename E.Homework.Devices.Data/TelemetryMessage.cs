using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Homework.Devices.Data
{
    /// <summary>
    /// Telemetry device message DTO
    /// </summary>
    public class TelemetryMessage
    {       
        public string DeviceId { get; set; }

        public string Value { get; set; }

        public string Units { get; set; }

        public DateTime TimeStamp { get; set; }
        
    }
}
