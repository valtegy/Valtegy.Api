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
using static System.Collections.Specialized.BitVector32;
using static Dapper.SqlMapper;
using System.Xml.Linq;
using Valtegy.Domain.Entities;

namespace Valtegy.Service.Services
{
    public class ActivitiesService : IActivitiesService
    {
        private readonly IDataRepository<Domain.Entities.Activities> _activitiesRepository;
        private readonly IDataRepository<Domain.Entities.ActivityType> _activityTypeRepository;
        private readonly IDataRepository<Domain.Entities.StatusActivity> _statusActivityRepository;

        public ActivitiesService(IDataRepository<Domain.Entities.Activities> activitiesRepository, 
            IDataRepository<Domain.Entities.ActivityType> activityTypeRepository,
            IDataRepository<Domain.Entities.StatusActivity> statusActivityRepository)
        {
            _activitiesRepository = activitiesRepository;
            _activityTypeRepository = activityTypeRepository;
            _statusActivityRepository = statusActivityRepository;
        }

        public async Task<ResponseModel> CreateActivity(Guid userId, CreateActivityViewModel activity)
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
                Minutes = activity.Minutes,
                Name = activity.Name,
                StatusActivityId = activity.StatusActivityId,
                InsertDate = DateTime.Now,
                UserIdCreated = userId,
                IsEnabled = true
            };

            var result = await _activitiesRepository.AddAsync(entity);

            return new ResponseModel(true, result.Id);
        }

        public ResponseModel GetActivities(Guid userId)
        {
            var activityTypeList = _activityTypeRepository.GetAll().ToList();
            var statusActivityList = _statusActivityRepository.GetAll().ToList();
            var activitiesList = new List<CreateActivityViewModel>();

            foreach (var entity in _activitiesRepository.GetAll().Where(x => x.UserIdCreated == userId && x.IsEnabled == true).ToList())
            {
                activitiesList.Add(
                    new CreateActivityViewModel
                    {
                        Id = entity.Id,
                        ActivityDate = entity.ActivityDate,
                        Name = entity.Name,
                        ActivityTypeId = entity.ActivityTypeId,
                        ActivityType = activityTypeList.FirstOrDefault(x => x.ActivityTypeId == entity.ActivityTypeId).Name,
                        ActivityNumber = entity.ActivityNumber,
                        Hours= entity.Hours,
                        Minutes= entity.Minutes,
                        StatusActivityId = entity.StatusActivityId,
                        StatusActivity = statusActivityList.FirstOrDefault(x => x.StatusActivityId == entity.ActivityTypeId).Name,
                        Comments = entity.Comments
                    }
                );
            }

            return new ResponseModel(true, activitiesList);
        }

        public ResponseModel GetActivitiesTypeList()
        {
            var data = _activityTypeRepository.GetAll().ToList();

            return new ResponseModel(true, data);
        }

        public ResponseModel GetStatusActivitiesList()
        {
            var data = _statusActivityRepository.GetAll().ToList();

            return new ResponseModel(true, data);
        }

        public async Task<ResponseModel> DeleteActivities(Guid userId, List<Guid> request)
        {
            if (request != null && request.Count > 0)
            {
                var data = _activitiesRepository.GetAll().Where(x => request.Contains(x.Id)).ToList();

                foreach (var activity in data)
                {
                    activity.IsEnabled = false;
                    activity.DateUpdated = DateTime.Now;
                    activity.UserIdUpdated = userId;
                }

                await _activitiesRepository.UpdateRangeAsync(data);

                return new ResponseModel(true, data);
            }

            return new ResponseModel(true);
        }

        public async Task<ResponseModel> UpdateActivity(Guid userId, CreateActivityViewModel createActivityViewModel)
        {
            var data = _activitiesRepository.GetAll().FirstOrDefault(x => x.Id == createActivityViewModel.Id);

            if (data != null)
            {
                data.ActivityDate = createActivityViewModel.ActivityDate;
                data.Name = createActivityViewModel.Name;
                data.ActivityTypeId = createActivityViewModel.ActivityTypeId;
                data.ActivityNumber = createActivityViewModel.ActivityNumber;
                data.Hours = createActivityViewModel.Hours;
                data.Minutes = createActivityViewModel.Minutes;
                data.StatusActivityId = createActivityViewModel.StatusActivityId;
                data.Comments = createActivityViewModel.Comments;

                await _activitiesRepository.UpdateAsync(data);

                return new ResponseModel(true, data);
            }

            return new ResponseModel(false, ErrorMessage.Repository.RecordNotFound);
        }
    }
}
