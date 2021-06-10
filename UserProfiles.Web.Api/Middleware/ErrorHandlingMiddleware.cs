using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;
using UserProfiles.Domain.Exceptions;
using UserProfiles.Web.Api.Models;

namespace UserProfiles.Web.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ErrorHandlingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                var exceptionType = e.GetType();
                LogException(exceptionType, e);

                if (exceptionType == typeof(UnauthorizedAccessException))
                {
                    await HandleUnauthorizedException(context);
                }
                else
                {
                    await HandleExceptionAsync(context, e);
                }
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = new ApiResponse(-1, exception.Message);

            if (exception is BusinessException businessException)
            {
                response.Status = businessException.Status;
                response.Description = response.Description.Contains(nameof(BusinessException)) ? businessException.Description : response.Description;
                context.Response.StatusCode = (int)HttpStatusCode.OK;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            var model = JsonConvert.SerializeObject(response,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            return context.Response.WriteAsync(model);
        }

        private Task HandleUnauthorizedException(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return Task.FromResult(0);
        }

        private void LogException(Type exceptionType, Exception exception)
        {
            if (exceptionType != typeof(BusinessException) || exceptionType != typeof(UnauthorizedAccessException))
            {
                _logger.LogError(exception, exception.Message);
            }
        }
    }
}
