using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Repositories;

public class PcCaseRepository : RepositoryBase<PcCase>
{
    public PcCaseRepository()
    {
        Add(new PcCaseBuilder()
            .WithName("Cougar Duoface Pro RGB")
            .WithLength(465)
            .WithWidth(240)
            .WithHeight(496)
            .WithCompatibleMotherboardFormFactors(new List<string>
            {
                "E-ATX", "Micro-ATX", "Mini-ITX", "SSI-CEB", "Standard-ATX",
            })
            .WithGraphicsCardMaxLength(390)
            .Build());

        Add(new PcCaseBuilder()
            .WithName("DEEPCOOL CC560 WH")
            .WithLength(416)
            .WithWidth(210)
            .WithHeight(477)
            .WithCompatibleMotherboardFormFactors(new List<string>
            {
                "Micro-ATX", "Mini-ITX", "Standard-ATX",
            })
            .WithGraphicsCardMaxLength(370)
            .Build());
    }
}