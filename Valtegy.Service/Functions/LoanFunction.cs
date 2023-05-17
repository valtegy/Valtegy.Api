
namespace Valtegy.Service.Functions
{
    public static class LoanFunction
    {
        public static string GenerateCode(int idNumber)
        {
            return idNumber.ToString().PadLeft(3, '0');
        }
    }
}
