
namespace Valtegy.Domain.Constants
{
    public class ErrorMessage
    {
        public class Repository
        {
            public const string RecordNotFound = "Registro no encontrado.";
        }

        public class Authentication
        {
            public const string InvalidCredentials = "Usuario o contraseña no valida.";
            public const string CustomerNotFound = "No se encontró registro de cliente asociado.";
        }

        public class InputUser
        {
            public const string RequiredField = "Éste campo es requerido.";
            public const string MaxLength100PeopleName = "El nombre sobrepasa los 100 caracteres.";
            public const string MaxLength100PeopleLastName = "Los apellidos sobrepasan los 100 caracteres.";
            public const string DuplicateUserName = "El usuario '{0}' ya está elegido.";
            public const string MaxLength40UserName = "El usuario sobrepasa los 40 caracteres.";
            public const string MinLength8Password = "La contraseña debe ser minimo de 8 caracteres.";
            public const string MaxLength30Password = "La contraseña sobrepasa los 30 caracteres.";
            public const string PasswordRequired1Digit = "Requiere al menos un dígito.";
            public const string PasswordRequiredLower = "Requiere al menos una minuscula.";
            public const string PasswordRequiredUpper = "Requiere al menos una mayuscula.";
            public const string PasswordSpecialCharacter = "Requiere al menos un simbolo.";
        }
    }
}
