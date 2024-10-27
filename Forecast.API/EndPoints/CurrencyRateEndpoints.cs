using Forecast.Application.Services;
using Forecast.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

public static class CurrencyRateEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/currency-rates");

        // Получение всех курсов валют
        group.MapGet("/", async (CurrencyRateService currencyRateService) =>
        {
            var rates = await currencyRateService.GetAllCurrencyRatesAsync();
            return Results.Ok(rates);
        });

        // Получение информации о конкретном курсе валюты по ID
        group.MapGet("/{id:guid}", async (CurrencyRateService currencyRateService, Guid id) =>
        {
            var rate = await currencyRateService.GetCurrencyRateByIdAsync(id);
            return rate != null ? Results.Ok(rate) : Results.NotFound();
        });

        // Добавление нового курса валюты
        group.MapPost("/", async (CurrencyRateService currencyRateService, [FromBody] CurrencyRateDto currencyRateDto) =>
        {
            await currencyRateService.AddCurrencyRateAsync(currencyRateDto);
            return Results.Created($"/currency-rates/{currencyRateDto.Id}", currencyRateDto);
        });

        // Обновление информации о курсе валюты
        group.MapPut("/{id:guid}", async (CurrencyRateService currencyRateService, Guid id, [FromBody] CurrencyRateDto currencyRateDto) =>
        {
            currencyRateDto.Id = id;
            await currencyRateService.UpdateCurrencyRateAsync(currencyRateDto);
            return Results.NoContent();
        });

        // Удаление курса валюты по ID
        group.MapDelete("/{id:guid}", async (CurrencyRateService currencyRateService, Guid id) =>
        {
            await currencyRateService.DeleteCurrencyRateAsync(id);
            return Results.NoContent();
        });
    }
}
