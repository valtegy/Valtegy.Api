﻿using Valtegy.Domain.Constants;
using Valtegy.Domain.Models;
using Valtegy.Domain.Repositories;
using Valtegy.Domain.Services;
using Valtegy.Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using Valtegy.Service.Functions;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;

namespace Valtegy.Service.Services
{
    public class UsersService : IUsersService
    {
        private readonly UserManager<Domain.Entities.Users> _usersManager;
        private readonly IDataRepository<Domain.Entities.Users> _usersRepository;
        private readonly INotificationService _notificationService;
        private readonly IConfiguration _configuration;

        public UsersService(IDataRepository<Domain.Entities.Users> usersRepository,
            UserManager<Domain.Entities.Users> usersManager,
            INotificationService notificationService,
            IConfiguration configuration)
        {
            _usersRepository = usersRepository;
            _usersManager = usersManager;
            _notificationService = notificationService;
            _configuration = configuration;
        }

        public async Task<ResponseModel> CreateUser(CreateUserViewModel user)
        {
            var entityUser = _usersRepository.Get().FirstOrDefault(x => x.Email == user.UserName);

            if (entityUser != null)
            {
                await this.RequestValidateEmailCode(new RequestValidateEmailCodeViewModel { Email = entityUser.Email });

                return new ResponseModel(true, entityUser.Id);
            }

            try
            {
                var entity = new Domain.Entities.Users
                {
                    UserName = user.UserName,
                    FirstName = "",
                    LastName1 = "",
                    Email = user.UserName,
                    ValidateEmailCode = GenerateValidationCode.GenerateCode(),
                };

                var result = _usersManager.CreateAsync(entity, user.Password).GetAwaiter().GetResult();

                if (result.Succeeded)
                {
                    await this.RequestValidateEmailCode(new RequestValidateEmailCodeViewModel { Email = entity.Email });

                    return new ResponseModel(true, entity.Id);
                }
                else
                {
                    return new ResponseModel(false, JsonConvert.SerializeObject(result.Errors));
                }
            }
            catch (AlenderException ex)
            {
                return new ResponseModel(false, ex.Message);
            }
        }
        
        public async Task<ResponseModel> RequestValidateEmailCode(RequestValidateEmailCodeViewModel data)
        {
            var user = _usersRepository.Get().FirstOrDefault(x => x.Email == data.Email && x.LockoutEnabled == false);

            if (user != null)
            {
                var entityUser = user;
                user.ValidateEmailCode = GenerateValidationCode.GenerateCode();

                _usersRepository.Update(entityUser, user);

                string pathRoot = Environment.CurrentDirectory;
                var filePath = Path.Combine(pathRoot, "Templates", "RequestValidateEmailCode.html");
                string template = File.ReadAllText(filePath);
                var bobyMessage = UserGeneratorFunction.GetHtml(template.Replace("\r", "").Replace("\n", ""), new { user.ValidateEmailCode });

                var notification = new CreateNotificationViewModel
                {
                    To = user.Email,
                    Subject = "Validación de cuenta valtegy",
                    IsBodyHtml = true,
                    BobyMessage = bobyMessage
                };

                await _notificationService.CreateNotification(null, notification);
            }

            return new ResponseModel(true);
        }
    }
}
