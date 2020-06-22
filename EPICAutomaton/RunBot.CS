using BOT.Requests;
using System;
using System.Threading;

namespace BOT
{
    public class RunBot
    {
        public static void Main()
        {
            ENV.DebugMode = true;

            Console.Write("HOST: ");
            ENV.Host = "https://discord.com/api/v6/channels/" + Console.ReadLine() + "/messages";

            Console.Write("AUTH: ");
            Headers.Authorization = Console.ReadLine();

            Helpers.PrintDashes(100);

            ENV.RuntimeInHours = 12;

            Utility.Runtime.Start();

            while (Utility.Runtime.Elapsed < TimeSpan.FromHours(ENV.RuntimeInHours))
            {
                RPGWork.MakeRequest("RPG LADDER");
                Thread.Sleep(1000);
                RPGHunt.MakeRequest();
                Thread.Sleep(1000);
            }

            Utility.Runtime.Stop();
        }

        // TODO: Make Requests Modular and DRY
    }
}
