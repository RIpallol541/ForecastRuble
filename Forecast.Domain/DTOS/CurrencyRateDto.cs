using System;

namespace Forecast.Domain.Dtos
{
    public class CurrencyRateDto
    {
        public Guid Id { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Rate { get; set; }
        public DateTime Date { get; set; }
    }
}
