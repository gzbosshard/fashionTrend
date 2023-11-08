using fashionTrend.Domain.Interfaces;
using fashionTrend.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceExtensions
{

    public static void ConfigurePersistenceApp(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Sqlite");

        services.AddDbContext<AppDbContext>(
            opt => opt.UseSqlite(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IFornecedorRepository, FornecedorRepository>();

    }
}
