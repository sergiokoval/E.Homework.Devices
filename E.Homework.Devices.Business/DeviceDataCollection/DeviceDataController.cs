using E.Homework.Devices.Business.Device;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace E.Homework.Devices.Business.DeviceDataCollection
{
    public sealed class DeviceDataController
    {
        private Action<string,string> _onDeviceRegisteredAction;
        private Action<string,string> _onDeviceDataPublishedAction;

        public static readonly ConcurrentDictionary<string, TelemetryDeviceStatistics> _devices = 
            new ConcurrentDictionary<string, TelemetryDeviceStatistics>();

        public DeviceDataController(Action<string,string> onDeviceRegirsteredAction, 
                                        Action<string,string> onDeviceDataPublishedAction)
        {
            _onDeviceRegisteredAction = onDeviceRegirsteredAction;
            _onDeviceDataPublishedAction = onDeviceDataPublishedAction;
        }

        public void UpdateStatistics(string deviceId, string data, string units)
        {
            if (!_devices.ContainsKey(deviceId))
            {
                RegisterDevice(deviceId,units);               
            }

            _devices[deviceId].PublishedMessagesCount++;
            _devices[deviceId].LastSeen = DateTime.Now;

            Debug.WriteLine(deviceId + " " + data + " , count - " + _devices[deviceId].PublishedMessagesCount);

            _onDeviceDataPublishedAction(deviceId, data);

        }

        void RegisterDevice(string deviceId,string units)
        {
            var success = _devices.TryAdd(deviceId, new TelemetryDeviceStatistics() { LastSeen = DateTime.Now });
            if (success)
            {
                if (_onDeviceRegisteredAction != null)
                {
                    _onDeviceRegisteredAction(deviceId, units);
                }
            }
        }
    }
}
