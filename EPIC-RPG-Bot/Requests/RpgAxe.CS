using Flurl.Http;
using System;
using System.Threading.Tasks;
using System.Text;

namespace EPIC_RPG_Bot.Requests
{
    internal static class RPGAxe
    {
        private static readonly string Command = "rpg axe";
        private static readonly int CooldownInSeconds = 305;

        private static dynamic Response;
        private static DateTime ThisCallTime;
        private static DateTime LastCallTime;
        private static int SecondsElapsed;

        internal static async void MakeRequest()
        {
            string JsonData = new StringBuilder()
                .Append("{ ").Append($"'content': '{Command}', ")
                .Append($"'nonce': '{Helpers.RandomIntAsString()}', ")
                .Append("'tts': false").Append(" }").ToString();

            if (LastCallTime != DateTime.MinValue)
                SecondsElapsed = Convert.ToInt32((DateTime.Now - LastCallTime).TotalSeconds);

            if ((SecondsElapsed > CooldownInSeconds) || (LastCallTime == DateTime.MinValue))
            {
                Response = await Environment.Host.
                    WithHeader("Authorization", Headers.Authorization).
                    PostJsonAsync(JsonData).
                    ReceiveJson();
            }

            if (Response != null)
            {
                ThisCallTime = DateTime.Now;
                LastCallTime = DateTime.Now;
                SecondsElapsed = 0;

                Console.WriteLine(Response.ToString() + System.Environment.NewLine);
                Response = null;
            }

            if (SecondsElapsed < CooldownInSeconds)
                await Task.Delay((CooldownInSeconds - SecondsElapsed) * 1000);
        }
    }
}
