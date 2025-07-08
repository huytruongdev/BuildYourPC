using BuildYourPC.Domain.Entities.Base;
using Domain.Enums;

namespace BuildYourPC.Domain.Entities.SpecificComponents;

public class Cpu : Component
{
    public Cpu()
    {
        ComponentType = ComponentType.CPU;
    }

    public string SocketType { get; set; } = string.Empty;
    public int Cores { get; set; }
    public int Threads { get; set; }
    public double BaseClockMhz { get; set; }
    public double BoostClockMhz { get; set; }
    public bool HasIntegratedGraphics { get; set; }
    public int TdpWatts { get; set; }
    public int CacheL3MB { get; set; }
}