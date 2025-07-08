using BuildYourPC.Domain.Entities.Base;

namespace BuildYourPC.Domain.Entities;

public class BuildComponent
{
    public int BuildId { get; set; }
    public Build Build { get; set; } = null!;

    public int ComponentId { get; set; }
    public Component Component { get; set; } = null!;

    public int Quantity { get; set; }
}
