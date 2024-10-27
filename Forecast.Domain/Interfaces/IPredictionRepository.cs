using Forecast.Domain.Entities;

public interface IPredictionRepository
{
    Task<IEnumerable<Prediction>> GetAllPredictionsAsync(); // Уже есть
    Task<Prediction> GetPredictionByIdAsync(Guid id); // Добавьте метод для получения предсказания по Id
    Task<IEnumerable<Prediction>> GetPredictionsByCurrencyRateIdAsync(Guid currencyRateId); // Для получения предсказаний по Id валютного курса
    Task AddPredictionAsync(Prediction prediction); // Уже есть
    Task UpdatePredictionAsync(Prediction prediction); // Уже есть
    Task DeletePredictionAsync(Guid id); // Уже есть
}
