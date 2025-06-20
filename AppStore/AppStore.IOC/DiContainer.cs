using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Aplication.Services.Implements;
using AppStore.Aplication.Services.Interfaces;
using AppStore.Data.Repositoreis;
using AppStore.Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace AppStore.IOC
{
    public static class DiContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository  , AccountRepository>();
            services.AddScoped<IAccountServices  , AccountServices>();
            services.AddScoped<IProductGroupRepository  , ProductGroupRepository>();
            services.AddScoped<IProductGroupServices, ProductGroupServices>();


        }
    }
}
