using Console.Scenarios.CommandScenarios.Account;
using Core.Services.Account;

namespace Console.Scenarios;

public class AccountScenario : ScenariosRunnerBase
{
    public AccountScenario(IAccountService accountService)
        : base("Choose command", new List<IScenario>
        {
            new TopUpCommandScenario(accountService),
            new WithdrawCommandScenario(accountService),
            new ShowBalanceCommandScenario(accountService),
            new ShowHistoryCommandScenario(accountService),
        })
    {
    }
}