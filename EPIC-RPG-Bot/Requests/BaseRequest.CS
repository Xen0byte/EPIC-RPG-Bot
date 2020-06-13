using Flurl.Http;
using Newtonsoft.Json.Linq;
using System;

namespace EPIC_RPG_Bot.Requests
{
    internal class BaseRequest
    {
        private string Command { get; set; }
        private string Nonce { get; set; }
        private JObject JsonData { get; set; }
        private DateTime ThisCallTime { get; set; }
        private dynamic Response { get; set; }

        public BaseRequest(DateTime lastCall, string command, int cooldownInSeconds)
        {
            SetCommand(command);
            SetNonce();
            SetJsonData();
            SetThisCallTime();
            Call(lastCall, cooldownInSeconds);
        }

        internal virtual async void Call(DateTime lastCall, int cooldownInSeconds)
        {
            TimeSpan timeSpan = DateTime.Now - lastCall;
            int secondsElapsed = Convert.ToInt32(timeSpan.TotalSeconds);

            if (secondsElapsed > cooldownInSeconds)
            {
                Response = await Environment.GetHost().
                    WithHeader("Authorization", PersistentHeaders.GetAuthorization()).
                    PostJsonAsync(GetJsonData()).
                    ReceiveJson();

                Console.WriteLine(Response.ToString() + System.Environment.NewLine);
            }
        }

        private void SetCommand(string command)
        {
            Command = command;
        }

        private string GetCommand()
        {
            return Command;
        }

        private void SetNonce()
        {
            Random random = new Random();
            Nonce = random.Next(int.MaxValue).ToString();
        }

        private string GetNonce()
        {
            return Nonce;
        }

        private void SetJsonData()
        {
            JsonData = JObject.Parse($"{{ 'content': '{GetCommand()}', 'nonce': '{GetNonce()}', 'tts': 'false' }}");
        }

        private JObject GetJsonData()
        {
            return JsonData;
        }

        private void SetThisCallTime()
        {
            ThisCallTime = DateTime.Now;
        }
    }
}
