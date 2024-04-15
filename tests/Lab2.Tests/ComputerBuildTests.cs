using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerValidatorResult;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions.ValidatorExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComputerValidator;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.Repositories;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ComputerBuildTests
{
    private readonly IRepository<Motherboard> _motherboards;
    private readonly IRepository<Cpu> _cpus;
    private readonly IRepository<Cooler> _coolers;
    private readonly IRepository<Ram> _rams;
    private readonly IRepository<GraphicsCard> _graphicsCards;
    private readonly IRepository<Ssd> _ssds;
    private readonly IRepository<Hdd> _hdds;
    private readonly IRepository<PcCase> _pcCases;
    private readonly IRepository<PowerSupply> _powerSupplies;

    private readonly Computer _validComputer;

    public ComputerBuildTests()
    {
        _motherboards = new MotherboardRepository();
        _cpus = new CpuRepository();
        _coolers = new CoolerRepository();
        _rams = new RamRepository();
        _graphicsCards = new GraphicsCardRepository();
        _ssds = new SsdRepository();
        _hdds = new HddRepository();
        _pcCases = new PcCaseRepository();
        _powerSupplies = new PowerSupplyRepository();

        _validComputer = new ComputerBuilder()
            .WithMotherboard(_motherboards.GetByName("GIGABYTE H610M H DDR4"))
            .WithCpu(_cpus.GetByName("Intel Core i3-12100F"))
            .WithGraphicsCard(_graphicsCards.GetByName("KFA2 GeForce RTX 3050"))
            .WithRam(_rams.GetByName("ADATA XPG GAMMIX D35"))
            .WithRam(_rams.GetByName("ADATA XPG GAMMIX D35"))
            .WithSsd(_ssds.GetByName("ARDOR GAMING Ally AL1284"))
            .WithCooler(_coolers.GetByName("DEEPCOOL AK400"))
            .WithPowerSupply(_powerSupplies.GetByName("DEEPCOOL PF700"))
            .WithCase(_pcCases.GetByName("DEEPCOOL CC560 WH"))
            .Build();
    }

    [Fact]
    public void ValidComputerTest()
    {
        CompatibilityResult validatorResult = new ComputerValidator().Validate(_validComputer);

        Assert.Equal(CompatibilityStatus.Compatible, validatorResult.Status);
    }

    [Fact]
    public void PowerSupplyHasIssueTest()
    {
        Computer computer = new ComputerBuilder(_validComputer)
            .WithCpu(new CpuBuilder(_validComputer.Cpu)
                .WithPowerConsumption(_validComputer.PowerSupply.Wattage -
                                      _validComputer.PowerConsumtion +
                                      _validComputer.Cpu.PowerConsumption)
                .Build())
            .Build();

        CompatibilityResult vaildatorResult = new ComputerValidator().Validate(computer);

        Assert.Equal(CompatibilityStatus.HasIssue, vaildatorResult.Status);
    }

    [Fact]
    public void CoolerNoWarrantyTest()
    {
        Computer computer = new ComputerBuilder(_validComputer)
            .WithCooler(new CoolerBuilder(_validComputer.Cooler)
                .WithTdp(_validComputer.Cpu.Tdp - 1)
                .Build())
            .Build();

        CompatibilityResult vaildatorResult = new ComputerValidator().Validate(computer);

        Assert.Equal(CompatibilityStatus.NoWarranty, vaildatorResult.Status);
    }

    [Fact]
    public void MotherboardCpuIncompatibilityTest()
    {
        string cpuSocket = "L000L";
        Cpu cpu = new CpuBuilder(_validComputer.Cpu)
            .WithSocket(cpuSocket)
            .Build();

        ComponentsIncompatibilityException exception = Assert.Throws<ComponentsIncompatibilityException>(() =>
        {
            new ComputerBuilder(_validComputer)
                .WithCpu(cpu)
                .Build();
        });

        string expectedMessage =
            $"Motherboard CPU socket is {_validComputer.Motherboard.CpuSocket}, " +
            $"but given CPU with socket {cpuSocket}.";

        Assert.Equal(expectedMessage, exception.Message);
    }
}