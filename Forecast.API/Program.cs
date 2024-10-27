using Microsoft.EntityFrameworkCore;
using Forecast.Infrastructure.Data; // Подключение к вашему контексту базы данных
using Forecast.Application.Services; // Подключение к вашим сервисам
using Forecast.Domain.Repositories; // Подключение к репозиториям
using Forecast.Infrastructure.Repositories; // Подключение к реализации репозиториев
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Получаем строку подключения из appsettings.json
var connectionString = builder.Configuration.GetConnectionString("ForecastDb");

// Регистрация контекста базы данных через метод расширения для SQLite
builder.Services.AddDbContext<ForecastDbContext>(options =>
    options.UseSqlite(connectionString));

// Регистрация репозиториев
builder.Services.AddScoped<ICurrencyRateRepository, CurrencyRateRepository>();
builder.Services.AddScoped<IPredictionRepository, PredictionRepository>();

// Регистрация сервисов
builder.Services.AddScoped<CurrencyRateService>();
builder.Services.AddScoped<PredictionService>();

// Настройка сериализации JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

// Настройка AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Настройка Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Forecast API", Version = "v1" });
});

var app = builder.Build();

// Middleware для обработки ошибок
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500; // Устанавливаем код состояния 500
        context.Response.ContentType = "application/json";

        var errorResponse = new { Message = "Произошла ошибка. Пожалуйста, попробуйте позже." };
        await context.Response.WriteAsJsonAsync(errorResponse);
    });
});

// Использование Swagger только в режиме разработки
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Forecast API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Регистрация эндпоинтов
CurrencyRateEndpoints.MapEndpoints(app);
PredictionEndpoints.MapEndpoints(app);

app.Run();
