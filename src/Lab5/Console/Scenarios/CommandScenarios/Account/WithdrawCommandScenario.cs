using Core.Models.OperationResult;
using Core.Services.Account;
using Spectre.Console;

namespace Console.Scenarios.CommandScenarios.Account;

public class WithdrawCommandScenario : IScenario
{
    private IAccountService _accountService;

    public WithdrawCommandScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Withdraw";

    public async Task Run()
    {
        int amount = AnsiConsole.Ask<int>("Enter amount");
        OperationResult result = await _accountService.Withdraw(amount);

        AnsiConsole.WriteLine(result.Status is OperationResultStatus.Success
            ? "Success!"
            : result.Message);
    }
}