using Valtegy.Domain.Constants;
using Valtegy.Domain.Models;
using Valtegy.Domain.Repositories;
using Valtegy.Domain.Services;
using Valtegy.Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Valtegy.Service.Services
{
    public class UsersService : IUsersService
    {
        private readonly UserManager<Valtegy.Domain.Entities.Users> _usersManager;
        private readonly IDataRepository<Valtegy.Domain.Entities.Users> _usersRepository;
        private readonly IConfiguration _configuration;

        public UsersService(IDataRepository<Valtegy.Domain.Entities.Users> usersRepository,
            UserManager<Valtegy.Domain.Entities.Users> usersManager,
            IConfiguration configuration)
        {
            _usersRepository = usersRepository;
            _usersManager = usersManager;
            _configuration = configuration;
        }

        public ResponseModel CreateUser(CreateUserViewModel user)
        {
            var entityUser = _usersRepository.GetAll().FirstOrDefault(x => x.Email == user.UserName);

            if (entityUser != null)
            {
                //this.RequestValidateEmailCode(new RequestValidateEmailCodeViewModel { Email = entityUser.Email });

                return new ResponseModel(true, entityUser.Id);
            }

            try
            {
                var entity = new Valtegy.Domain.Entities.Users
                {
                    UserName = user.UserName,
                    Email = user.UserName,
                    PhoneNumber = user.PhoneNumber,
                    FirstName = user.FirstName,
                    MiddleName = user.MiddleName,
                    LastName1 = user.LastName1,
                    LastName2 = user.LastName2,
                    BirthdayDate = user.BirthdayDate,
                };

                var result = _usersManager.CreateAsync(entity, user.Password).GetAwaiter().GetResult();

                if (result.Succeeded)
                {
                    //this.RequestValidateEmailCode(new RequestValidateEmailCodeViewModel { Email = entity.Email });

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
    }
}
