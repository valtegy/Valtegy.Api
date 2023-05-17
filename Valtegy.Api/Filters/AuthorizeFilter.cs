using Valtegy.Domain.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System;

namespace Valtegy.Api.Filters
{
    public class AuthorizeFilter : Attribute, IResourceFilter
    {
        //private string _roles;
        private AppSettings _appSettings;

        //public AuthorizeFilter(string roles)
        //{
        //    _roles = roles;
        //}

        public AuthorizeFilter()
        {

        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            try
            {
                _appSettings = ((IOptions<AppSettings>)context.HttpContext.RequestServices.GetService(typeof(IOptions<AppSettings>))).Value;

                var authorization = context.HttpContext.Request.Headers["Authorization"].ToString().Split(" ");
                string token = authorization[1];

                //var claims = JwtToken.ValidateToken(token);
                //var rolesClaims = JsonConvert.DeserializeObject<List<string>>(claims.Roles);

                //var rolesAuth = _roles.Split(",");

                //bool authorized = false;

                //foreach (var role in rolesClaims)
                //{
                //    if (rolesAuth.Contains(role))
                //    {
                //        authorized = true;
                //        break;
                //    }
                //}

                //if (!authorized)
                //{
                //    context.Result = new ObjectResult("Can't process this!")
                //    {
                //        StatusCode = 403,
                //    };
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
