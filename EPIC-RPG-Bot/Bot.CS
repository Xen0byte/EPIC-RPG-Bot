using BOT.Requests;
using System;

namespace BOT
{
    class Bot
    {
        static void Main()
        {
            Environment.Host = "https://discord.com/api/v6/channels/708660683063033886/messages";
            Headers.Authorization = "MTExNTU0MTAyNzMwNzQ3OTA0.XuUIHQ.-TcMSpKsEgByx4bUNQUXwwErzE4";

            Environment.RuntimeInHours = 12;

            Utility.Runtime.Start();

            while (Utility.Runtime.Elapsed < TimeSpan.FromHours(Environment.RuntimeInHours))
            {
                
                RPGAxe.MakeRequest();
            }

            Utility.Runtime.Stop();
        }

        // TODO: Put Config In External File
        // TODO: Stop Going To Jail
    }
}
