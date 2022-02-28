using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nihongo.Api.Models;
using Nihongo.Application.Helpers;
using Nihongo.Application.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Nihongo.Api.Extensions.CustomExceptionMiddleware
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
                _ => (int)HttpStatusCode.InternalServerError,// unhandled error
            };

            return context.Response.WriteAsync(new ErrorDetails
            {
                Message = ex.Message,
            }.ToString());
        }
    }
}
