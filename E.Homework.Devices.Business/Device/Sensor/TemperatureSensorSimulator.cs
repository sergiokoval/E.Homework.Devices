using E.Homework.Devices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Homework.Devices.Business.Device.Sensor
{
    public class TemperatureSensorSimulator : ConnectedDevice
    {
        public TemperatureSensorSimulator(string connectionString) : base(connectionString)
        {
        }

        public override TelemetryReading ReadData()
        {
            return new TelemetryReading() { Value = 10, Units = "C" };
        }
    }
}
