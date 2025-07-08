using BuildYourPC.Application.DTOs.Components;
using BuildYourPC.Domain.Entities.SpecificComponents;

namespace BuildYourPC.Application.Interfaces;

public interface IComponentService
{
    Task<Cpu> CreateCpuAsync(CreateCpuDto cpuDto);

    Task<IEnumerable<Cpu>> GetCpus();
}
