using Valtegy.Domain.Helpers;
using Valtegy.Service.Util;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace Valtegy.Api.Binders
{
    public class ClientBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            UserClaims claims = new UserClaims();

            try
            {
                var authorization = bindingContext.HttpContext.Request.Headers["Authorization"].ToString().Split(" ");
                string token = authorization[1];

                claims = JwtToken.ValidateToken(token);

                bindingContext.Result = ModelBindingResult.Success(claims);
            }
            catch (Exception)
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }

            await Task.FromResult(Task.CompletedTask);
        }
    }
}
