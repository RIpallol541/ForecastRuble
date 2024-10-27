using System;

namespace Forecast.Domain.Dtos
{
    public class UpdateCurrencyRateDto
    {
        public Guid Id { get; set; }
        public decimal Rate { get; set; }
        public DateTime Date { get; set; }
    }
}
