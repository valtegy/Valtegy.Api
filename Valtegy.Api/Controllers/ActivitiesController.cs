using Valtegy.Domain.Helpers;
using Valtegy.Domain.Services;
using Valtegy.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Valtegy.Api.Binders;
using Valtegy.Api.Binders.Models;
using Valtegy.Api.Models;
using System.Collections.Generic;

namespace Valtegy.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesService _activityService;

        public ActivitiesController(IActivitiesService activityService)
        {
            _activityService = activityService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([ModelBinder(typeof(ClientBinder))] UserClaims claims,
                                   CreateActivityViewModel request)
        {
            var result = await _activityService.CreateActivity(Guid.Parse(claims.UserId), request);

            if (!result.Success)
            {
                return Conflict(new Response409Conflict(result.Message));
            }

            return Created("", new Response201Created(result.Data));
        }

        [HttpGet]
        public IActionResult Get([ModelBinder(typeof(ClientBinder))] UserClaims claims)
        {
            var result = _activityService.GetActivities(Guid.Parse(claims.UserId));

            if (!result.Success)
            {
                return Conflict(new Response409Conflict(result.Message));
            }

            return Created("", new Response201Created(result.Data));
        }

        [HttpGet("getActivitiesTypeList")]
        public IActionResult GetActivitiesTypeList([ModelBinder(typeof(ClientBinder))] UserClaims claims)
        {
            var result = _activityService.GetActivitiesTypeList();

            if (!result.Success)
            {
                return Conflict(new Response409Conflict(result.Message));
            }

            return Created("", new Response201Created(result.Data));
        }

        [HttpGet("getStatusActivitiesList")]
        public IActionResult GetStatusActivitiesList([ModelBinder(typeof(ClientBinder))] UserClaims claims)
        {
            var result = _activityService.GetStatusActivitiesList();

            if (!result.Success)
            {
                return Conflict(new Response409Conflict(result.Message));
            }

            return Created("", new Response201Created(result.Data));
        }

        [HttpPost("deleteActivities")]
        public async Task<IActionResult> DeleteActivities([ModelBinder(typeof(ClientBinder))] UserClaims claims,
                                   List<Guid> request)
        {
            var result = await _activityService.DeleteActivities(Guid.Parse(claims.UserId), request);

            if (!result.Success)
            {
                return Conflict(new Response409Conflict(result.Message));
            }

            return Created("", new Response201Created(result.Data));
        }

        [HttpPost("updateActivity")]
        public async Task<IActionResult> UpdateActivity([ModelBinder(typeof(ClientBinder))] UserClaims claims,
                                   CreateActivityViewModel request)
        {
            var result = await _activityService.UpdateActivity(Guid.Parse(claims.UserId), request);

            if (!result.Success)
            {
                return Conflict(new Response409Conflict(result.Message));
            }

            return Created("", new Response201Created(result.Data));
        }
    }
}
