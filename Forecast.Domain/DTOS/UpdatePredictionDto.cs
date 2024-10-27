using System;

namespace Forecast.Domain.Dtos
{
    public class UpdatePredictionDto
    {
        public Guid Id { get; set; }
        public decimal PredictedRate { get; set; }
    }
}
