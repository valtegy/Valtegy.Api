using Valtegy.Domain.Models;
using Valtegy.Domain.ViewModels;

namespace Valtegy.Domain.Services
{
    public interface IUsersService
    {
        ResponseModel CreateUser(CreateUserViewModel user);
    }
}
