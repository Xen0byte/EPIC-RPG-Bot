using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace BOT
{
    class Safety
    {
        public static void KeepOuttaJail()
        {
            var lastMessage = GetMessages(1)[0];

            if (ENV.DebugMode)
                Console.Write(Environment.NewLine + ObjectDumper.Dump(lastMessage));

            if (lastMessage.Content.Contains("EPIC GUARD"))
            {
                var answers = new List<string> { "NORMIE FISH", "WOLF SKIN", "LIFE POTION", "ZOMBIE EYE", "COIN" };
                var random = new Random();
                var randomAnswer = answers[random.Next(answers.Count)];

                // TODO: Create Classes With Image File Hashes & Get Rid Of This Ugly Code

                var JsonData = new { content = randomAnswer, nonce = Helpers.RandomIntAsString(), tts = false };

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

        public static Message[] GetMessages(int amount)
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
