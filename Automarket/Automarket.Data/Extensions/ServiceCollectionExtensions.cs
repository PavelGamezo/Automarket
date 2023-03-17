using Automarket.Data.Repositories;
using Automarket.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                                                        {
                                                            options.UseSqlServer(connectionString);
                                                        });
            services.AddScoped<ICarRepository, CarRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
