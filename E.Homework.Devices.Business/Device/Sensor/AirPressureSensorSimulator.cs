using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E.Homework.Devices.Data;

namespace E.Homework.Devices.Business.Device.Sensor
{
    public class AirPressureSensorSimulator : ConnectedDevice
    {
        public AirPressureSensorSimulator(string connectionString) : base(connectionString)
        {
        }

        public override TelemetryReading ReadData()
        {
            return new TelemetryReading() { Value = 2, Units = "Bar" };
        }
    }
}
