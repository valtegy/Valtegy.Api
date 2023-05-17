using Valtegy.Domain.Models;
using Valtegy.Domain.ViewModels;

namespace Valtegy.Domain.Services
{
    public interface IAuthenticateService
    {
        ResponseModel Login(LoginViewModel login);
    }
}
