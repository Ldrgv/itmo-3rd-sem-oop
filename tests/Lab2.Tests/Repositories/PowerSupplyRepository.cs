using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Repositories;

public class PowerSupplyRepository : RepositoryBase<PowerSupply>
{
    public PowerSupplyRepository()
    {
        Add(new PowerSupply("DEEPCOOL PF600", 600));
        Add(new PowerSupply("DEEPCOOL PF700", 700));
    }
}