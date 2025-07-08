using BuildYourPC.Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities.SpecificComponents;

public class Gpu : Component
{
    public Gpu()
    {
        ComponentType = ComponentType.GPU;
    }

    public string Chipset { get; set; } = string.Empty;
    public int MemorySizeGB { get; set; }
    public RamType MemoryType { get; set; }
    public double CoreClockMhz { get; set; }
    public double BoostClockMhz { get; set; }
    public string Interface { get; set; } = string.Empty;
    public int TdpWatts { get; set; }
}
