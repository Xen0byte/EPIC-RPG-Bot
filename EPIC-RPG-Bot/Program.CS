using EPIC_RPG_Bot.Requests;

namespace EPIC_RPG_Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.SetHost("708660683063033886");
            PersistentHeaders.SetAuthorization("MTExNTU0MTAyNzMwNzQ3OTA0.XsUElA.4Iv7bWqwsxF0kI_yA1X5XovSat8");
            Environment.Iterations = 500;

            for (int i = 0; i < Environment.Iterations; i++)
            {
                new RpgAxe(Cooldowns.RpgAxeLastCallTime);
            }
        }
    }
}
