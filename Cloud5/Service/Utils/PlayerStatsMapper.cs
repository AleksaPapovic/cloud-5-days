using Cloud5.Domain.Player;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace Cloud5.Service.Utils
{

    public sealed class PlayerStatsMapper : ClassMap<PlayerStats>
    {
        public PlayerStatsMapper()
        {
            Map(m => m.PlayerName).Name("PLAYER");
            Map(m => m.Position).Name("POSITION");
            Map(m => m.FTM).Name("FTM");
            Map(m => m.FTA).Name("FTA");
            Map(m => m.TwoPM).Name("2PM");
            Map(m => m.TwoPA).Name("2PA");
            Map(m => m.ThreePM).Name("3PM");
            Map(m => m.ThreePA).Name("3PA");
            Map(m => m.REB).Name("REB");
            Map(m => m.BLK).Name("BLK");
            Map(m => m.AST).Name("AST");
            Map(m => m.STL).Name("STL");
            Map(m => m.TOV).Name("TOV");

            Map(m => m.GM).Ignore();
            Map(m => m.FTPercentage).Ignore();
            Map(m => m.TwoPPercentage).Ignore();
            Map(m => m.ThreePPercentage).Ignore();
            Map(m => m.Points).Ignore();
            Map(m => m.Valorization).Ignore();
            Map(m => m.EffectiveFGPercentage).Ignore();
            Map(m => m.TrueShootingPercentage).Ignore();
            Map(m => m.HollingerAssistRatio).Ignore();
        }
    }
}