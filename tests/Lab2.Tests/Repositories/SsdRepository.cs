using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Repositories;

public class SsdRepository : RepositoryBase<Ssd>
{
    public SsdRepository()
    {
        Add(new SsdBuilder()
            .WithName("Kingston A400")
            .WithConnectivityTechnology(DriveConnectivityTechnology.Sata)
            .WithMemorySize(480)
            .WithSpeed(500)
            .WithPowerConsumption(1.53)
            .Build());

        Add(new SsdBuilder()
            .WithName("ARDOR GAMING Ally AL1284")
            .WithConnectivityTechnology(DriveConnectivityTechnology.Pcie)
            .WithMemorySize(512)
            .WithSpeed(3100)
            .WithPowerConsumption(4)
            .Build());
    }
}