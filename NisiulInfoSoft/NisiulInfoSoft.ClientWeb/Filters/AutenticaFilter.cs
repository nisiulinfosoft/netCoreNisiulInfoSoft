using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace NisiulInfoSoft.ClientWeb.Filters
{
    public class AutenticaFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var cadena = context.HttpContext.Session.GetString("user");

            if (cadena == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                            { "controller", "Login"},
                            {"action","Index" }
                        }
                    );
            }
        }
    }
}
