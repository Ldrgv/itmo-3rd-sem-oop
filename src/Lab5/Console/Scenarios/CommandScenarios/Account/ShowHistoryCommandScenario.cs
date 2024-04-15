using Core.Models;
using Core.Models.OperationResult;
using Core.Services.Account;
using Spectre.Console;

namespace Console.Scenarios.CommandScenarios.Account;

public class ShowHistoryCommandScenario : IScenario
{
    private IAccountService _accountService;

    public ShowHistoryCommandScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Operations history";

    public async Task Run()
    {
        OperationResult result = await _accountService.GetAccountOperationHistory();

        if (result is OperationResultSuccess<IEnumerable<Operation>> resultSuccess)
        {
            foreach (Operation operation in resultSuccess.Result)
            {
                AnsiConsole.WriteLine($"{operation.Time} {operation.OperationType} {operation.Amount}");
            }
        }
        else
        {
            AnsiConsole.WriteLine(result.Message);
        }
    }
}