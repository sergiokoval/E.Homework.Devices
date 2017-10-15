using E.Homework.Devices.Data;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace E.Homework.Devices.Business.Device
{
    /// <summary>
    /// Base implementation for web connected device
    /// </summary>
    public abstract class ConnectedDevice : ITelemetryDevice
    {
        public string Id { get; set; }
        private readonly HubConnection _hubConnection;
        private IHubProxy _telemetryProxy;        

        public ConnectedDevice(string connectionString)
        {
            _hubConnection = new HubConnection(connectionString);
            Console.WriteLine("Starting sensor device simulator ... ");
        }       

        public abstract TelemetryReading ReadData();

        public virtual void PublishData()
        {
            //_telemetryProxy.Invoke("Publish", new object[] { Id, ReadData().Value,ReadData().Units });
            _telemetryProxy.Invoke("Publish", new object[] { new TelemetryMessage(){
                DeviceId = Id,
                Value = ReadData().Value.ToString(),
                Units = ReadData().Units,
             TimeStamp = DateTime.Now
            } });
        }

        public async Task Connect()
        {
            _telemetryProxy = _hubConnection.CreateHubProxy("TelemetryHub");
            await _hubConnection.Start();

            System.Console.WriteLine(string.Format("Device with id:{0} has been connected", Id));
        }       
    }
}
