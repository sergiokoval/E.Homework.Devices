using E.Homework.Devices.Business.Device;
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
        ConcurrentDictionary<string, TelemetryDeviceStatistics> _devices = new ConcurrentDictionary<string, TelemetryDeviceStatistics>();

        public void Publish(string id, string data)
        {
            if(_devices.ContainsKey(id))
            {
                _devices[id].LastSeen = DateTime.Now;
                _devices[id].PublishedMessagesCount++;
            }
            else
            {
                _devices.TryAdd(id, new TelemetryDeviceStatistics() { LastSeen = DateTime.Now });
            }

            Clients.All.broadcastMessage(id, data);
        }
    }
}