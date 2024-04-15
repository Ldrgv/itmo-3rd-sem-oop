namespace Console.Scenarios.LoginScenarios;

public class LoginScenario : ScenariosRunnerBase
{
    public LoginScenario(IEnumerable<IScenario> scenarios)
        : base("Choose login mode", scenarios)
    {
    }
}