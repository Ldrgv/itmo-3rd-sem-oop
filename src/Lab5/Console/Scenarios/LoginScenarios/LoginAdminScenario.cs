using Core.Models.OperationResult;
using Core.Services.Admin;
using Core.Services.Login;
using Spectre.Console;

namespace Console.Scenarios.LoginScenarios;

public class LoginAdminScenario : IScenario
{
    private AdminLoginService _adminLoginService;

    public LoginAdminScenario(AdminLoginService adminLoginService)
    {
        _adminLoginService = adminLoginService;
    }

    public string Name => "Admin";

    public async Task Run()
    {
        string password = AnsiConsole.Ask<string>("Enter password:");

        OperationResult result = await _adminLoginService.Login(password);

        if (result is OperationResultSuccess<AdminService> operationResult)
        {
            await new AdminScenario(operationResult.Result).Run();

            return;
        }

        AnsiConsole.WriteLine(result.Message);
    }
}