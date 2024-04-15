using Core.Models.OperationResult;
using Core.Services.Account;
using Spectre.Console;

namespace Console.Scenarios.CommandScenarios.Account;

public class TopUpCommandScenario : IScenario
{
    private IAccountService _accountService;

    public TopUpCommandScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Top up";

    public async Task Run()
    {
        int amount = AnsiConsole.Ask<int>("Enter amount");
        OperationResult result = await _accountService.TopUp(amount);

        AnsiConsole.WriteLine(result.Status is OperationResultStatus.Success
            ? "Success!"
            : result.Message);
    }
}