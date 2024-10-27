using Forecast.Domain.Entities;
using Forecast.Domain.Repositories;
using Forecast.Infarastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forecast.Infarastructure.Repositories
{
    public class CurrencyRateRepository : ICurrencyRateRepository
    {
        private readonly ForecastDbContext _context;

        public CurrencyRateRepository(ForecastDbContext context)
        {
            _context = context;
        }

        // Получение всех валютных курсов
        public async Task<IEnumerable<CurrencyRate>> GetAllAsync()
        {
            return await _context.CurrencyRates.Include(cr => cr.Predictions).ToListAsync();
        }

        // Получение курса валюты по ID
        public async Task<CurrencyRate> GetCurrencyRateByIdAsync(Guid id)
        {
            return await _context.CurrencyRates.Include(cr => cr.Predictions)
                                               .FirstOrDefaultAsync(cr => cr.Id == id);
        }

        // Добавление нового валютного курса
        public async Task AddCurrencyRateAsync(CurrencyRate currencyRate)
        {
            await _context.CurrencyRates.AddAsync(currencyRate);
            await _context.SaveChangesAsync();
        }

        // Получение курса валюты по коду и дате
        public async Task<CurrencyRate> GetCurrencyRateAsync(string currencyCode, DateTime date)
        {
            return await _context.CurrencyRates
                .FirstOrDefaultAsync(cr => cr.CurrencyCode == currencyCode && cr.Date == date);
        }

        // Получение последнего курса валюты по коду
        public async Task<CurrencyRate> GetLatestCurrencyRateAsync(string currencyCode)
        {
            return await _context.CurrencyRates
                .Where(cr => cr.CurrencyCode == currencyCode)
                .OrderByDescending(cr => cr.Date)
                .FirstOrDefaultAsync();
        }

        // Обновление существующего курса валюты
        public async Task UpdateCurrencyRateAsync(CurrencyRate currencyRate)
        {
            var existingCurrencyRate = await GetCurrencyRateByIdAsync(currencyRate.Id);

            if (existingCurrencyRate != null)
            {
                existingCurrencyRate.Rate = currencyRate.Rate; // Обновляем курс
                _context.CurrencyRates.Update(existingCurrencyRate);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Currency rate not found for update.");
            }
        }

        // Удаление валютного курса по ID
        public async Task DeleteCurrencyRateAsync(Guid id)
        {
            var currencyRate = await GetCurrencyRateByIdAsync(id);
            if (currencyRate != null)
            {
                _context.CurrencyRates.Remove(currencyRate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
