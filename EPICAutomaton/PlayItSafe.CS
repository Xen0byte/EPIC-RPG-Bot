using RestSharp;
using System;
using System.Threading;

namespace BOT
{
    public static class PlayItSafe
    {
        public static void KeepOuttaJail()
        {
            var lastMessage = Helpers.GetMessages(1)[0];

            if (ENV.DebugMode)
                Console.Write(Environment.NewLine + ObjectDumper.Dump(lastMessage));

            if (lastMessage.Content.Contains("EPIC GUARD"))
            {
                var prediction = MachineLearning.PredictItemFromUri(lastMessage.Attachments[0].URL);

                var JsonData = new { content = prediction, nonce = Helpers.RandomIntAsString(), tts = false };

                var client = new RestClient(ENV.Host);

                var request = new RestRequest(Method.POST)
                    .AddHeader("Accept", "application/json")
                    .AddHeader("Authorization", Headers.Authorization)
                    .AddJsonBody(JsonData);

                Console.WriteLine(Environment.NewLine + $"{DateTime.Now} :: EPIC GUARD Start");

                var response = client.Execute(request);

                Console.WriteLine($"{DateTime.Now} :: EPIC GUARD {response.ResponseStatus}");

                if (ENV.DebugMode)
                    Console.WriteLine(Environment.NewLine + response.Content);

                if (!Helpers.GetMessages(1)[0].Content.ToUpper().Contains("EVERYTHING SEEMS FINE"))
                {
                    Helpers.PlayAlert();
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }
            }
        }
    }
}
