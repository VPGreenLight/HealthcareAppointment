global using Microsoft.Extensions.DependencyInjection;
global using HealthcareAppointment.Models;
global using HealthcareAppointment.Data;

namespace HealthcareAppointment.Bussiness
{
    public static class _Imports
    {
        public static void AddServiceCollections(this IServiceCollection service)
        {
            service.AddScoped<IUserService, UserService>();
        }
    }
}
