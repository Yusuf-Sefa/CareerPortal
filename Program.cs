using CareerPortal.Context;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using CareerPortal.Repository.Interfaces;
using CareerPortal.Repository;
using CareerPortal.Repository.Repositories;
using CareerPortal.Repository.Interfaces.ICompany;
using CareerPortal.Repository.Queries;
using CareerPortal.Services.Interface;
using CareerPortal.Services;
using FluentValidation;
using CareerPortal.Validators.CompanyValidators;
using CareerPortal.ExceptionHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

Env.Load();

var connectionString = Environment.GetEnvironmentVariable("DB_ConnectionString")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString, npgsqlOptions =>
    {
        // EF Core SQL sorgu üretecine pgvector desteğini ekler
        npgsqlOptions.UseVector();
    });
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyQueries, CompanyQueries>();

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCompanyRequestValidator>();

builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddExceptionHandler<ConflictExceptionHandler>();
builder.Services.AddProblemDetails();

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

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
}

app.UseHttpsRedirection();
// app.UseAuthentication();
// app.UseAuthorization();
app.MapControllers();

app.Run();
