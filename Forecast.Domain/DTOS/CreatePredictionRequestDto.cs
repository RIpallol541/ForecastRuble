using System;

namespace Forecast.Domain.Dtos
{
    public class CreatePredictionRequestDto
    {
        public Guid CurrencyRateId { get; set; }
        public DateTime PredictedDate { get; set; }
        public decimal PredictedRate { get; set; }
    }
}
