using Customers.API.Entites;
namespace Customers.API.Interfaces
{
    public interface ICustomersService
    {
        Task<List<Customer>> GetCustomers();

        ////Task<List<Customer>> GetCustomers_2();
    }
}
