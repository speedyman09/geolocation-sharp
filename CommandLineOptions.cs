using CommandLine;

namespace geolocation_sharp;

public class CommandLineOptions
{
    [Option('p', "path", Required = true, HelpText = "Directory of photos")]
    public string? Path { get; set; }
}