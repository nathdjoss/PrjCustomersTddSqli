using Customers.API.Entites;
namespace Customers.API.Data
{
    public static class CustomersFixture
    {
        public async static Task<List<Customer>> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            await Task.Run(() => 
            {
                customers = new()
                {
                    new Customer { Id = 1, Name = "Frater" },
                    new Customer { Id = 2, Name = "Nathaniel" }
                };
            });
            

            return  customers;

        }
    }
}
