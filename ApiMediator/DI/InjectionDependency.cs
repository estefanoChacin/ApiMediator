using ApiMediator.Application.Command;
using ApiMediator.Domain.Context;
using ApiMediator.Domain.Interfaces;
using ApiMediator.Domain.Model;
using ApiMediator.Infrastructure.Model;
using ApiMediator.Infrastructure.Repository;
using MediatR;

namespace ApiMediator.DI
{
    public static class InjectionDependency
    {
        public static IServiceCollection AddInjectionDependency(this IServiceCollection services, IConfiguration configuration)
        {
            // Add your dependency injection registrations here
            services.AddMediatR(typeof(UserCreateCommand).Assembly);
            services.Configure<DatabaseSetting>(configuration.GetSection("DatabaseSetting"));
            services.AddScoped<IMongoDbContext, MongoDbContext>();
            services.AddScoped(typeof(IDBRepository<UserModel>), typeof(DBRepository<UserModel>));
            services.AddScoped(typeof(IDBRepository<ProductModel>), typeof(DBRepository<ProductModel>));
            return services;
        }
    }
}