using Microsoft.EntityFrameworkCore;
using RaqamliAvlod.DataAccess.DbContexts;
using RaqamliAvlod.DataAccess.Interfaces;
using RaqamliAvlod.DataAccess.Repositories;

namespace RaqamliAvlod.Api.Configurations.Dependencies
{
    public static class DataAccessLayerConfiguration
    {
        public static void AddDataAccessLayer(this WebApplicationBuilder builder)
        {
            string connectionString = builder.Configuration.GetConnectionString("HerokuProductionDb");
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
