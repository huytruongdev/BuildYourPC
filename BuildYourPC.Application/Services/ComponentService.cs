using BuildYourPC.Application.DTOs.Components;
using BuildYourPC.Application.Interfaces;
using BuildYourPC.Domain.Entities.SpecificComponents;
using BuildYourPC.Infrastructure.DB;
using Domain.Enums;

namespace BuildYourPC.Application.Services
{
    public class ComponentService() : IComponentService
    {

        public async Task<Cpu> CreateCpuAsync(CreateCpuDto cpuDto)
        {
            var cpu = new Cpu
            {
                Name = cpuDto.Name,
                Manufacturer = cpuDto.Manufacturer,
                Model = cpuDto.Model,
                Price = cpuDto.Price,
                Description = cpuDto.Description,
                ImageUrl = cpuDto.ImageUrl,
                ComponentType = ComponentType.CPU,
                SocketType = cpuDto.SocketType,
                Cores = cpuDto.Cores,
                Threads = cpuDto.Threads,
                BaseClockMhz = cpuDto.BaseClockMhz,
                BoostClockMhz = cpuDto.BoostClockMhz,
                HasIntegratedGraphics = cpuDto.HasIntegratedGraphics,
                TdpWatts = cpuDto.TdpWatts,
                CacheL3MB = cpuDto.CacheL3MB
            };

            return cpu;
        }

        public async Task<IEnumerable<Cpu>> GetCpus()
        {
            return await MySqlProvider.MySqlInstance.QueryAsync<Cpu>("select * from Components");
        }
    }
}
