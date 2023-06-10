using System.Collections.Generic;

namespace Valtegy.Domain.Constants
{
    public static class NotificationStatus
    {
        public const int Pending = 0;
        public const int Sent = 1;
        public const int Failed = 2;

        public static List<KeyValuePair<int, string>> GetAll()
        {
            return new List<KeyValuePair<int, string>>()
                        {
                            new KeyValuePair<int, string>(Pending, "Pendiente"),
                            new KeyValuePair<int, string>(Sent, "Enviada"),
                            new KeyValuePair<int, string>(Failed, "Fallado")
                        };
        }
    }
}
