using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Repositories;

public class RamRepository : RepositoryBase<Ram>
{
    public RamRepository()
    {
        Add(new RamBuilder()
            .WithName("Kingston FURY Beast Black")
            .WithMemorySize(8)
            .WithDdrStandard(4)
            .WithFormFactor(RamFormFactor.Dimm)
            .WithPowerConsumption(1.35)
            .WithJedec(new Jedec(3200, new Timings(16, 18, 18, 36), 1.35))
            .Build());

        Add(new RamBuilder()
            .WithName("ADATA XPG GAMMIX D35")
            .WithMemorySize(8)
            .WithDdrStandard(4)
            .WithFormFactor(RamFormFactor.Dimm)
            .WithPowerConsumption(1.35)
            .WithJedec(new Jedec(3200, new Timings(16, 20, 20, null), 1.35))
            .Build());
    }
}