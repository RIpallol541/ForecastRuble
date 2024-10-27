using Microsoft.EntityFrameworkCore;
using Forecast.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Forecast.Infrastructure.Data
{
    public class ForecastDbContext : DbContext
    {
        public ForecastDbContext(DbContextOptions<ForecastDbContext> options)
            : base(options)
        {
        }

        public DbSet<CurrencyRate> CurrencyRates { get; set; }
        public DbSet<Prediction> Predictions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Определение связей между сущностями
            modelBuilder.Entity<CurrencyRate>()
                .HasMany(cr => cr.Predictions)
                .WithOne(p => p.CurrencyRate)
                .HasForeignKey(p => p.CurrencyRateId)
                .OnDelete(DeleteBehavior.Cascade);

            // Создание данных с фиксированными курсами валют
            var currencyRates = new List<CurrencyRate>
            {
                new CurrencyRate { Id = Guid.NewGuid(), CurrencyCode = "RUB", Date = new DateTime(2024, 10, 1), Rate = 75.50m },
                new CurrencyRate { Id = Guid.NewGuid(), CurrencyCode = "RUB", Date = new DateTime(2024, 10, 2), Rate = 76.00m },
                new CurrencyRate { Id = Guid.NewGuid(), CurrencyCode = "RUB", Date = new DateTime(2024, 10, 3), Rate = 74.80m },
                new CurrencyRate { Id = Guid.NewGuid(), CurrencyCode = "RUB", Date = new DateTime(2024, 10, 4), Rate = 75.20m },
                new CurrencyRate { Id = Guid.NewGuid(), CurrencyCode = "RUB", Date = new DateTime(2024, 10, 5), Rate = 75.70m }
            };

            modelBuilder.Entity<CurrencyRate>().HasData(currencyRates);

            // Создание прогнозов для каждого курса
            var predictions = new List<Prediction>
            {
                new Prediction { Id = Guid.NewGuid(), CurrencyRateId = currencyRates[0].Id, PredictedDate = new DateTime(2024, 10, 6), PredictedRate = 75.80m },
                new Prediction { Id = Guid.NewGuid(), CurrencyRateId = currencyRates[1].Id, PredictedDate = new DateTime(2024, 10, 7), PredictedRate = 76.10m },
                new Prediction { Id = Guid.NewGuid(), CurrencyRateId = currencyRates[2].Id, PredictedDate = new DateTime(2024, 10, 8), PredictedRate = 74.90m },
                new Prediction { Id = Guid.NewGuid(), CurrencyRateId = currencyRates[3].Id, PredictedDate = new DateTime(2024, 10, 9), PredictedRate = 75.30m },
                new Prediction { Id = Guid.NewGuid(), CurrencyRateId = currencyRates[4].Id, PredictedDate = new DateTime(2024, 10, 10), PredictedRate = 75.60m }
            };

            modelBuilder.Entity<Prediction>().HasData(predictions);
        }
    }
}
