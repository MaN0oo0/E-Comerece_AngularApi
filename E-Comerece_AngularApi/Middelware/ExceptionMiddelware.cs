using E_Comerece_AngularApi.Errors;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace E_Comerece_AngularApi.Middelware
{
    public class ExceptionMiddelware
    {
        private readonly RequestDelegate requestDelegate;
        private readonly ILogger<ExceptionMiddelware> logger;
        private readonly IHostEnvironment hostEnvironment;

        public ExceptionMiddelware(RequestDelegate requestDelegate, ILogger<ExceptionMiddelware> logger, IHostEnvironment hostEnvironment)
        {
            this.requestDelegate = requestDelegate;
            this.logger = logger;
            this.hostEnvironment = hostEnvironment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                context.Response.ContentType = "appliction/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = hostEnvironment.IsDevelopment()
                    ?
                    new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString()) :
                    new ApiException((int)HttpStatusCode.InternalServerError);

                var Options = new JsonSerializerOptions { PropertyNamingPolicy= JsonNamingPolicy.CamelCase };

                var json=JsonSerializer.Serialize(response, Options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
