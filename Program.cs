using System.Reflection;
using CommandLine;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using Directory = System.IO.Directory;

namespace geolocation_sharp;
using System;
static class Program
{
    private static Task Main(string[] args)
    {
        var arguments = Parser.Default.ParseArguments<CommandLineOptions>(args);
        if ((arguments.Value?.Path != null))
        {
            var files = Directory.GetFiles(arguments.Value.Path);
            if (files == Array.Empty<string>())
            {
                Console.WriteLine("Directory is empty");
                Environment.Exit(1);
            }
            foreach (var file in files)
            {
                if (file.Contains(".jpg"))
                {
                    var directories = ImageMetadataReader.ReadMetadata(Path.Combine(arguments.Value.Path, file));
                    var gpsMetadata = directories.OfType<GpsDirectory>().FirstOrDefault();
                    if (gpsMetadata != null)
                    {
                        var latitude = gpsMetadata.GetDescription(GpsDirectory.TagLatitude);
                        var longitude = gpsMetadata.GetDescription(GpsDirectory.TagLongitude);
                        Console.WriteLine($"{latitude}, {longitude}");
                    }
                    else
                    {
                        Console.WriteLine($"{file} is not a JPG");
                    }
                }
                else
                {
                    Console.WriteLine($"{file} is not a jpg");
                }
            }
            
        }
        else
        {
            Console.WriteLine("No path was provided");
        }

        return Task.CompletedTask;
    }
}

