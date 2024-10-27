using AutoMapper;
using Forecast.Domain.Dtos;
using Forecast.Domain.Entities;
using Forecast.Domain.Repositories;

namespace Forecast.Application.Services
{
    public class CurrencyRateService
    {
        private readonly ICurrencyRateRepository _currencyRateRepository;
        private readonly IMapper _mapper;

        public CurrencyRateService(ICurrencyRateRepository currencyRateRepository, IMapper mapper)
        {
            _currencyRateRepository = currencyRateRepository;
            _mapper = mapper;
        }

        // Получение всех курсов валют
        public async Task<IEnumerable<CurrencyRateDto>> GetAllCurrencyRatesAsync()
        {
            var rates = await _currencyRateRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CurrencyRateDto>>(rates);
        }

        // Получение курса валюты по ID
        public async Task<CurrencyRateDto> GetCurrencyRateByIdAsync(Guid id)
        {
            var rate = await _currencyRateRepository.GetCurrencyRateByIdAsync(id); // Исправлено имя метода
            return _mapper.Map<CurrencyRateDto>(rate);
        }

        // Добавление нового курса валюты
        public async Task AddCurrencyRateAsync(CurrencyRateDto currencyRateDto)
        {
            var currencyRate = _mapper.Map<CurrencyRate>(currencyRateDto);
            currencyRate.Id = Guid.NewGuid(); // Генерация нового Id
            await _currencyRateRepository.AddCurrencyRateAsync(currencyRate); // Исправлено имя метода
        }

        // Обновление существующего курса валюты
        public async Task UpdateCurrencyRateAsync(CurrencyRateDto currencyRateDto)
        {
            var currencyRate = _mapper.Map<CurrencyRate>(currencyRateDto);
            await _currencyRateRepository.UpdateCurrencyRateAsync(currencyRate); // Исправлено имя метода
        }

        // Удаление курса валюты
        public async Task DeleteCurrencyRateAsync(Guid id)
        {
            await _currencyRateRepository.DeleteCurrencyRateAsync(id); // Исправлено имя метода
        }

        // Получение последнего курса валюты по коду
        public async Task<CurrencyRateDto> GetLatestCurrencyRateAsync(string currencyCode)
        {
            var rate = await _currencyRateRepository.GetLatestCurrencyRateAsync(currencyCode);
            return _mapper.Map<CurrencyRateDto>(rate);
        }

        // Получение курса валюты по коду и дате
        public async Task<CurrencyRateDto> GetCurrencyRateByDateAsync(string currencyCode, DateTime date)
        {
            var rate = await _currencyRateRepository.GetCurrencyRateAsync(currencyCode, date);
            return _mapper.Map<CurrencyRateDto>(rate);
        }
    }
}
