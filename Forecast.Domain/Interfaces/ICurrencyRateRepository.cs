using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Forecast.Domain.Entities;

namespace Forecast.Domain.Repositories
{
    public interface ICurrencyRateRepository
    {
        Task<IEnumerable<CurrencyRate>> GetAllAsync();
        Task<CurrencyRate> GetCurrencyRateByIdAsync(Guid id);
        Task AddCurrencyRateAsync(CurrencyRate currencyRate);
        Task<CurrencyRate> GetCurrencyRateAsync(string currencyCode, DateTime date);
        Task<CurrencyRate> GetLatestCurrencyRateAsync(string currencyCode);
        Task UpdateCurrencyRateAsync(CurrencyRate currencyRate);
        Task DeleteCurrencyRateAsync(Guid id);
    }
}
