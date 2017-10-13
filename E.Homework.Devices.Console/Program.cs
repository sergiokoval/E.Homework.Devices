using E.Homework.Devices.Business.Device.Sensor;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            var connString = ConfigurationManager.AppSettings["publishingConnectionString"];

            var sensor2 = new TemperatureSensorSimulator(connString);
            var sensor1 = new AirPressureSensorSimulator(connString);           
            var sensor3 = new TemperatureSensorSimulator(connString);

            sensor1.Id = Guid.NewGuid().ToString();
            sensor2.Id = Guid.NewGuid().ToString();
            sensor3.Id = Guid.NewGuid().ToString();           

            var con = sensor1.Connect();
            var con2 = sensor2.Connect();
            var con3 = sensor3.Connect();

            con.Wait();
            con2.Wait();
            con3.Wait();

            var cancellationTokenSource = new CancellationTokenSource();

            new Task(() =>
            {
                while (!cancellationTokenSource.IsCancellationRequested)
                {
                    sensor1.PublishData();
                    Thread.Sleep(1000);
                    sensor2.PublishData();
                    Thread.Sleep(1000);
                    sensor3.PublishData();
                }
            }).Start();


            System.Console.WriteLine("press enter to stop device simulation...");
            System.Console.ReadLine();

            cancellationTokenSource.Cancel();

            System.Console.ReadLine();
        }


    }
}
