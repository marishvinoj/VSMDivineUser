using Microsoft.Extensions.DependencyInjection;
using Services.Implementations;
using VSMDivineUser.Repository.IRepositories;
using VSMDivineUser.Repository.Repositories;
using VSMDivineUser.Service.Services;
using VSMDivineUser.UnitOfWork;

namespace VSMDivineUser.Service
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IUserRoleMappingService, UserRoleMappingService>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}
