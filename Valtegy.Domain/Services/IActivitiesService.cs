using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Valtegy.Domain.Models;
using Valtegy.Domain.ViewModels;

namespace Valtegy.Domain.Services
{
    public interface IActivitiesService
    {
        Task<ResponseModel> CreateActivity(Guid userId, CreateActivityViewModel createActivityViewModel);

        ResponseModel GetActivities(Guid userId);

        ResponseModel GetActivitiesTypeList();

        ResponseModel GetStatusActivitiesList();

        Task<ResponseModel> DeleteActivities(Guid userId, List<Guid> request);

        Task<ResponseModel> UpdateActivity(Guid userId, CreateActivityViewModel createActivityViewModel);
    }
}
