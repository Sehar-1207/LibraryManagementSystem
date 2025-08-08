using Application.Mappings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extension
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAppExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            // Register MediatR for CQRS
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            //services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
