
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace WebUI.Configs
{
    public class AuthorizationRequirement : IAuthorizationRequirement { }

    public class PermissionHandler : AuthorizationHandler<AuthorizationRequirement>
    {
        

        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationRequirement requirement)
        {
            if(context.User.Identity.IsAuthenticated)
            context.Succeed(requirement);
        }
        public class ErrorHandlingMiddleware
        {
            private readonly RequestDelegate next;

            public ErrorHandlingMiddleware(RequestDelegate next)
            {   
                this.next = next;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                await next(context);

                if (context.Response.StatusCode == 404)
                {
                    context.Response.Redirect("/Home/Error");
                }
            }
        }
    }
}