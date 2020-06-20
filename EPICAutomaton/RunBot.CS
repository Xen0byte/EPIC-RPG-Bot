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
            ENV.Host = "https://discord.com/api/v6/channels/708660683063033886/messages";
            Headers.Authorization = "MTExNTU0MTAyNzMwNzQ3OTA0.Xu6b-w.u20QrOEUglH3STXmF4OaJOa79qI";

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
