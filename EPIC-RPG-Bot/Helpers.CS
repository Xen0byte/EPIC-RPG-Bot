using System;
using System.Text;

namespace BOT
{
    public static class Helpers
    {
        public static string RandomIntAsString()
        {
            Random random = new Random();
            return random.Next(int.MaxValue).ToString();
        }

        public static void PrintRuntimeStats()
        {
            Console.WriteLine(new StringBuilder()
                .Append($"{DateTime.Now} :: {Utility.Runtime.Elapsed} Elapsed")
                .Append(" & ")
                .Append($"{TimeSpan.FromHours(Environment.RuntimeInHours) - Utility.Runtime.Elapsed} Remaining")
                .ToString());
        }

        public static void PrintDashes(int amount)
        {
            for (int i = 0; i < amount; i++)
                Console.Write("-");

            Console.WriteLine();
        }

        public static void PrintEnclosedInNewLines(string content)
        {
            Console.Write(System.Environment.NewLine);
            Console.Write(content);
            Console.Write(System.Environment.NewLine);
        }

        // needed because ObjectDumper.NET adds an unnecessary new line at the end of the dump
        public static void PrintWithoutTrailingNewLines(string content)
        {
            Console.WriteLine(content.Remove(content.TrimEnd().LastIndexOf(System.Environment.NewLine)));
        }
    }
}
