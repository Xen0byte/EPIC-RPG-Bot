using System.Diagnostics;

namespace BOT
{
    internal static class Environment
    {
        internal static bool DebugMode { get; set; }
        internal static string Host { get; set; }
        internal static int RuntimeInHours { get; set; }
    }

    internal static class Headers
    {
        internal static string Authorization { get; set; }
    }

    internal static class Utility
    {
        internal static Stopwatch Runtime = new Stopwatch();
        internal static int CooldownBuffer = 10;
    }
}
