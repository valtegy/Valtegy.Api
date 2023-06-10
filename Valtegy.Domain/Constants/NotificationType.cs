using System.Collections.Generic;

namespace Valtegy.Domain.Constants
{
    public static class NotificationType
    {
        public const int Email = 0;
        public const int Sms = 1;
        public const int PushWeb = 2;
        public const int PushApp = 3;
        public const int WhatsApp = 4;
        public const int FacebookMessenger = 5;

        public static List<KeyValuePair<int, string>> GetAll()
        {
            return new List<KeyValuePair<int, string>> ()
            {
                new KeyValuePair<int, string>(Email, "Email"),
                new KeyValuePair<int, string>(Sms, "SMS"),
                new KeyValuePair<int, string>(PushWeb, "PushWeb"),
                new KeyValuePair<int, string>(PushApp, "PushApp"),
                new KeyValuePair<int, string>(WhatsApp, "WhatsApp"),
                new KeyValuePair<int, string>(FacebookMessenger, "Facebook Messenger")
            };
        }
    }
}
