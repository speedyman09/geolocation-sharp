using CommandLine;

namespace geolocation_sharp;

public class CommandLineOptions
{
    [Value(index:0, Required = true, HelpText = "Directory of photos")]
    public string? Path { get; set; }
}