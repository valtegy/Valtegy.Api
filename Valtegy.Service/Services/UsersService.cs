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
using System.Threading.Tasks;
using Valtegy.Domain.Constants;
using static Dapper.SqlMapper;
using Newtonsoft.Json.Linq;
using System.Runtime.Intrinsics.Arm;
using Alender.User.Domain.ViewModels;

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

                await _notificationService.CreateNotification(user.Id, notification);
            }

            return new ResponseModel(true);
        }

        public ResponseModel DeleteUser(Guid userId)
        {
            _usersRepository.Delete(userId);

            return new ResponseModel(true, userId);
        }

        public bool ExistsUserName(string userName)
        {
            var entityUser = _usersRepository.Get().FirstOrDefault(x => x.UserName.ToLower() == userName.ToLower());

            if (entityUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ResponseModel ValidateEmailCode(RequestValidateEmailCodeViewModel data)
        {
            var user = _usersRepository.Get().FirstOrDefault(x => x.Email == data.Email
                                                            && x.ValidateEmailCode != null
                                                            && x.ValidateEmailCode == data.Code.ToString()
                                                            && x.LockoutEnabled == false);

            if (user != null)
            {
                var entityUser = user;
                user.ValidateEmailCode = null;
                user.EmailConfirmed = true;

                _usersRepository.Update(entityUser, user);

                return new ResponseModel(true);
            }

            return new ResponseModel(false, "Validación no exitosa.");
        }
        public async Task<ResponseModel> CompleteAccount(string email, CompleteAccountViewModel user)
        {
            var entity = _usersRepository.Get().FirstOrDefault(x => x.UserName.ToLower().Trim() == email.ToLower().Trim());

            if (entity == null)
            {
                return new ResponseModel(false, ErrorMessage.Repository.RecordNotFound);
            }

            var model = entity;

            model.FirstName = user.FirstName;
            model.MiddleName = user.MiddleName;
            model.LastName1 = user.LastName1;
            model.LastName2 = user.LastName2;
            model.BirthdayDate = user.BirthdayDate;
            model.IsEnabled = true;

            _usersRepository.Update(entity, model);

            string pathRoot = Environment.CurrentDirectory;
            var filePath = Path.Combine(pathRoot, "Templates", "CompleteAccount.html");
            string template = File.ReadAllText(filePath);

            var notification = new CreateNotificationViewModel
            {
                To = entity.Email,
                Subject = "Validación de cuenta valtegy",
                IsBodyHtml = true,
                BobyMessage = UserGeneratorFunction.GetHtml(template.Replace("\r", "").Replace("\n", ""),
                new
                {
                    firstName = entity.FirstName,
                    lastName1 = entity.LastName1
                })
            };

            await _notificationService.CreateNotification(entity.Id, notification);

            return new ResponseModel(true, entity.Id);
        }

        public async Task<ResponseModel> ForgotPassword(string email)
        {
            var user = await _usersManager.FindByEmailAsync(email);

            if (user != null)
            {
                string urlBase = _configuration.GetSection("ForgotPassword")["UrlBase"].ToString();
                var token = await _usersManager.GeneratePasswordResetTokenAsync(user);
                string pathRoot = Environment.CurrentDirectory;
                var filePath = Path.Combine(pathRoot, "Templates", "ForgotPassword.html");
                string template = File.ReadAllText(filePath);

                var notification = new CreateNotificationViewModel
                {
                    To = user.Email,
                    Subject = "Restablecer contraseña valtegy",
                    IsBodyHtml = true,
                    BobyMessage = UserGeneratorFunction.GetHtml(template.Replace("\r", "").Replace("\n", ""),
                    new
                    {
                        HrefLink = "href=" + "\"" + urlBase + "/restablecer-contraseña/" + email + "/" + System.Net.WebUtility.UrlEncode(token) + "/\""
                    })
                };

                await _notificationService.CreateNotification(user.Id, notification);

                return new ResponseModel(true, data: null);
            }

            return new ResponseModel(false, "No se encontró el registro de usuario.");
        }

        public async Task<ResponseModel> RequestForgotPassword(string email)
        {
            var user = await _usersManager.FindByEmailAsync(email);

            if (user != null)
            {
                string pathRoot = Environment.CurrentDirectory;
                var filePath = Path.Combine(pathRoot, "Templates", "RequestConfirmChangePassword.html");
                string template = File.ReadAllText(filePath);

                var notification = new CreateNotificationViewModel
                {
                    To = user.Email,
                    Subject = "Contraseña restablecida",
                    IsBodyHtml = true,
                    BobyMessage = UserGeneratorFunction.GetHtml(template.Replace("\r", "").Replace("\n", ""), null)
                };

                await _notificationService.CreateNotification(user.Id, notification);

                return new ResponseModel(true, data: null);
            }

            return new ResponseModel(false, "No se encontró el registro de usuario.");
        }

        public async Task<ResponseModel> ResetPassword(ResetPasswordViewModel data)
        {
            var user = await _usersManager.FindByEmailAsync(data.Email);

            if (user != null)
            {
                var result = await _usersManager.ResetPasswordAsync(user, data.Token, data.Password);

                if (result.Succeeded)
                {
                    return new ResponseModel(true, data: null);
                }
                else
                {
                    return new ResponseModel(false, JsonConvert.SerializeObject(result.Errors));
                }
            }

            return new ResponseModel(false, "La sesión ha expirado.");
        }
    }
}
