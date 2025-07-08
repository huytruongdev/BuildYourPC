using Domain.Interfaces;

namespace BuildYourPC.Domain.Entities;

public class Build : IAuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int UserId { get; set; }

    // Collection of components in this build (many-to-many relationship via BuildComponent)
    public ICollection<BuildComponent> BuildComponents { get; set; } = [];

    public decimal TotalPrice
    {
        get
        {
            return BuildComponents.Sum(bc => bc.Component.Price * bc.Quantity);
        }
    }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
