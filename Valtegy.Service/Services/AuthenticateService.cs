using Valtegy.Domain.Constants;
using Valtegy.Domain.DTOs;
using Valtegy.Domain.Helpers;
using Valtegy.Domain.Models;
using Valtegy.Domain.Repositories;
using Valtegy.Domain.Services;
using Valtegy.Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Valtegy.Service.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly SignInManager<Domain.Entities.Users> _signInManager;
        private readonly AppSettings _appSettings;
        private readonly IDataRepository<Domain.Entities.Users> _userRepository;
        private readonly IConfiguration _configuration;

        public AuthenticateService(IDataRepository<Domain.Entities.Users> userRepository,
            IOptions<AppSettings> appSettings,
            SignInManager<Domain.Entities.Users> signInManager,
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public ResponseModel Login(LoginViewModel login)
        {
            try
            {
                var user = _userRepository
                    .Get()
                    .FirstOrDefault(x => x.UserName == login.User && x.LockoutEnabled == false);

                // login with phoneNumber
                if (user == null)
                {
                    user = _userRepository
                    .Get()
                    .FirstOrDefault(x => x.PhoneNumber == login.User && x.PhoneNumberConfirmed == true && x.LockoutEnabled == false);
                }

                if (user != null)
                {
                    var result = _signInManager.CheckPasswordSignInAsync(user,
                               login.Password, lockoutOnFailure: true).GetAwaiter().GetResult();

                    if (result.Succeeded)
                    {
                        string token = "";
                        if (user.EmailConfirmed)
                        {
                            token = GenerateJwtToken(user); 
                        }
                        
                        var authenticateDTO = new AuthenticateDTO(user, token);

                        return new ResponseModel(true, authenticateDTO);
                    }
                }

                throw new AlenderException(ErrorMessage.Authentication.InvalidCredentials);
            }
            catch (AlenderException ex)
            {
                return new ResponseModel(false, ex.Message);
            }
        }

        private string GenerateJwtToken(Domain.Entities.Users user)
        {
            double expiresTokenMinutes = double.Parse(_appSettings.ExpiresTokenMinutes);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            List<string> roles = new List<string>()
            {
                "lender",
                "borrower"
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("appId", _appSettings.AppId),
                    new Claim("userId", user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(expiresTokenMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
