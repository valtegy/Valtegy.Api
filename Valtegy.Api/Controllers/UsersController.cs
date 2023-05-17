using Valtegy.Api.Binders;
using Valtegy.Api.Models;
using Valtegy.Domain.Helpers;
using Valtegy.Domain.Services;
using Valtegy.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Valtegy.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        [Route("{*url}", Order = 999)]
        public IActionResult Index()
        {
            return File("~/wwwroot/index.html", "text/html");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(CreateUserViewModel request)
        {
            var result = _usersService.CreateUser(request);

            if (!result.Success)
            {
                return Conflict(new Response409Conflict(result.Message));
            }

            return Created("", result);
        }
    }
}