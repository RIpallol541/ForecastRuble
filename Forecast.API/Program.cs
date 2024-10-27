using Microsoft.EntityFrameworkCore;
using Forecast.Infrastructure.Data; // ����������� � ������ ��������� ���� ������
using Forecast.Application.Services; // ����������� � ����� ��������
using Forecast.Domain.Repositories; // ����������� � ������������
using Forecast.Infrastructure.Repositories; // ����������� � ���������� ������������
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� appsettings.json
var connectionString = builder.Configuration.GetConnectionString("ForecastDb");

// ����������� ��������� ���� ������ ����� ����� ���������� ��� SQLite
builder.Services.AddDbContext<ForecastDbContext>(options =>
    options.UseSqlite(connectionString));

// ����������� ������������
builder.Services.AddScoped<ICurrencyRateRepository, CurrencyRateRepository>();
builder.Services.AddScoped<IPredictionRepository, PredictionRepository>();

// ����������� ��������
builder.Services.AddScoped<CurrencyRateService>();
builder.Services.AddScoped<PredictionService>();

// ��������� ������������ JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

// ��������� AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// ��������� Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Forecast API", Version = "v1" });
});

var app = builder.Build();

// Middleware ��� ��������� ������
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500; // ������������� ��� ��������� 500
        context.Response.ContentType = "application/json";

        var errorResponse = new { Message = "��������� ������. ����������, ���������� �����." };
        await context.Response.WriteAsJsonAsync(errorResponse);
    });
});

// ������������� Swagger ������ � ������ ����������
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Forecast API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();

// ����������� ����������
CurrencyRateEndpoints.MapEndpoints(app);
PredictionEndpoints.MapEndpoints(app);

app.Run();
