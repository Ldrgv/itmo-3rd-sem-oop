using Spectre.Console;

namespace Console.Scenarios;

public abstract class ScenariosRunnerBase : IScenario
{
    private IEnumerable<IScenario> _scenarios;

    protected ScenariosRunnerBase(string name, IEnumerable<IScenario> scenarios)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        _scenarios = scenarios ?? throw new ArgumentNullException(nameof(scenarios));
    }

    public string Name { get; }

    public async Task Run()
    {
        IScenario specificLoginScenario = AnsiConsole.Prompt(
            new SelectionPrompt<IScenario>()
                .Title(Name)
                .PageSize(10)
                .AddChoices(_scenarios)
                .UseConverter(scenario => scenario.Name));

        await specificLoginScenario.Run();
    }
}