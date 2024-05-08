using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieAPI.Application.Auth;
using MovieAPI.Application.Mappers;
using MovieAPI.Domain.Entities;
using MovieAPI.Infrastructure.Data.Context;
using MovieAPI.WebAPI.AutoFac;
using MovieAPI.WebAPI.Middleware;
using MovieAPI.WebAPI.Middlewares;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System.Text;
using FluentValidation.AspNetCore;
using MovieAPI.Application.Validators.UserValidators;

var builder = WebApplication.CreateBuilder(args);
ConfigureLogging();
var config = builder.Configuration;

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(x => x.RegisterModule(new AutoFacModule()));

builder.Services.AddControllers()
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<UserRegisterContractValidator>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(UserMapperProfile).Assembly);

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddDbContext<MovieAPIDbContext>(builder =>
{
    builder.UseSqlServer(config.GetConnectionString("MSSqlConnection"));
});

builder.Services.AddProblemDetails();

JwtConfig jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();
builder.Services.Configure<JwtConfig>(config.GetSection("JwtConfig"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfig.Issuer,
        ValidAudience = jwtConfig.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig.Secret)),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RequestResponseLoggingMiddleware>();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureLogging()
{
    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{environment}.json", optional: true)
        .Build();

    Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .Enrich.WithExceptionDetails()
        .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration["Elasticsearch:Uri"]))
        {
            AutoRegisterTemplate = true,
            IndexFormat = "log-{0:yyyy.MM.dd}"
        })
        .Enrich.WithProperty("Environment", environment)
        .ReadFrom.Configuration(configuration)
        .CreateLogger();
};
