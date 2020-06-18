using Newtonsoft.Json;
using RestSharp;
using System;
using System.Drawing;

namespace BOT
{
    public static class PlayItSafe
    {
        public static void KeepOuttaJail()
        {
            var lastMessage = GetMessages(1)[0];

            if (ENV.DebugMode)
                Console.Write(Environment.NewLine + ObjectDumper.Dump(lastMessage));

            if (lastMessage.Content.Contains("EPIC GUARD"))
            {
                Item match = null;

                foreach (Item item in Dataset.ItemDataset)
                {
                    var checker = new ImageRecognition();
                    var point = checker.Find(new Bitmap("???"), item.Bitmap);

                    if (point != null) match = item;
                }

                if (match == null)
                {
                    Helpers.PlayAlert();
                    Environment.Exit(0);
                } 

                else
                {
                    var JsonData = new { content = match.Name, nonce = Helpers.RandomIntAsString(), tts = false };

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
                }
            }
        }

        private static Message[] GetMessages(int amount)
        {
            var client = new RestClient(ENV.Host);

            var request = new RestRequest(Method.GET)
                .AddParameter("limit", amount)
                .AddHeader("Accept", "application/json")
                .AddHeader("Authorization", Headers.Authorization);

            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<Message[]>(response.Content);
        }
    }
}
