using Cloud5.Service.Implementation;
using Cloud5.Service.Interfaces;

namespace Cloud5.Service
{
    public static class ConfigServices
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPlayerStatsService, PlayerStatsService>();
        }
    }
}
