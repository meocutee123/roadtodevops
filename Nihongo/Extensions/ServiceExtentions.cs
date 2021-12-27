using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Nihongo.Api.Filters;
using Nihongo.Application.Common.Mappings;
using Nihongo.Application.Repository;
using Nihongo.Entites.Models;
using Nihongo.Repository;

namespace Nihongo.Api.Extensions
{
    public static class ServiceExtentions
    {
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NihongoContext>(o =>
                    o.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection")));
        }
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            }).CreateMapper());
        }
        public static void ConfigureMicrosoftWebApiAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMicrosoftIdentityWebApiAuthentication(configuration);
        }
        public static void ConfigureValidationActionFilter(this IServiceCollection services)
        {
            services.AddScoped<ValidateFilterAttribute>();
        }
        public static void ConfigureValidateEntityExistsFilter(this IServiceCollection services)
        {
            services.AddScoped<ValidateEntityExistsAttribute<Kanji>>();
        }
    }
}
