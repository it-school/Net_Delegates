namespace Net_Delegates
{
    internal class Utils
    {
        public enum ESex { Male, Female };

        private static Random _random = new();
        private static string[] _names = {
                "Yuliy",
                "Martin",
                "Kuzma",
                "Abram",
                "Sofya",
                "Vasiliy",
                "Vitaly",
                "Konstantin",
                "Leonid",
                "Mikhail",
                "Leonty",
                "Venera",
                "Sergej",
                "Yesfir",
                "Larisa",
                "Innokenti",
                "Evgeniya",
                "Emil",
                "Evgeni",
                "Saveli",
        };

        public static string getRandomName()
        {
            return _names[_random.Next(_names.Length)];
        }
    }
}
