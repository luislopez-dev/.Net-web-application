using Application.Services;
using Business.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer((config.GetConnectionString("app")));
            }
        );
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IServiceManager, ServiceManager>();
        
        return services;
    }

}