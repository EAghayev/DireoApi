using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Direo.Data;
using Microsoft.AspNetCore.Mvc;

namespace Direo.Filter
{
    public class Auth : ActionFilterAttribute
    {
        private readonly DireoContext _context;

        public Auth(DireoContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (String.IsNullOrEmpty(context.HttpContext.Request.Headers["token"]))
            {
                context.Result = new BadRequestObjectResult("Token is missing");
            }

            string token = context.HttpContext.Request.Headers["token"];

            var user = _context.Users.FirstOrDefault(u => u.Token == token);

            if(user == null)
            {
                context.Result = new UnauthorizedObjectResult("Token is incorrect");
            }

            base.OnActionExecuting(context);
        }

    }
}
