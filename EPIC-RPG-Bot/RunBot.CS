using BOT.Requests;
using System;
using System.Threading;

namespace BOT
{
    class RunBot
    {
        static void Main()
        {
            ENV.DebugMode = true;
            ENV.Host = "https://discord.com/api/v6/channels/708660683063033886/messages";
            Headers.Authorization = "MTExNTU0MTAyNzMwNzQ3OTA0.XuUIHQ.-TcMSpKsEgByx4bUNQUXwwErzE4";

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

        // TODO: Put Config In External File
        // TODO: Make Requests Modular and DRY
    }
}
