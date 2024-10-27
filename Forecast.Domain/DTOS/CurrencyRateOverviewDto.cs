using System.Collections.Generic;
using System;

namespace Forecast.Domain.Dtos
{
    public class CurrencyRateOverviewDto
    {
        public Guid Id { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Rate { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<PredictionDto> Predictions { get; set; }
    }
}
