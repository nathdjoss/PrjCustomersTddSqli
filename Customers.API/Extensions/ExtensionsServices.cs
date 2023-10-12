
using Customers.API.Config;
using Customers.API.Interfaces;
using Customers.API.Services;
namespace Customers.API.Extensions
{
    public static class ExtensionsServices
    {
        public static IServiceCollection AddExtensionDeMesServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<ICustomersService, CustomersService>();

            services.AddHttpClient<ICustomersService, CustomersService>();

            services.Configure<CustomersApiOptions>(config.GetSection("CustomersApiOptions"));

            return services;
        }
    }
}
