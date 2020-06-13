using BOT.Requests;
using System;

namespace BOT
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.Host = "https://discord.com/api/v6/channels/708660683063033886/messages";
            Headers.Authorization = "MTExNTU0MTAyNzMwNzQ3OTA0.XuUIHQ.-TcMSpKsEgByx4bUNQUXwwErzE4";
            Environment.Iterations = 500;

            for (int i = 0; i < Environment.Iterations; i++)
            {
                Console.WriteLine($"Iteration: {i + 1}");
                RPGAxe.MakeRequest();
            }
        }
    }
}
