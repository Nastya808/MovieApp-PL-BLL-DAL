using Microsoft.Extensions.DependencyInjection;
using MovieApp.DAL.Interfaces;

namespace Soccer.BLL.Infrastructure
{
    public static class UnitOfWorkServiceExtensions
    {
        public static void AddUnitOfWorkService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork>();
        }
    }
}