using Cloud5.Repository.Implementation;
using Cloud5.Repository.Interface;

namespace Cloud5.Repository
{
    public static class ConfigRepositories
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPlayerStatsRepository, PlayerStatsRepository>();
        }
    }
}
