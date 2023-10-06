using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NativeTunes.Application.Contracts.Persistence;
using NativeTunes.Application.Contracts.Services;
using NativeTunes.Infrastructure.Interceptors;
using NativeTunes.Infrastructure.Persistence;
using NativeTunes.Infrastructure.Persistence.Repositories;
using NativeTunes.Infrastructure.Services;
using NativeTunes.Infrastructure.Services.Authentication;
using System.Text;

namespace NativeTunes.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddPersistence(configuration)
                    .AddAuth(configuration);
            return services;
        }
        private static IServiceCollection AddPersistence(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<NativeTunesDbContext>(options =>
            {
                // TODO: Set Connection String
                var connectionString = configuration.GetConnectionString("DatabaseConnectionString");
                // options.UseSqlServer(connectionString);
                options.UseSqlite(connectionString);
            });

            services.AddScoped<PublishDomainEventInterceptor>();
            services.AddScoped<AuditableInterceptor>();

            // Repositories
            services.AddScoped<IPodcastRepository, PodcastRepository>();

            // Azure Blob Service
            services.AddOptions<AzureBlobSettings>()
               .BindConfiguration(AzureBlobSettings.SectionName)
               .ValidateDataAnnotations()
               .ValidateOnStart();
            services.AddSingleton<IStorageService, AzureBlobService>();

            return services;
        }
        private static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);
            services.AddSingleton(Options.Create(jwtSettings));
            if (string.IsNullOrWhiteSpace(jwtSettings.Secret)
            || jwtSettings.ExpirationTimeInMinutes <= 0
            || string.IsNullOrWhiteSpace(jwtSettings.Issuer)
            || string.IsNullOrWhiteSpace(jwtSettings.Audience))
            {
                throw new InvalidOperationException("Invalid/Missing JwtSettings configuration.");
            }

            services.AddSingleton<IJwtGenerator, JwtGenerator>();
            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = jwtSettings.Issuer,
                   ValidAudience = jwtSettings.Audience,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
               };

               options.Events = new JwtBearerEvents()
               {
                   OnChallenge = context =>
                   {
                       context.HandleResponse();
                       context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                       context.Response.ContentType = "application/json";

                       var unauthorizedProblem = new ProblemDetails() { Status = context.Response.StatusCode, Type = "Unauthorized" };

                       return context.Response.WriteAsJsonAsync(unauthorizedProblem);
                   },
                   OnForbidden = context =>
                   {
                       context.Response.StatusCode = StatusCodes.Status403Forbidden;
                       context.Response.ContentType = "application/json";

                       var forbiddenProblem = new ProblemDetails() { Status = context.Response.StatusCode, Type = "Forbidden" };
                       return context.Response.WriteAsJsonAsync(forbiddenProblem);
                   }
               };
           });
            services.AddAuthorization();
            return services;
        }

    }
}
