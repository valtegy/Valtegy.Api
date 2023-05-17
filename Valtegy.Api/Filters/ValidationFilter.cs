using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Valtegy.Api.Models;

namespace Valtegy.Api.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(x => x.ErrorMessage))
                    .ToArray();

                List<ErrorModel> listErrorModel = new List<ErrorModel>();

                foreach (var error in errors)
                {
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new ErrorModel
                        {
                            FieldName = error.Key,
                            Message = subError
                        };

                        listErrorModel.Add(errorModel);
                    }
                }

                var response400BadRequest = new Response400BadRequest(listErrorModel);

                context.Result = new BadRequestObjectResult(response400BadRequest);
                return;
            }

            await next();


        }
    }
}
