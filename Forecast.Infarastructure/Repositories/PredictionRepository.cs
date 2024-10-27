using Forecast.Domain.Entities;
using Forecast.Domain.Repositories;
using Forecast.Infarastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Forecast.Infarastructure.Repositories
{
    public class PredictionRepository : IPredictionRepository
    {
        private readonly ForecastDbContext _context;

        public PredictionRepository(ForecastDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prediction>> GetAllAsync()
        {
            return await _context.Predictions.Include(p => p.CurrencyRate).ToListAsync();
        }

        public async Task<Prediction> GetByIdAsync(Guid id)
        {
            return await _context.Predictions.Include(p => p.CurrencyRate)
                                             .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Prediction prediction)
        {
            await _context.Predictions.AddAsync(prediction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Prediction prediction)
        {
            _context.Predictions.Update(prediction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var prediction = await GetByIdAsync(id);
            if (prediction != null)
            {
                _context.Predictions.Remove(prediction);
                await _context.SaveChangesAsync();
            }
        }

        public Task<Prediction> GetPredictionByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task AddPredictionAsync(Prediction prediction)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Prediction>> GetPredictionsByCurrencyRateIdAsync(Guid currencyRateId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Prediction>> GetPredictionsByDateRangeAsync(string currencyCode, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePredictionAsync(Prediction prediction)
        {
            throw new NotImplementedException();
        }
    }
}
