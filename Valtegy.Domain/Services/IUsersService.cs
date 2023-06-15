using System.Threading.Tasks;
using Valtegy.Domain.Models;
using Valtegy.Domain.ViewModels;

namespace Valtegy.Domain.Services
{
    public interface IUsersService
    {
        Task<ResponseModel> CreateUser(CreateUserViewModel user);
        Task<ResponseModel> RequestValidateEmailCode(RequestValidateEmailCodeViewModel data);
        bool ExistsUserName(string userName);
        ResponseModel ValidateEmailCode(RequestValidateEmailCodeViewModel data);
        ResponseModel DeleteUser(int id);
    }
}
