using E.Homework.Devices.Business.DeviceDataCollection;
using Microsoft.AspNet.SignalR;

namespace E.Homework.Devices.Web.Hubs
{
    /// <summary>
    /// SignalR hub for device telemetry publishing
    /// </summary>
    public class TelemetryHub : Hub
    {
        private readonly DeviceDataController _deviceDataController;

        public TelemetryHub()
        {
            _deviceDataController = new DeviceDataController(
                (newDeviceId, units) =>
                        {
                            Clients.All.updateDashboard(newDeviceId, units);
                        },
                (deviceId, data, messageCount) =>
                        {
                            Clients.All.publishData(deviceId, data, messageCount);
                        });
        }

        public void Publish(string deviceId, string data, string units)
        {
            _deviceDataController.PublishData(deviceId, data, units);
        }            
    }
}