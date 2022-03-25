using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Nihongo.Api.Filters;
using Nihongo.Application.Interfaces.Reposiroty;
using Nihongo.Application.Interfaces.Services;
using Nihongo.Entites.Models;
using Nihongo.Repository;
using Nihongo.Repository.Services;
using System.Text;
using Nihongo.Api.Mappings;
using Nihongo.Shared.Settings;
using Nihongo.Api.Settings;
using Nihongo.Shared.Interfaces.Services;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace Nihongo.Api.Extensions
{
    public static class ServiceExtentions
    {
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NihongoContext>(o =>
                    o.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RoadToDevops", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                                  Enter 'Bearer' [space] and then your token in the text input below.
                                  \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                      },
                      new List<string>()
                    }
                });
            });
        }
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiJWTSettings>(configuration.GetSection("JWTSettings"));
            services.Configure<SharedAppSettings>(configuration.GetSection("AppSettings"));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                RequireExpirationTime = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:key"]))
            };

            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = tokenValidationParameters;
                });
        }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("enableCORS", builder =>
                {
                    builder.WithOrigins("http://localhost:4200");
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                    builder.AllowCredentials();
                });
            });
        }
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
        public static void ConfigureAppServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPropertyService, PropertyService>();



            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ICookieService, CookieService>();
            services.AddScoped<IJwtService, JwtService>();
        }
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            }).CreateMapper());
        }
        public static void ConfigureValidationActionFilter(this IServiceCollection services)
        {
            services.AddScoped<ValidateFilterAttribute>();
        }
        public static void ConfigureValidateEntityExistsFilter(this IServiceCollection services)
        {
            services.AddScoped<ValidateEntityExistsAttribute<Account>>();
            services.AddScoped<ValidateEntityExistsAttribute<Property>>();
        }
    }
}
