using CommandLine;

namespace geolocation_sharp;

static class Program
{
    private static Task Main(string[] args)
    {
        var arguments = Parser.Default.ParseArguments<CommandLineOptions>(args);
        var path = arguments.Value?.Path ?? "Default";
        Console.WriteLine(path);
        return Task.CompletedTask;
    }
}

