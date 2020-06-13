using BOT.Requests;
using System;
using System.Diagnostics;

namespace BOT
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.Host = "https://discord.com/api/v6/channels/708660683063033886/messages";
            Headers.Authorization = "MTExNTU0MTAyNzMwNzQ3OTA0.XuUIHQ.-TcMSpKsEgByx4bUNQUXwwErzE4";

            Environment.RuntimeInHours = 12;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (stopwatch.Elapsed < TimeSpan.FromHours(Environment.RuntimeInHours))
            {
                Console.WriteLine($"{stopwatch.Elapsed} Elapsed :: {TimeSpan.FromHours(Environment.RuntimeInHours) - stopwatch.Elapsed} Remaining");
                RPGAxe.MakeRequest();
            }

            stopwatch.Stop();
        }
    }
}
