using static EPIC_RPG_Bot.Cooldowns;
using System;
using System.Threading.Tasks;

namespace EPIC_RPG_Bot.Requests
{
    internal class RpgAxe : BaseRequest
    {
        internal RpgAxe(DateTime lastCall, string command = "rpg axe", int cooldownInSeconds = 305) : base(lastCall, command, cooldownInSeconds) { }

        internal override async void Call(DateTime lastCall, int cooldownInSeconds)
        {
            base.Call(lastCall, cooldownInSeconds);

            TimeSpan timeSpan = DateTime.Now - lastCall;
            int secondsElapsed = Convert.ToInt32(timeSpan.TotalSeconds);

            if (secondsElapsed > cooldownInSeconds)
                RpgAxeLastCallTime = DateTime.Now;
            else
            {
                int timeRemainingInMillisecond = (cooldownInSeconds - secondsElapsed) * 1000;
                await Task.Delay(timeRemainingInMillisecond);
            }
        }
    }
}
