﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreWebAPI.Filters
{
    public class AuthorizeFilter : IAuthorizationFilter
    {
        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //if(!context.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    context.Result = new UnauthorizedResult();
            //    return;
            //}
        }
    }
}
