using Customers.API.Data;
using Customers.API.Entites;
using Customers.API.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Customers.API.Config;
using Microsoft.Extensions.Options;
using System.Net;

namespace Customers.API.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly HttpClient _httpClient;
        private readonly CustomersApiOptions _customersApiOptions;

        public CustomersService(HttpClient httpClient, IOptions<CustomersApiOptions> customersApiOptions)
        {
            _httpClient = httpClient;
            _customersApiOptions = customersApiOptions.Value;
        }
       
        public async Task<List<Customer>> GetCustomers()
        {
            string url = _customersApiOptions.Endpoint;
            var customersResponse = await _httpClient.GetAsync(url);
            if (customersResponse.StatusCode == HttpStatusCode.NotFound)
                return null;

            var customers = await customersResponse.Content.ReadFromJsonAsync<List<Customer>>();
            return customers != null ? customers : new List<Customer>();
            

        }

        ////public async Task<List<Customer>> GetCustomers_2()
        ////{
        ////    string url = _customersApiOptions.Endpoint;
        ////    var rslt = await _httpClient.GetAsync(url);
        ////    return await CustomersFixture.GetCustomers();

        ////}
    }
}