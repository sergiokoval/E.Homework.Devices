using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Homework.Devices.Business.Device
{
    interface ITelemetryDevice
    {
        string Id { get; set; }

        Task Connect();

        void PublishData();
    }
}
