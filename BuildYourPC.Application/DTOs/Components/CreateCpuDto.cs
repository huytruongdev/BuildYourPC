using System.ComponentModel.DataAnnotations;

namespace BuildYourPC.Application.DTOs.Components;

public class CreateCpuDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Manufacturer { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Model { get; set; } = string.Empty;

    [Range(0.01, 10000.00)]
    public decimal Price { get; set; }

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [Url]
    [MaxLength(255)]
    public string ImageUrl { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)] //TODO: check socket load from db
    public string SocketType { get; set; } = string.Empty;

    [Range(1, 128)]
    public int Cores { get; set; }

    [Range(1, 256)]
    public int Threads { get; set; }

    [Range(500.0, 6000.0)]
    public double BaseClockMhz { get; set; }

    [Range(500.0, 7000.0)]
    public double BoostClockMhz { get; set; }

    public bool HasIntegratedGraphics { get; set; }

    [Range(1, 500)]
    public int TdpWatts { get; set; }

    [Range(0, 128)]
    public int CacheL3MB { get; set; }
}
