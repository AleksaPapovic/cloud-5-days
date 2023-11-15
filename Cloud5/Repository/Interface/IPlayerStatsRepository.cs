using Cloud5.Domain.Player;

namespace Cloud5.Repository.Interface
{
    public interface IPlayerStatsRepository
    {
        List<PlayerStats> GetPlayerStatsByName(string playerName);
    }
}
