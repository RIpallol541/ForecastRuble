using System;
using System.Collections.Generic; // Для использования ICollection

namespace Forecast.Domain.Entities
{
    public class CurrencyRate
    {
        public Guid Id { get; set; }
        public string CurrencyCode { get; set; } // Код валюты (например, "RUB")
        public DateTime Date { get; set; } // Дата курса
        public decimal Rate { get; set; } // Значение курса

        public ICollection<Prediction> Predictions { get; set; } // Связь с прогнозами
    }
}
