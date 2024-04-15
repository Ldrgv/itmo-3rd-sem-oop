using Microsoft.Extensions.Configuration;

namespace Itmo.ObjectOrientedProgramming.Lab4.App.OutputFormatting;

public static class ConfigLoader
{
    public static OutputFormatInfo LoadOutputFormatInfo()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("./App/OutputFormatting/outputFormatConfig.json", false, true)
            .Build();

        return new OutputFormatInfo(
            configuration["Tab"],
            configuration["File"],
            configuration["Directory"]);
    }
}