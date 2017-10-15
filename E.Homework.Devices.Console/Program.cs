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

            // create few sensor device simulator devices
            var sensor2 = new TemperatureSensorSimulator(connString);
            var sensor1 = new AirPressureSensorSimulator(connString);           
            var sensor3 = new TemperatureSensorSimulator(connString);

            // assign some random ids
            sensor1.Id = Guid.NewGuid().ToString();
            sensor2.Id = Guid.NewGuid().ToString();
            sensor3.Id = Guid.NewGuid().ToString();           

            // connect to web hub


            var con = sensor1.Connect();
            var con2 = sensor2.Connect();
            var con3 = sensor3.Connect();

            // normally some retry logic goes here
            try
            {
                con.Wait();
                con2.Wait();
                con3.Wait();
            }
            catch(AggregateException ae)
            {
                System.Console.WriteLine("Error while connecting to the server. Press enter to exit");
                System.Console.ReadLine();
                Environment.Exit(1);
            }

            // cancellation feature
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


            System.Console.WriteLine("Press enter to stop device simulation...");
            System.Console.ReadLine();

            cancellationTokenSource.Cancel();
            System.Console.WriteLine("Press enter to exit");

            System.Console.ReadLine();
        }


    }
}
