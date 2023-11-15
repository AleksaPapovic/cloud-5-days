using Cloud5.API.Dto;
using Cloud5.Domain;
using Cloud5.Domain.Player;
using Cloud5.Repository.Interface;
using Cloud5.Service.Interfaces;
using System.Net;

namespace Cloud5.Service.Implementation
{
    public class PlayerStatsService : IPlayerStatsService
    {
        private readonly IPlayerStatsRepository _playerStatsRepository;


        public PlayerStatsService(IPlayerStatsRepository playerStatsRepository)
        {
            _playerStatsRepository = playerStatsRepository;
        }

        public async Task<List<PlayerStatsDto>> GeneratePlayerStatsFromCsv(GetPlayerStatsDto getPlayerStats)
        {
            var playerStatsList = _playerStatsRepository.GetPlayerStatsByName(getPlayerStats.playerName);
            if (playerStatsList == null || playerStatsList.Count == 0)
                throw new CloudException("Player not found", HttpStatusCode.NotFound);

            var statsByPlayerName = playerStatsList
           .GroupBy(p => p.PlayerName)
           .Select(group => new PlayerStats
           {
               PlayerName = group.Key,
               Position = group.First().Position,
               FTM = group.Average(p => p.FTM),
               FTA = group.Average(p => p.FTA),
               TwoPM = group.Average(p => p.TwoPM),
               TwoPA = group.Average(p => p.TwoPA),
               ThreePM = group.Average(p => p.ThreePM),
               ThreePA = group.Average(p => p.ThreePA),
               REB = group.Average(p => p.REB),
               BLK = group.Average(p => p.BLK),
               AST = group.Average(p => p.AST),
               STL = group.Average(p => p.STL),
               TOV = group.Average(p => p.TOV),
               GM = group.Count(),
           })
           .ToList();

            List<PlayerStatsDto> generatedStats = new List<PlayerStatsDto>();
            foreach (var playerStat in statsByPlayerName)
            {
                playerStat.CreateStats();
                generatedStats.Add(new PlayerStatsDto()
                {
                    PlayerName = playerStat.PlayerName,
                    GamesPlayed = playerStat.GM,
                    Traditional = new TraditionalStatsDto()
                    {
                        FreeThrows = new ShootingStatsDto()
                        {
                            Attempts = decimal.Round(playerStat.FTA, 1),
                            Made = decimal.Round(playerStat.FTM, 1),
                            ShootingPercentage = decimal.Round(playerStat.FTPercentage, 1)
                        },
                        TwoPoints = new ShootingStatsDto()
                        {
                            Attempts = decimal.Round(playerStat.TwoPA, 1),
                            Made = decimal.Round(playerStat.TwoPM, 1),
                            ShootingPercentage = decimal.Round(playerStat.TwoPPercentage, 1)
                        },
                        ThreePoints = new ShootingStatsDto()
                        {
                            Attempts = decimal.Round(playerStat.ThreePA, 1),
                            Made = decimal.Round(playerStat.ThreePM, 1),
                            ShootingPercentage = decimal.Round(playerStat.ThreePPercentage, 1)
                        },
                        Points = decimal.Round(playerStat.Points, 1),
                        Rebounds = decimal.Round(playerStat.REB, 1),
                        Blocks = decimal.Round(playerStat.BLK, 1),
                        Assists = decimal.Round(playerStat.AST, 1),
                        Steals = decimal.Round(playerStat.STL, 1),
                        Turnovers = decimal.Round(playerStat.TOV, 1)
                    },
                    Advanced = new AdvancedStatsDto()
                    {
                        Valorization = decimal.Round(playerStat.Valorization, 1),
                        EffectiveFieldGoalPercentage = decimal.Round(playerStat.EffectiveFGPercentage, 1),
                        TrueShootingPercentage = decimal.Round(playerStat.TrueShootingPercentage, 1),
                        HollingerAssistRatio = decimal.Round(playerStat.HollingerAssistRatio, 1)
                    }
                });
            }

            return generatedStats;
        }

    }
}
