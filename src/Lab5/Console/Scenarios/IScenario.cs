namespace Console.Scenarios;

public interface IScenario
{
    public string Name { get; }
    public Task Run();
}