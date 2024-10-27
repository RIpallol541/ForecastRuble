using AutoMapper;
using Forecast.Domain.Dtos;
using Forecast.Domain.Entities; 

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Сопоставление между CurrencyRate и CurrencyRateDto
        CreateMap<CurrencyRate, CurrencyRateDto>().ReverseMap();

        // Сопоставление между Prediction и PredictionDto
        CreateMap<Prediction, PredictionDto>().ReverseMap();
    }
}
