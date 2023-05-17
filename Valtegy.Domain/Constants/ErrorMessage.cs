
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
        }
    }
}
