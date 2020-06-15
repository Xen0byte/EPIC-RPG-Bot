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
            Console.WriteLine(System.Environment.NewLine);
            Console.WriteLine(content);
            Console.WriteLine(System.Environment.NewLine);
        }
    }
}
