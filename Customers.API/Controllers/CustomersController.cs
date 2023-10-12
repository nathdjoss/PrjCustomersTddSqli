using Microsoft.AspNetCore.Mvc;
using Customers.API.Data;
using Customers.API.Entites;

namespace Customers.API.Controllers
{
    public class CustomersController : ControllerBase
    {
        
        [HttpGet("customers")]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            var customers = await CustomersFixture.GetCustomers();
           
            return Ok(customers);
            //return BadRequest("Probleme extraction!!");
           

        }

        [HttpGet("customers/{name}")]
        public async Task<ActionResult<Customer>> GetCustomerByName(string name)
        {
            var customers = await CustomersFixture.GetCustomers();
            var customer = customers.FirstOrDefault(x => x.Name == name);
            if(customer == null) 
                return null; 
           
            return Ok(customer);

        }


    }
}
