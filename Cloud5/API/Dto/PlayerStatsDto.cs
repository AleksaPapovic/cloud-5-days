using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cloud5.API.Dto
{
    public record GetPlayerStatsDto([FromRoute] string? playerName);

    public record PlayerStatsDto
    {
        public string PlayerName { get; set; }
        public int GamesPlayed { get; set; }
        public TraditionalStatsDto Traditional { get; set; }
        public AdvancedStatsDto Advanced { get; set; }
    }

    public record TraditionalStatsDto
    {
        public ShootingStatsDto FreeThrows { get; set; }
        public ShootingStatsDto TwoPoints { get; set; }
        public ShootingStatsDto ThreePoints { get; set; }
        [Precision(18, 1)]
        public decimal Points { get; set; }
        [Precision(18, 1)]
        public decimal Rebounds { get; set; }
        [Precision(18, 1)]
        public decimal Blocks { get; set; }
        [Precision(18, 1)]
        public decimal Assists { get; set; }
        [Precision(18, 1)]
        public decimal Steals { get; set; }
        [Precision(18, 1)]
        public decimal Turnovers { get; set; }
    }

    public record ShootingStatsDto
    {
        [Precision(18, 1)]
        public decimal Attempts { get; set; }
        [Precision(18, 1)]
        public decimal Made { get; set; }
        [Precision(18, 1)]
        public decimal ShootingPercentage { get; set; }
    }

    public record AdvancedStatsDto
    {
        [Precision(18, 1)]
        public decimal Valorization { get; set; }
        [Precision(18, 1)]
        public decimal EffectiveFieldGoalPercentage { get; set; }
        [Precision(18, 1)]
        public decimal TrueShootingPercentage { get; set; }
        [Precision(18, 1)]
        public decimal HollingerAssistRatio { get; set; }
    }
}
