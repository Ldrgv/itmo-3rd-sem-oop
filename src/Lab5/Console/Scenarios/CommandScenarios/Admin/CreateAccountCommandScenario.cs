using Core.Services.Admin;
using Spectre.Console;

namespace Console.Scenarios.CommandScenarios.Admin;

public class CreateAccountCommandScenario : IScenario
{
    private IAdminService _adminService;

    public CreateAccountCommandScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Create command";

    public async Task Run()
    {
        int id = AnsiConsole.Ask<int>("Enter account id");
        string pin = AnsiConsole.Ask<string>("Enter pin");

        await _adminService.CreateAccount(id, pin);
    }
}