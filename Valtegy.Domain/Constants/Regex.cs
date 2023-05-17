
namespace Valtegy.Domain.Constants
{
    public class Regex
    {
        public const string Gender = "[FMOfmo]{1}";
        public const string TenDigits = @"^\d{10}$";
        public const string PasswordRequired1Digit = @".*\d.*";
        public const string PasswordRequiredLower = ".*[a-z].*";
        public const string PasswordRequiredUpper = ".*[A-Z].*";
        public const string PasswordSpecialCharacter = ".*[$&+,:;=?@#|'<>.^*()%!-].*";
    }
}
