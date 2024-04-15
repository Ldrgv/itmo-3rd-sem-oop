using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Repositories;

public class HddRepository : RepositoryBase<Hdd>
{
    public HddRepository()
    {
        Add(new HddBuilder()
            .WithName("WD Blue")
            .WithMemorySize(1000)
            .WithRpm(7200)
            .WithPowerConsumption(6.8)
            .Build());

        Add(new HddBuilder()
            .WithName("WD Purple Surveillance")
            .WithMemorySize(4800)
            .WithRpm(5400)
            .WithPowerConsumption(4.7)
            .Build());
    }
}