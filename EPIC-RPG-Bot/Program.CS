using EPIC_RPG_Bot.Requests;

namespace EPIC_RPG_Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.SetHost("708660683063033886");
            PersistentHeaders.SetAuthorization("MTExNTU0MTAyNzMwNzQ3OTA0.XuUIHQ.-TcMSpKsEgByx4bUNQUXwwErzE4");
            Environment.Iterations = 500;

            for (int i = 0; i < Environment.Iterations; i++)
            {
                RpgAxe.MakeRequest();
            }
        }
    }
}
