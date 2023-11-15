using Cloud5.API.Dto;
using Cloud5.Domain.Player;

namespace Cloud5.Service.Interfaces
{
    public interface IPlayerStatsService
    {
        Task<List<PlayerStatsDto>> GeneratePlayerStatsFromCsv(GetPlayerStatsDto getPlayerStats);
    }
}
