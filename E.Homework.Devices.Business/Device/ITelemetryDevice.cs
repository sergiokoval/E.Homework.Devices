using System.Threading.Tasks;

namespace E.Homework.Devices.Business.Device
{
    /// <summary>
    /// Top level device interface
    /// </summary>
    public interface ITelemetryDevice
    {
        string Id { get; set; }

        Task Connect();

        void PublishData();
    }
}
