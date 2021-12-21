using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using System.Net.Http;

namespace Nihongo.Api.Filters
{
    public class ValidationActionFilter : ActionFilterAttribute
    {
        public void OnActionExecuting(ActionExecutedContext context)
        {
            var modelState = context.ModelState;
            if (!modelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(modelState);
            }
        }
    }
}
