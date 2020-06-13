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

            int secondsElapsed = 0;

            if (lastCall != DateTime.MinValue)
            {
                TimeSpan timeSpan = DateTime.Now - lastCall;
                secondsElapsed = Convert.ToInt32(timeSpan.TotalSeconds);
            }

            if ((secondsElapsed > cooldownInSeconds) || (lastCall != DateTime.MinValue))
                RpgAxeLastCallTime = DateTime.Now;
            else
            {
                int timeRemainingInMillisecond = (cooldownInSeconds - secondsElapsed) * 1000;
                await Task.Delay(timeRemainingInMillisecond);
            }
        }
    }
}
