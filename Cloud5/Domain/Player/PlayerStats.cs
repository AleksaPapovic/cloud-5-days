using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Cloud5.Domain.Player
{
    public class PlayerStats
    {
        [Key]
        public int Id { get; set; }
        [Name("PLAYER")]
        public string PlayerName { get; set; }
        [Name("POSITION")]
        public string Position { get; set; }
        [Name("FTM")]
        public decimal FTM { get; set; }
        [Name("FTA")]
        public decimal FTA { get; set; }
        [Name("2PM")]
        public decimal TwoPM { get; set; }
        [Name("2PA")]
        public decimal TwoPA { get; set; }
        [Name("3PM")]
        public decimal ThreePM { get; set; }
        [Name("3PA")]
        public decimal ThreePA { get; set; }
        [Name("REB")]
        public decimal REB { get; set; }
        [Name("BLK")]
        public decimal BLK { get; set; }
        [Name("AST")]
        public decimal AST { get; set; }
        [Name("STL")]
        public decimal STL { get; set; }
        [Name("TOV")]
        public decimal TOV { get; set; }
        public int GM { get; set; }

        public decimal FTPercentage { get; set; }
        public decimal TwoPPercentage { get; set; }
        public decimal ThreePPercentage { get; set; }
        public decimal Points { get; set; }
        public decimal Valorization { get; set; }
        public decimal EffectiveFGPercentage { get; set; }
        public decimal TrueShootingPercentage { get; set; }
        public decimal HollingerAssistRatio { get; set; }

        public PlayerStats CreateStats()
        {
            FTPercentage = FTA == 0 ? 0 : FTM / FTA * 100;
            TwoPPercentage = TwoPA == 0 ? 0 : TwoPM / TwoPA * 100;
            ThreePPercentage = ThreePA == 0 ? 0 : ThreePM / ThreePA * 100;
            Points = FTM + 2 * TwoPM + 3 * ThreePM;
            Valorization = (FTM + 2 * TwoPM + 3 * ThreePM + REB + BLK + AST + STL) - (FTA - FTM + TwoPA - TwoPM + ThreePA - ThreePM + TOV);
            EffectiveFGPercentage = (TwoPA + ThreePA) == 0 ? 0 : (TwoPM +(decimal)1.50 * ThreePM) / (TwoPA + ThreePA) * 100;
            TrueShootingPercentage = Points == 0 ? 0 : Points / (2 * (TwoPA + ThreePA + (decimal)0.475 * FTA)) * 100;
            HollingerAssistRatio = (TwoPA + ThreePA + (decimal)0.475 * FTA + AST + TOV) == 0 ? 0 : AST / (TwoPA + ThreePA + (decimal)0.475 * FTA + AST + TOV) * 100;
            return this;
        }
    }

}
