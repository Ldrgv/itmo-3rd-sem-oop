using Core.Models.OperationResult;
using Core.Services.Account;
using Core.Services.Login;
using Spectre.Console;

namespace Console.Scenarios.LoginScenarios;

public class LoginAccountScenario : IScenario
{
    private AccountLoginService _accountLoginService;

    public LoginAccountScenario(AccountLoginService accountLoginService)
    {
        _accountLoginService = accountLoginService;
    }

    public string Name => "Account holder";

    public async Task Run()
    {
        int id = AnsiConsole.Ask<int>("Enter account ID:");
        string pin = AnsiConsole.Ask<string>("Enter PIN:");

        OperationResult result = await _accountLoginService.Login(id, pin);

        if (result is OperationResultSuccess<AccountService> operationResult)
        {
            while (true)
            {
                await new AccountScenario(operationResult.Result).Run();
            }
        }

        AnsiConsole.WriteLine(result.Message);
    }
}