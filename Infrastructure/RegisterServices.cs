using Application.Common.Repositories;
using Domain.Abstractions;
using Infrastructure.Abstractions;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class RegisterServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configurations)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    configurations.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)
                );
            });

            //services.AddDbContext<ApplicationDbContext>(options =>
            //{
            //    options.UseNpgsql(
            //        configuration.GetConnectionString("DefaultConnection"),
            //        builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            //    );
            //});

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWebinarRepository, WebinarRepository>();

            return services;
        }
    }
}
