using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Repositories;

public class CpuRepository : RepositoryBase<Cpu>
{
    public CpuRepository()
    {
        Add(new CpuBuilder()
            .WithName("Intel Core i5-12400F")
            .WithSocket("LGA 1700")
            .WithCoreCount(6)
            .WithClockSpeed(2.5)
            .WithMaxRamSpeed(4800)
            .WithTdp(117)
            .WithPowerConsumption(65)
            .Build());

        Add(new CpuBuilder()
            .WithName("Intel Core i3-12100F")
            .WithSocket("LGA 1700")
            .WithCoreCount(4)
            .WithClockSpeed(3.3)
            .WithMaxRamSpeed(4800)
            .WithTdp(89)
            .WithPowerConsumption(58)
            .Build());
    }
}