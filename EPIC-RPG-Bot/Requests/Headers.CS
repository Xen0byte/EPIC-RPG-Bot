namespace EPIC_RPG_Bot.Requests
{
    internal static class PersistentHeaders
    {
        private static string Authorization { get; set; }

        internal static void SetAuthorization(string authorization)
        {
            Authorization = authorization;
        }

        internal static string GetAuthorization()
        {
            return Authorization;
        }
    }
}
