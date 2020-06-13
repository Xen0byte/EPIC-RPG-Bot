using Flurl;
using System;

namespace EPIC_RPG_Bot
{
    internal static class Environment
    {
        private static string Host { get; set; }

        public static int Iterations { get; set; }

        internal static void SetHost(string discordChannelId)
        {
            Host = Url.Combine("https://discord.com/api/v6/channels/", discordChannelId, "/messages");
        }

        internal static string GetHost()
        {
            return Host;
        }
    }

    internal static class Cooldowns
    {
        internal static DateTime RpgAxeLastCallTime;
    }
}
