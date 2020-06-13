using RestSharp;
using System;
using System.Threading.Tasks;

namespace BOT.Requests
{
    internal static class RPGAxe
    {
        private static readonly string Command = "rpg axe";
        private static readonly int CooldownInSeconds = 305;

        private static IRestResponse Response;
        private static DateTime LastCallTime;
        private static int SecondsElapsed;

        internal static async void MakeRequest()
        {
            // resets response from previous call, if any
            if (Response != null) Response = null;

            // create POST data
            var JsonData = new { content = Command, nonce = Helpers.RandomIntAsString(), tts = false };

            // if the call has been made in a previous iteration, then establish how many seconds have passed since
            if (LastCallTime != DateTime.MinValue)
                SecondsElapsed = Convert.ToInt32((DateTime.Now - LastCallTime).TotalSeconds);

            //  if the cooldown has reset or if this is the first iteration, make the API call
            if ((SecondsElapsed > CooldownInSeconds) || (LastCallTime == DateTime.MinValue))
            {
                var client = new RestClient(Environment.Host);

                var request = new RestRequest(Method.POST)
                    .AddHeader("Accept", "application/json")
                    .AddHeader("Authorization", Headers.Authorization)
                    .AddJsonBody(JsonData);

                Response = client.Execute(request);

                LastCallTime = DateTime.Now;
                SecondsElapsed = 0;

                Console.WriteLine($"{Utility.Runtime.Elapsed} Elapsed :: {TimeSpan.FromHours(Environment.RuntimeInHours) - Utility.Runtime.Elapsed} Remaining");
                Console.WriteLine(Response.Content + System.Environment.NewLine);
            }

            // if the cooldown has not finished resetting, wait for the remainder of the time
            if (SecondsElapsed < CooldownInSeconds)
                await Task.Delay((CooldownInSeconds - SecondsElapsed) * 1000);
        }
    }
}
