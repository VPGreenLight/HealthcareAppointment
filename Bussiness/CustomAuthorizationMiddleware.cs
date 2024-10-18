using Microsoft.AspNetCore.Http;

namespace HealthcareAppointment.Bussiness
{
    public class CustomAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var userRole = context.User.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

                if (userRole == "Admin")
                {
                    await _next(context);  // Continue to the next middleware
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Forbidden: You do not have access to this resource.");
                }
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized: Please login.");
            }
        }
    }
}
