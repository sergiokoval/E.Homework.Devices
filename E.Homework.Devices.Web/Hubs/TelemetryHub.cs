using E.Homework.Devices.Business.Device;
using E.Homework.Devices.Business.DeviceDataCollection;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E.Homework.Devices.Web.Hubs
{
    
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
                (deviceId, data) => 
                        {
                            Clients.All.publishData(deviceId, data);
                        });
        }

        public void Publish(string id, string data, string units)
        {
            // TODO: rename UpdateStatistics 
            _deviceDataController.UpdateStatistics(id, data, units);

            Clients.All.broadcastMessage(id, data);
        }
    }
}