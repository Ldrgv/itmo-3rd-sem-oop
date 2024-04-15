using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Repositories;

public class GraphicsCardRepository : RepositoryBase<GraphicsCard>
{
    public GraphicsCardRepository()
    {
        Add(new GraphicsCardBuilder()
            .WithName("Palit GeForce RTX 3060 Ti Dual")
            .WithMemorySize(8)
            .WithClockSpeed(1418)
            .WithPcieVersion("4.0")
            .WithPowerConsumption(225)
            .WithLength(294)
            .WithHeight(118)
            .Build());

        Add(new GraphicsCardBuilder()
            .WithName("KFA2 GeForce RTX 3050")
            .WithMemorySize(8)
            .WithClockSpeed(1552)
            .WithPcieVersion("4.0")
            .WithPowerConsumption(550)
            .WithLength(209)
            .WithHeight(118)
            .Build());
    }
}