using System.Globalization;
using Core.Models.OperationResult;
using Core.Services.Account;
using Spectre.Console;

namespace Console.Scenarios.CommandScenarios.Account;

public class ShowBalanceCommandScenario : IScenario
{
    private IAccountService _accountService;

    public ShowBalanceCommandScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Balance";

    public async Task Run()
    {
        OperationResult result = await _accountService.GetAccountBalance();

        if (result is OperationResultSuccess<int> resultSuccess)
        {
            AnsiConsole.WriteLine(CultureInfo.InvariantCulture, resultSuccess.Result);
        }
        else
        {
            AnsiConsole.WriteLine(result.Message);
        }
    }
}