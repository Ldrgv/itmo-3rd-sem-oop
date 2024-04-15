using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Common;

public class Config : IConfiguration
{
    private IConfiguration _configuration;

    public Config()
    {
        _configuration = new ConfigurationBuilder()
            .AddJsonFile("./configs/adminPassword.json", false, true)
            .Build();
    }

    public string? this[string key]
    {
        get => _configuration[key];
        set => throw new NotImplementedException();
    }

    public IConfigurationSection GetSection(string key)
    {
        return _configuration.GetSection(key);
    }

    public IEnumerable<IConfigurationSection> GetChildren()
    {
        return _configuration.GetChildren();
    }

    public IChangeToken GetReloadToken()
    {
        return _configuration.GetReloadToken();
    }
}