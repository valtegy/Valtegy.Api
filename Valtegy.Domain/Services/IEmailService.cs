using Valtegy.Domain.Models;

namespace Valtegy.Domain.Services
{
    public interface IEmailService
    {
        ResponseModel Send(string to, string subject, string body, bool isBodyHtml = false, string cc = "", string cco = "");
    }
}
