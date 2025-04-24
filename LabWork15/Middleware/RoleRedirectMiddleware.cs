namespace LabWork15.Middleware
{
    public class RoleRedirectMiddleware
    {
        private readonly RequestDelegate _next;

        public RoleRedirectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var path = context.Request.Path;

                if (path.StartsWithSegments("/Admin") && !context.User.IsInRole("Admin"))
                {
                    context.Response.Redirect("/Home/AccessDenied");
                    return;
                }
            }

            await _next(context);
        }
    }

    public static class RoleRedirectMiddlewareExtensions
    {
        public static IApplicationBuilder UseRoleRedirectMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RoleRedirectMiddleware>();
        }
    }
}
