using Application.Contracts.Interfaces;
using Infrastructure.DataAccess;
using Infrastructure.Implementation.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IBook, BookRepository>();
            services.AddScoped<ICategory, CategoryRepository>();
            services.AddScoped<IMember, MemberRepository>();
            services.AddScoped<IBorrow, BorrowRepository>();
            services.AddScoped<IReservation, ReservationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
