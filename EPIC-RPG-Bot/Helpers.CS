using System;

namespace BOT
{
    internal static class Helpers
    {
        internal static string RandomIntAsString()
        {
            Random random = new Random();
            return random.Next(int.MaxValue).ToString();
        }
    }
}
