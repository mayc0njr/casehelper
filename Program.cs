using System;

namespace casehelper
{
    class Program
    {

        public const string USE = "How to use: casehelper [option] words";
        public const string UNKNOWN = USE + "\nUse \"casehelper --help\" for use options.";
        public const string HELP = "Makes a conversion between cases: camelCase, CamelCase, snake_case, SNAKE_CASE\n\n"
                                    + USE
                                    + "\nAvailable options:"
                                    + "\n\t-c, --camel\t\tConvert case to camelCase."
                                    + "\n\t-C, --Camel\t\tConvert case to CamelCase (or PascalCase)."
                                    + "\n\t-s, --snake\t\tConvert case to snake_case. (default option)."
                                    + "\n\t-S, --Snake\t\tConvert case to SNAKE_CASE. (or MACRO_CASE)."
                                    + "\n\t-h, --help\t\tShow help and exit.";

        static void Main(string[] args)
        {
            //No arguments, show help
            if(args.Length == 0){
                Console.WriteLine(UNKNOWN);
                return;
            }
            //No option select, run default snake_case
            if (!args[0].StartsWith("-"))
            {
                foreach (var item in args)
                {
                    Console.WriteLine(item.ToSnakeCase().StartLower());
                }
                return;
            }
            //Parse the option.
            switch (args[0])
            {
                case "-c":
                    goto case "--camel";
                case "--camel":
                    for (var x = 1; x < args.Length; x++)
                    {
                        Console.WriteLine(args[x].ToCamelCase().StartLower());
                    }
                    break;
                case "-p":
                    goto case "--pascal";
                case "--pascal":
                    for (var x = 1; x < args.Length; x++)
                    {
                        Console.WriteLine(args[x].ToCamelCase().StartUpper());
                    }
                    break;
                case "-s":
                    goto case "--snake";
                case "--snake":
                    for (var x = 1; x < args.Length; x++)
                    {
                        Console.WriteLine(args[x].ToSnakeCase().StartLower());
                    }
                    break;
                case "-S":
                    goto case "--Snake";
                case "--Snake":
                    for (var x = 1; x < args.Length; x++)
                    {
                        Console.WriteLine(args[x].ToSnakeCase().ToUpper());
                    }
                    break;
                case "-h":
                    goto case "--help";
                case "--help":
                    Console.WriteLine(HELP);
                    break;
                default:
                    Console.WriteLine($"Unknown Option ({args[0]}).\n{UNKNOWN}");
                    break;
            }
        }
    }
}