using E.Homework.Devices.Business.Device.Sensor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E.Homework.Devices.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var sensor1 = new AirPressureSensorSimulator("http://localhost:36210");
            var sensor2 = new TemperatureSensorSimulator("http://localhost:36210");
            sensor1.Id = "s1";

            Thread.Sleep(5000);

            var con = sensor1.Connect();
            con.Wait();
            sensor1.PublishData();

            System.Console.ReadLine();
        }


    }
}
