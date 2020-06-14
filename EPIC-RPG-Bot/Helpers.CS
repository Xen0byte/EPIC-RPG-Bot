using RestSharp;
using System;
using System.Text;
using System.Text.Json;

namespace BOT
{
    internal static class Helpers
    {
        internal static string RandomIntAsString()
        {
            Random random = new Random();
            return random.Next(int.MaxValue).ToString();
        }

        internal static void PrintRuntimeStats()
        {
            Console.WriteLine(new StringBuilder()
                .Append($"{Utility.Runtime.Elapsed} Elapsed :: ")
                .Append($"{TimeSpan.FromHours(Environment.RuntimeInHours) - Utility.Runtime.Elapsed} Remaining")
                .ToString());
        }

        internal static void PrintDashes(int amount)
        {
            for (int i = 0; i < amount; i++)
                Console.Write("-");

            Console.WriteLine();
        }

        internal static void KeepOuttaJail()
        {
            var message = GetLatestMessage();
            Console.WriteLine(message);
        }

        internal static Message GetLatestMessage()
        {
            var client = new RestClient(Environment.Host);

            var request = new RestRequest(Method.GET)
                .AddParameter("limit", "1")
                .AddHeader("Accept", "application/json")
                .AddHeader("Authorization", Headers.Authorization);

            var response = client.Execute(request);
            return JsonSerializer.Deserialize<Message>(response.Content);
        }
    }
}

/*
    {
        "id": "721493781190410301",
        "type": 0,
        "content": ":police_car: **EPIC GUARD**: stop there, <@111554102730747904>\nWe have to check you are actually playing",
        "channel_id": "708660683063033886",
        "author": {
            "id": "555955826880413696",
            "username": "EPIC RPG",
            "avatar": "2a984946a5bfe892da8309b69f0a4aec",
            "discriminator": "4117",
            "public_flags": 65536,
            "bot": true
        },
        "attachments": [
            {
                "id": "721493781396062288",
                "filename": "epic_guard.png",
                "size": 7560,
                "url": "https://cdn.discordapp.com/attachments/708660683063033886/721493781396062288/epic_guard.png",
                "proxy_url": "https://media.discordapp.net/attachments/708660683063033886/721493781396062288/epic_guard.png",
                "width": 695,
                "height": 85
            }
        ],
        "embeds": [],
        "mentions": [
            {
                "id": "111554102730747904",
                "username": "GOPO™",
                "avatar": "739fbae025450f3c99610f570bce3d93",
                "discriminator": "2651",
                "public_flags": 0
            }
        ],
        "mention_roles": [],
        "pinned": false,
        "mention_everyone": false,
        "tts": false,
        "timestamp": "2020-06-13T22:38:42.142000+00:00",
        "edited_timestamp": null,
        "flags": 0
    }
*/
