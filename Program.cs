namespace geolocation_sharp;

static class Program
{
    static void Main(string[] args)
    {
        foreach (string arg in args)
        {
            switch(arg)
            {
                case not null when arg.Contains("-f"):
                    Console.WriteLine("ARG had a -f flag");
                    break;
                case not null when arg.Contains("-a"):
                    Console.WriteLine("ARG had a -a flag");
                    break;
            }
        }
    }
}

