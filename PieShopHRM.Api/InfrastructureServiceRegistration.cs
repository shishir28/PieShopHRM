using PieShopHRM.Api.Repositories;
using Microsoft.EntityFrameworkCore;
namespace PieShopHRM.Api
{
    public static class InfrastructureServiceRegistration
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }

        public static void MigrateDB(this IServiceProvider svcProvider)
        {
            var services = svcProvider.CreateScope().ServiceProvider;
            var dbContext = services.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();            
        }

    }
}
