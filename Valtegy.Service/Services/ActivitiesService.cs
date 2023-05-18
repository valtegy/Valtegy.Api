using Valtegy.Domain.Constants;
using Valtegy.Domain.DTOs;
using Valtegy.Domain.Models;
using Valtegy.Domain.Repositories;
using Valtegy.Domain.Services;
using Valtegy.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Valtegy.Service.Functions;

namespace Valtegy.Service.Services
{
    public class ActivitiesService : IActivitiesService
    {
        private readonly IDataRepository<Domain.Entities.Activities> _activityRepository;

        public ActivitiesService(IDataRepository<Domain.Entities.Activities> activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<ResponseModel> CreateActivity(/*int userId, */CreateActivityViewModel activity)
        {
            var entity = new Domain.Entities.Activities
            {
                ActivityDate = activity.ActivityDate,
                ActivityNumber = activity.ActivityNumber,
                ActivityTypeId = activity.ActivityTypeId,
                DateCreated = DateTime.Now,
                Comments = activity.Comments,
                DateUpdated = DateTime.Now,
                Hours = activity.Hours,
                Name = activity.Name,
                StatusActivityId = activity.StatusActivityId,
                InsertDate = DateTime.Now
            };

            var result = await _activityRepository.AddAsync(entity);

            return new ResponseModel(true, result.Id);
        }

        public ResponseModel GetActivity()
        {
            var data = "";// = _activityRepository.GetAll().ToList();

            if (data != null)
            {
                return new ResponseModel(true, data);
            }
            else
            {
                return new ResponseModel(true, null);
            }
        }
    }
}
