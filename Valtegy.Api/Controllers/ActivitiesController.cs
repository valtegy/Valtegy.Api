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

        [HttpGet]
        [Route("{*url}", Order = 999)]
        public IActionResult Index()
        {
            return File("~/wwwroot/index.html", "text/html");
        }

        [HttpPost]
        public async Task<IActionResult> Create([ModelBinder(typeof(ClientBinder))] UserClaims claims,
                                   CreateActivityViewModel request)
        {
            var result = await _activityService.CreateActivity(int.Parse(claims.UserId), request);

            if (!result.Success)
            {
                return Conflict(new Response409Conflict(result.Message));
            }

            return Created("", new Response201Created(result.Data));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get([ModelBinder(typeof(ClientBinder))] UserClaims claims)
        {
            var result = _activityService.GetActivity();

            if (!result.Success)
            {
                return Conflict(new Response409Conflict(result.Message));
            }

            return Created("", new Response201Created(result.Data));
        }
    }
}
