using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast.Domain.Entities
{
    public class Prediction
    {
        public Guid Id { get; set; }
        public Guid CurrencyRateId { get; set; } // Идентификатор связанного курса валюты
        public DateTime PredictedDate { get; set; } // Дата, на которую производится прогноз
        public decimal PredictedRate { get; set; } // Прогнозируемое значение курса

        public CurrencyRate CurrencyRate { get; set; } // Связь с курсом валюты
    }
}
