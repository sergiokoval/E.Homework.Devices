using E.Homework.Devices.Business.Device;
using E.Homework.Devices.Data;
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
        private Action<TelemetryMessage> _onDeviceRegisteredAction;
        private Action<TelemetryMessage, string> _onDeviceDataPublishedAction;

        static object lockobj = new object();

        public static readonly ConcurrentDictionary<string, TelemetryDeviceSummary> _devices = 
            new ConcurrentDictionary<string, TelemetryDeviceSummary>();

        public DeviceDataController(Action<TelemetryMessage> onDeviceRegirsteredAction, 
                                        Action<TelemetryMessage, string> onDeviceDataPublishedAction)
        {
            _onDeviceRegisteredAction = onDeviceRegirsteredAction;
            _onDeviceDataPublishedAction = onDeviceDataPublishedAction;
        }

        public void PublishData(TelemetryMessage message)
        {
            if (!_devices.ContainsKey(message.DeviceId))
            {
                RegisterDevice(message);               
            }

            _devices[message.DeviceId].PublishedMessagesCount++;
            _devices[message.DeviceId].LastSeen = message.TimeStamp;

            if (_onDeviceDataPublishedAction != null)
            {
                _onDeviceDataPublishedAction(message, _devices[message.DeviceId].PublishedMessagesCount.ToString());
            }

        }

        void RegisterDevice(TelemetryMessage message)
        {
            var success = _devices.TryAdd(message.DeviceId, new TelemetryDeviceSummary() { LastSeen = message.TimeStamp });
            if (success)
            {
                if (_onDeviceRegisteredAction != null)
                {
                    lock (lockobj)
                    {
                        _onDeviceRegisteredAction(message);
                    }
                }
            }
        }
    }
}
