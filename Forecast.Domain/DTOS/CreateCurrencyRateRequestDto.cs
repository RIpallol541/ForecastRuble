using System;

namespace Forecast.Domain.Dtos
{
    public class CreateCurrencyRateRequestDto
    {
        public string CurrencyCode { get; set; }
        public decimal Rate { get; set; }
        public DateTime Date { get; set; }
    }
}
