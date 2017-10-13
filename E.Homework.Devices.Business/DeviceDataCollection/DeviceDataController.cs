using E.Homework.Devices.Business.Device;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace E.Homework.Devices.Business.DeviceDataCollection
{
    /// <summary>
    /// Main device data/telemetry controller
    /// </summary>
    public sealed class DeviceDataController
    {        
        private Action<string,string> _onDeviceRegisteredAction;
        private Action<string,string,string> _onDeviceDataPublishedAction;

        static object lockobj = new object();

        public static readonly ConcurrentDictionary<string, TelemetryDeviceSummary> _devices = 
            new ConcurrentDictionary<string, TelemetryDeviceSummary>();

        public DeviceDataController(Action<string,string> onDeviceRegirsteredAction, 
                                        Action<string,string,string> onDeviceDataPublishedAction)
        {
            _onDeviceRegisteredAction = onDeviceRegirsteredAction;
            _onDeviceDataPublishedAction = onDeviceDataPublishedAction;
        }

        public void PublishData(string deviceId, string data, string units)
        {
            if (!_devices.ContainsKey(deviceId))
            {
                RegisterDevice(deviceId,units);               
            }

            _devices[deviceId].PublishedMessagesCount++;
            _devices[deviceId].LastSeen = DateTime.Now;

            if (_onDeviceDataPublishedAction != null)
            {
                _onDeviceDataPublishedAction(deviceId, data, _devices[deviceId].PublishedMessagesCount.ToString());
            }

        }

        void RegisterDevice(string deviceId,string units)
        {
            var success = _devices.TryAdd(deviceId, new TelemetryDeviceSummary() { LastSeen = DateTime.Now });
            if (success)
            {
                if (_onDeviceRegisteredAction != null)
                {
                    lock (lockobj)
                    {
                        _onDeviceRegisteredAction(deviceId, units);
                    }
                }
            }
        }
    }
}
