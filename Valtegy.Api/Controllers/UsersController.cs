using Valtegy.Api.Models;
using Valtegy.Domain.Services;
using Valtegy.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Valtegy.Service.Services;
using Valtegy.Api.Binders;
using Valtegy.Domain.Helpers;
using System;
using Alender.User.Domain.ViewModels;

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

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CreateUserViewModel request)
        {
            var result = await _usersService.CreateUser(request);

            if (!result.Success)
            {
                return Conflict(new Response409Conflict(result.Message));
            }

            return Created("", result);
        }

        [HttpPost("requestValidateEmailCode")]
        [AllowAnonymous]
        public async Task<IActionResult> RequestValidateEmailCode(RequestValidateEmailCodeViewModel request)
        {
            var result = await _usersService.RequestValidateEmailCode(request);

            if (!result.Success)
            {
                return Conflict(new Response409Conflict(result.Message));
            }

            return Ok(new Response200Ok(result.Data));
        }

        [HttpPost("validateEmailCode")]
        [AllowAnonymous]
        public IActionResult ValidateEmailCode(RequestValidateEmailCodeViewModel request)
        {
            var result = _usersService.ValidateEmailCode(request);

            if (!result.Success)
            {
                return Conflict(new Response409Conflict(result.Message));
            }

            return Ok(new Response200Ok(result.Data));
        }

        [HttpPost("deleteUser/{idUser}")]
        [AllowAnonymous]
        public IActionResult DeleteUser(Guid userId)
        {
            var result = _usersService.DeleteUser(userId);

            if (!result.Success)
            {
                return Conflict(new Response409Conflict(result.Message));
            }

            return Ok(new Response200Ok(result.Data));
        }

        [HttpPost("completeAccount/{email}")]
        [AllowAnonymous]
        public async Task<IActionResult> CompleteAccount(string email, CompleteAccountViewModel request)
        {
            var result = await _usersService.CompleteAccount(email, request);

            if (!result.Success)
            {
                return Conflict(new Response409Conflict(result.Message));
            }

            return Ok(new Response200Ok(result.Data));
        }

        [AllowAnonymous]
        [HttpPost("forgotpassword/{email}")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var result = await _usersService.ForgotPassword(email);

            if (!result.Success)
            {
                return Conflict(new Response409Conflict(result.Message));
            }

            return Ok(new Response200Ok(result.Data));
        }

        [AllowAnonymous]
        [HttpPost("resetpassword")]
        public async Task<IActionResult> SetPassword(ResetPasswordViewModel request)
        {
            var result = await _usersService.ResetPassword(request);

            if (!result.Success)
            {
                return Conflict(new Response409Conflict(result.Message));
            }

            return Ok(new Response200Ok(result.Data));
        }

        [AllowAnonymous]
        [HttpPost("requestForgotPassword/{email}")]
        public async Task<IActionResult> RequestForgotPassword(string email)
        {
            var result = await _usersService.RequestForgotPassword(email);

            if (!result.Success)
            {
                return Conflict(new Response409Conflict(result.Message));
            }

            return Ok(new Response200Ok(result.Data));
        }
    }
}