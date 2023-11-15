using Cloud5.Domain;
using Cloud5.Domain.Player;
using Cloud5.Service.Utils;
using CsvHelper;
using System.Globalization;

namespace Cloud5.Service.Implementation
{
    public static class CsvImportUtil
    {
        public static async Task ImportPlayerStats(this WebApplication app, string fileName = "test.csv")
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<CloudDbContext>();

                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

                using (var stream = File.OpenRead(filePath))
                using (var reader = new StreamReader(stream))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<PlayerStatsMapper>();
                    int id = 1;
                    var playerStats = new List<PlayerStats>();
                    while (await csv.ReadAsync())
                    {
                        var record = csv.GetRecord<PlayerStats>();
                        record.Id = id++;
                        playerStats.Add(record);
                    }
                    await context.PlayerStats.AddRangeAsync(playerStats);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
