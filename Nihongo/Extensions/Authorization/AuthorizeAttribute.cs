using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Nihongo.Entites.Models;
using Nihongo.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nihongo.Api.Extensions.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<Role> _roles;

        public AuthorizeAttribute(params Role[] roles)
        {
            _roles = roles ?? new Role[] { };
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // authorization
            var user = (Account)context.HttpContext.Items["Account"];
            if (user == null || _roles.Any() && !_roles.Contains(user.Role))
            {
                // not logged in or role not authorized
                throw new ForbiddenAccessException("Access denied!");
            }
        }
    }
}