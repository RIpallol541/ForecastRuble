using System;

namespace Forecast.Domain.Dtos
{
    public class PredictionDto
    {
        public Guid Id { get; set; }
        public Guid CurrencyRateId { get; set; }
        public DateTime PredictedDate { get; set; }
        public decimal PredictedRate { get; set; }
    }
}
