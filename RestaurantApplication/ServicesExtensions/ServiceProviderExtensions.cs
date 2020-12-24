using BLL.Interfaces;
using BLL.Services;
using DataLayer.Implementations;
using DataLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApplication.ServicesExtensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddRestaurantService(this IServiceCollection services)
        {
            services.AddTransient<IRestaurantService, RestaurantService>();
        }

        public static void AddEFUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
        }
    }
}
