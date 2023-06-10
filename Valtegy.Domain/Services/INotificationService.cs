using Valtegy.Domain.Models;
using Valtegy.Domain.ViewModels;
using System;
using System.Threading.Tasks;

namespace Valtegy.Domain.Services
{
    public interface INotificationService
    {
        Task<ResponseModel> CreateNotification(Guid? userId, CreateNotificationViewModel notification);
    }
}
