using Console.Scenarios.CommandScenarios.Admin;
using Core.Services.Admin;

namespace Console.Scenarios;

public class AdminScenario : ScenariosRunnerBase
{
    public AdminScenario(IAdminService adminService)
        : base("Choose command", new List<IScenario>
        {
            new CreateAccountCommandScenario(adminService),
        })
    {
    }
}