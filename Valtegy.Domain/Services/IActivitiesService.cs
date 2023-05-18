using System;
using System.Threading.Tasks;
using Valtegy.Domain.Models;
using Valtegy.Domain.ViewModels;

namespace Valtegy.Domain.Services
{
    public interface IActivitiesService
    {
        //Task<ResponseModel> CreateActivity(int userId, CreateActivityViewModel loan);
        Task<ResponseModel> CreateActivity(CreateActivityViewModel loan);
        ResponseModel GetActivity();
    }
}
