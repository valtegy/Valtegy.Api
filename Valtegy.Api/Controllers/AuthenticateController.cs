using Valtegy.Api.Models;
using Valtegy.Domain.Services;
using Valtegy.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Valtegy.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/users/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        readonly IAuthenticateService _authenticateService;

        public AuthenticateController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpGet]
        [Route("{*url}", Order = 999)]
        public IActionResult Index()
        {
            return File("~/wwwroot/index.html", "text/html");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            var result = _authenticateService.Login(login);

            if (!result.Success)
            {
                return Conflict(new Response409Conflict(result.Message));
            }

            return Ok(new Response200Ok(result.Data));
        }
    }
}
