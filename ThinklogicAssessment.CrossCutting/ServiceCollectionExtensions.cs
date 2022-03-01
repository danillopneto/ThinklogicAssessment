using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThinklogicAssessment.Infra.Contexts;
using ThinklogicAssessment.Infra.Repositories;
using ThinklogicAssessment.Interfaces.Repositories;
using ThinklogicAssessment.Interfaces.UseCases;
using ThinklogicAssessment.UseCases.UseCases;

namespace ThinklogicAssessment.CrossCutting
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEventRepository, EventRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGetEventsByDateUseCase, GetEventsByDateUseCase>();
            services.AddScoped<ISaveEventUseCase, SaveEventUseCase>();            

            return services;
        }
    }
}
