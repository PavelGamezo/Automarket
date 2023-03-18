using Automarket.Data;
using Automarket.Data.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.BusinessLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection service, string connectionSctring)
        {
            service.AddDatabase(connectionSctring);
            service.AddAutoMapper(Assembly.GetCallingAssembly(),
                               Assembly.GetExecutingAssembly());

            return service;
        }
    }
}
