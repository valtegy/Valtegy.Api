using System.Collections.Generic;

namespace Valtegy.Domain.Constants
{
    public static class LoanStatus
    {
        public const int Activo = 0;

        public static List<KeyValuePair<string, int>> GetAll()
        {
            return new List<KeyValuePair<string, int>>()
                        {
                            new KeyValuePair<string, int>("Activo", Activo)
                        };
        }
    }
}
