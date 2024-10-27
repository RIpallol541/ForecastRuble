using Forecast.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Forecast.Domain.Repositories
{
    public interface IPredictionRepository
    {
        Task<Prediction> GetPredictionByIdAsync(Guid id);
        Task AddPredictionAsync(Prediction prediction);
        Task<IEnumerable<Prediction>> GetPredictionsByCurrencyRateIdAsync(Guid currencyRateId);
        Task<IEnumerable<Prediction>> GetPredictionsByDateRangeAsync(string currencyCode, DateTime startDate, DateTime endDate);
        Task UpdatePredictionAsync(Prediction prediction);
    }
}
