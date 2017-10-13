using E.Homework.Devices.Data;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace E.Homework.Devices.Business.Device
{
    public abstract class ConnectedDevice : ITelemetryDevice
    {
        private readonly HubConnection _hubConnection;
        private IHubProxy _telemetryProxy;

        public ConnectedDevice(string connectionString)
        {
            _hubConnection = new HubConnection(connectionString);
        }
        public string Id { get; set; }

        public abstract TelemetryReading ReadData();

        public virtual void PublishData()
        {
           _telemetryProxy.Invoke("Publish", new object[] { Id, ReadData().Value,ReadData().Units });
        }

        public async Task Connect()
        {
            _hubConnection.StateChanged += _hubConnection_StateChanged;

            _telemetryProxy = _hubConnection.CreateHubProxy("TelemetryHub");
            await _hubConnection.Start();
        }

        private void _hubConnection_StateChanged(StateChange obj)
        {
            Console.WriteLine(obj.NewState);
        }
    }
}
