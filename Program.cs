using CareerPortal.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString, npgsqlOptions =>
    {
        // EF Core SQL sorgu üretecine pgvector desteğini ekler
        npgsqlOptions.UseVector();
    });
});

/*
builder.Services.AddHttpClient<OpenAiLlmProvider>();
builder.Services.AddHttpClient<GeminiLlmProvider>();
builder.Services.AddHttpClient<OllamaLlmProvider>();

// Factory Pattern: Runtime'da appsettings.json'a göre provider seçecek servis
builder.Services.AddScoped<ILlmProviderFactory, LlmProviderFactory>();

// Concrete Agent Kayıtları (Infrastructure / Application Katmanı Ajanları)
builder.Services.AddScoped<ICvParserAgent, CvParserAgent>();
builder.Services.AddScoped<IAtsCoachAgent, AtsCoachAgent>();*/


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
// app.UseAuthentication();
// app.UseAuthorization();
app.MapControllers();

app.Run();
