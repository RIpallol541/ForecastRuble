using AutoMapper;
using Forecast.Domain.Dtos;
using Forecast.Domain.Entities;
using Forecast.Domain.Repositories;

namespace Forecast.Application.Services
{
    public class PredictionService
    {
        private readonly IPredictionRepository _predictionRepository;
        private readonly ICurrencyRateRepository _currencyRateRepository;
        private readonly IMapper _mapper;

        public PredictionService(IPredictionRepository predictionRepository, ICurrencyRateRepository currencyRateRepository, IMapper mapper)
        {
            _predictionRepository = predictionRepository;
            _currencyRateRepository = currencyRateRepository;
            _mapper = mapper;
        }

        // Получение всех прогнозов
        public async Task<IEnumerable<PredictionDto>> GetAllPredictionsAsync()
        {
            var predictions = await _predictionRepository.GetAllPredictionsAsync(); // Исправлено имя метода
            return _mapper.Map<IEnumerable<PredictionDto>>(predictions);
        }

        // Получение прогноза по ID
        public async Task<PredictionDto> GetPredictionByIdAsync(Guid id)
        {
            var prediction = await _predictionRepository.GetPredictionByIdAsync(id); // Исправлено имя метода
            return _mapper.Map<PredictionDto>(prediction);
        }

        // Добавление нового прогноза
        public async Task AddPredictionAsync(PredictionDto predictionDto)
        {
            var currencyRate = await _currencyRateRepository.GetCurrencyRateByIdAsync(predictionDto.CurrencyRateId);
            if (currencyRate == null)
            {
                throw new Exception("Связанный курс валюты не найден.");
            }

            var prediction = _mapper.Map<Prediction>(predictionDto);
            prediction.Id = Guid.NewGuid(); // Генерация нового Id
            await _predictionRepository.AddPredictionAsync(prediction); // Исправлено имя метода
        }

        // Обновление прогноза
        public async Task UpdatePredictionAsync(PredictionDto predictionDto)
        {
            var prediction = _mapper.Map<Prediction>(predictionDto);
            await _predictionRepository.UpdatePredictionAsync(prediction); // Исправлено имя метода
        }

        // Удаление прогноза
        public async Task DeletePredictionAsync(Guid id)
        {
            await _predictionRepository.DeletePredictionAsync(id); // Исправлено имя метода
        }

        // Получение всех прогнозов для указанного курса валюты
        public async Task<IEnumerable<PredictionDto>> GetPredictionsByCurrencyRateIdAsync(Guid currencyRateId)
        {
            var predictions = await _predictionRepository.GetPredictionsByCurrencyRateIdAsync(currencyRateId); // Исправлено имя метода
            return _mapper.Map<IEnumerable<PredictionDto>>(predictions);
        }
    }
}
