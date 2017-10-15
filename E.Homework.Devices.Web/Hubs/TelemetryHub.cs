using E.Homework.Devices.Business.DeviceDataCollection;
using E.Homework.Devices.Data;
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
                (message) =>
                        {
                            Clients.All.updateDashboard(message);
                        },
                (message, messageCount) =>
                        {
                            Clients.All.publishData(message, messageCount);
                        });
        }

        public void Publish(TelemetryMessage message)
        {
            _deviceDataController.PublishData(message);
        }            
    }
}