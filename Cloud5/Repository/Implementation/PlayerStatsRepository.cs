using Cloud5.Domain;
using Cloud5.Domain.Player;
using Cloud5.Repository.Interface;

namespace Cloud5.Repository.Implementation
{
    public class PlayerStatsRepository : IPlayerStatsRepository
    {

        private readonly CloudDbContext _cloudDbContext;

        public PlayerStatsRepository(CloudDbContext cloudDbContext)
        {
            _cloudDbContext = cloudDbContext;
        }

        public List<PlayerStats> GetPlayerStatsByName(string playerName)
        {
            return _cloudDbContext.PlayerStats.Where(playerStat => playerStat.PlayerName.Contains(playerName.Trim())).ToList();
        }
    }
}
