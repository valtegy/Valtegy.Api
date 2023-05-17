using Valtegy.Domain.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using Valtegy.Api.Models;

namespace Valtegy.Api.GlobalErrorHandling.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger, IConfiguration configuration)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var appSettingsSection = configuration.GetSection("AppSettings");
                        var appSettings = appSettingsSection.Get<AppSettings>();
                        string traceId = System.Guid.NewGuid().ToString();
                        LogErrorModel logErrorModel = new LogErrorModel(appSettings.AppId, traceId, contextFeature.Error.ToString());

                        logger.LogError($"{JsonConvert.SerializeObject(logErrorModel)}");
                        await context.Response.WriteAsync
                        (
                            JsonConvert.SerializeObject(new Response500InternalServerError(traceId, "Internal Server Error."))
                        );
                    }
                });
            });
        }
    }
}
