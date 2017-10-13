using E.Homework.Devices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Homework.Devices.Business.Device.Sensor
{
    /// <summary>
    /// Temperature sensor device simulator
    /// </summary>
    public class TemperatureSensorSimulator : ConnectedDevice
    {
        public TemperatureSensorSimulator(string connectionString) : base(connectionString)
        {
        }

        public override TelemetryReading ReadData()
        {
            return new TelemetryReading() { Value = new Random().Next(0,100), Units = "Celsius" };
        }
    }
}
