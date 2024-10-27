using Forecast.Application.Services;
using Forecast.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

public static class PredictionEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/predictions");

        // Получение всех прогнозов
        group.MapGet("/", async (PredictionService predictionService) =>
        {
            var predictions = await predictionService.GetAllPredictionsAsync();
            return Results.Ok(predictions);
        });

        // Получение прогноза по ID
        group.MapGet("/{id:guid}", async (PredictionService predictionService, Guid id) =>
        {
            var prediction = await predictionService.GetPredictionByIdAsync(id);
            return prediction != null ? Results.Ok(prediction) : Results.NotFound();
        });

        // Добавление нового прогноза
        group.MapPost("/", async (PredictionService predictionService, [FromBody] PredictionDto predictionDto) =>
        {
            await predictionService.AddPredictionAsync(predictionDto);
            return Results.Created($"/predictions/{predictionDto.Id}", predictionDto);
        });

        // Обновление прогноза
        group.MapPut("/{id:guid}", async (PredictionService predictionService, Guid id, [FromBody] PredictionDto predictionDto) =>
        {
            predictionDto.Id = id;
            await predictionService.UpdatePredictionAsync(predictionDto);
            return Results.NoContent();
        });

        // Удаление прогноза по ID
        group.MapDelete("/{id:guid}", async (PredictionService predictionService, Guid id) =>
        {
            await predictionService.DeletePredictionAsync(id);
            return Results.NoContent();
        });
    }
}
