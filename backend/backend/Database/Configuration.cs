using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace backend.Database
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureDB(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            var services = builder.Services;
            services
                .SetupDbConnection(configuration);

            return services;
        }

        public static void SetUpDb(this WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<RoomDbContext>();

            dbContext
                .EnsureMigrated()
                .EnsureDbCreated();
        }

        private static IServiceCollection SetupDbConnection(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<RoomDbContext>(
                    opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        private static RoomDbContext EnsureDbCreated(this RoomDbContext context)
        {
            context.Database.EnsureCreated();
            return context;
        }

        private static RoomDbContext EnsureMigrated(this RoomDbContext context)
        {
            context.Database.Migrate();
            return context;
        }

    }


}
