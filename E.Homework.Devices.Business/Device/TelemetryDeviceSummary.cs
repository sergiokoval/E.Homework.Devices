using System;

namespace E.Homework.Devices.Business.Device
{
    /// <summary>
    /// Used for dashboard device statistic representation
    /// </summary>
    public class TelemetryDeviceSummary
    {
        public int PublishedMessagesCount { get; set; }
        public DateTime LastSeen { get; set; }
    }
}
