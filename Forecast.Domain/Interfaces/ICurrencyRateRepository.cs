using Forecast.Domain.Entities;
using System.Threading.Tasks;
using System;

namespace Forecast.Domain.Repositories
{
    public interface ICurrencyRateRepository
    {
        Task<CurrencyRate> GetCurrencyRateByIdAsync(Guid id);
        Task AddCurrencyRateAsync(CurrencyRate currencyRate);
        Task<CurrencyRate> GetCurrencyRateAsync(string currencyCode, DateTime date);
        Task<CurrencyRate> GetLatestCurrencyRateAsync(string currencyCode); // Метод для получения последнего курса по коду валюты
        Task UpdateCurrencyRateAsync(CurrencyRate currencyRate);
    }
}
