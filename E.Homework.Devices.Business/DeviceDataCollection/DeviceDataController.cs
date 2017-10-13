using E.Homework.Devices.Business.Device;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace E.Homework.Devices.Business.DeviceDataCollection
{
    public sealed class DeviceDataController
    {
        private Action<string> _onDeviceRegisteredAction;
        private Action<string,string> _onDeviceDataPublishedAction;

        public static readonly ConcurrentDictionary<string, TelemetryDeviceStatistics> _devices = 
            new ConcurrentDictionary<string, TelemetryDeviceStatistics>();

        public DeviceDataController(Action<string> onDeviceRegirsteredAction, Action<string,string> onDeviceDataPublishedAction)
        {
            _onDeviceRegisteredAction = onDeviceRegirsteredAction;
            _onDeviceDataPublishedAction = onDeviceDataPublishedAction;
        }

        public void UpdateStatistics(string deviceId, string telemetryReading)
        {
            if (_devices.ContainsKey(deviceId))
            {
                _devices[deviceId].PublishedMessagesCount++;
                _devices[deviceId].LastSeen = DateTime.Now;

                Debug.WriteLine(deviceId + " " + telemetryReading + " , count - " + _devices[deviceId].PublishedMessagesCount);

                _onDeviceDataPublishedAction(deviceId, telemetryReading);
            }
            else
            {
                RegisterDevice(deviceId);

                if (_onDeviceRegisteredAction != null)
                {
                    _onDeviceRegisteredAction(deviceId);
                }
            }
        }

        void RegisterDevice(string deviceId)
        {
          var success =  _devices.TryAdd(deviceId, new TelemetryDeviceStatistics() { LastSeen = DateTime.Now });
            if(success)
            {
                if (_onDeviceRegisteredAction != null)
                {
                    _onDeviceRegisteredAction(deviceId);
                }
            }
        }
    }
}
