using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Repositories;

public class CoolerRepository : RepositoryBase<Cooler>
{
    public CoolerRepository()
    {
        Add(new CoolerBuilder()
            .WithName("DEEPCOOL AK620")
            .WithHeight(160)
            .WithWidth(129)
            .WithLength(138)
            .WithTdp(260)
            .WithCompatibleSockets(new List<string>
            {
                "AM2", "AM2+", "AM3", "AM3+", "AM4", "AM5", "FM1", "FM2", "FM2+", "LGA 1150", "LGA 1151",
                "LGA 1155", "LGA 1200", "LGA 1700", "LGA 2011", "LGA 2011-3", "LGA 2066",
            })
            .Build());

        Add(new CoolerBuilder()
            .WithName("DEEPCOOL AK400")
            .WithHeight(155)
            .WithWidth(127)
            .WithLength(97)
            .WithTdp(220)
            .WithCompatibleSockets(new List<string>
            {
                "AM4", "AM5", "LGA 1150", "LGA 1151", "LGA 1155", "LGA 1156", "LGA 1200", "LGA 1700",
            })
            .Build());
    }
}