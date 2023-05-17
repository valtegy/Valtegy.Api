using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;
using Valtegy.Api.Binders.Models;

namespace Valtegy.Api.Binders
{
    public class HeadersRequestBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            HeadersRequest headersRequest = new HeadersRequest();

            try
            {
                headersRequest.OriginIpAddress = bindingContext.HttpContext.Request.Headers["X-Forwarded-For"].ToString();
                bindingContext.Result = ModelBindingResult.Success(headersRequest);
            }
            catch (Exception)
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }

            await Task.FromResult(Task.CompletedTask);
        }
    }
}
