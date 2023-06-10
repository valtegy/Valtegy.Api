using System;

namespace Valtegy.Service.Functions
{
    public static class GenerateValidationCode
    {
        public static string GenerateCode()
        {
            Random rnd = new Random();

            string c1 = rnd.Next(1, 99).ToString().PadLeft(2, '0');
            string c2 = rnd.Next(1, 99).ToString().PadLeft(2, '0');
            string c3 = rnd.Next(1, 99).ToString().PadLeft(2, '0');

            string code = $"{c1}{c2}{c3}";
            return code;
        }
    }
}
