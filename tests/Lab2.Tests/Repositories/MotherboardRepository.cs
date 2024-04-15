using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Repositories;

public class MotherboardRepository : RepositoryBase<Motherboard>
{
    public MotherboardRepository()
    {
        Add(new MotherboardBuilder()
            .WithName("GIGABYTE B550 AORUS ELITE V2")
            .WithFormFactor("Standard-ATX")
            .WithCpuSocket("AM4")
            .WithDdrStandard(4)
            .WithRamFormFactor(RamFormFactor.Dimm)
            .WithRamCount(4)
            .WithMaxRamSize(128)
            .WithOperatingFrequencies(new List<int> { 3200, 2933, 2667, 2400, 2133 })
            .WithPcieVersion("4.0")
            .WithPcieCount(3)
            .WithSataCount(4)
            .WithBios(new BiosBuilder()
                .WithType("AMI UEFI BIOS")
                .WithVersion("F1")
                .WithCompatibleCpus(new List<string> { "Ryzen 7 4700G", "Ryzen 5 5600G", "Ryzen 3 PRO 4350GE" })
                .Build())
            .Build());

        Add(new MotherboardBuilder()
            .WithName("GIGABYTE H610M H DDR4")
            .WithFormFactor("Micro-ATX")
            .WithCpuSocket("LGA 1700")
            .WithDdrStandard(4)
            .WithRamFormFactor(RamFormFactor.Dimm)
            .WithRamCount(2)
            .WithMaxRamSize(64)
            .WithOperatingFrequencies(new List<int> { 3200, 3000, 2933, 2666, 2400, 2133 })
            .WithPcieVersion("4.0")
            .WithPcieCount(1)
            .WithSataCount(4)
            .WithBios(new BiosBuilder()
                .WithType("AMI UEFI BIOS")
                .WithVersion("FL")
                .WithCompatibleCpus(new List<string> { "Intel Core I9-13900KS", "Intel Core i3-12100F", "Intel Core I5-13400F" })
                .Build())
            .Build());
    }
}