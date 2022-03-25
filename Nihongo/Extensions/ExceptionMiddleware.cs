
using Microsoft.AspNetCore.Http;
using Nihongo.Application.Helpers;
using Nihongo.Shared.Exceptions;
using Nihongo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Nihongo.Api.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = context.Response;
            context.Response.ContentType = "application/json";

            response.StatusCode = ex switch
            {
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                ForbiddenAccessException => (int)HttpStatusCode.Forbidden,
                AppException => (int)HttpStatusCode.BadRequest,
                ArgumentNullException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError,// unhandled error
            };

            return context.Response.WriteAsync(new ErrorDetails
            {
                Message = ex.Message,
            }.ToString());
        }
    }
}
