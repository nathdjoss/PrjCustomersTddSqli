using Customers.API.Controllers;
using Customers.API.Entites;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Tests
{
    public class CustomersControllerTest
    {
        [Fact]
        public async Task CustomerController_GetCustomers_Return_200()
        {
            //arrange
            var controller = new CustomersController();

            //act
            var actionResult = await controller.GetCustomers();
            OkObjectResult okObjectResult = actionResult.Result.As<OkObjectResult>();

            //assert
            okObjectResult.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task CustomerController_GetCustomers_Return_Count_2()
        {
            //arrange
            var controller = new CustomersController();

            //act
            var actionResult = await controller.GetCustomers();
            OkObjectResult okObjectResult = actionResult.Result.As<OkObjectResult>();
            List<Customer> model = okObjectResult.Value.As<List<Customer>>();

            //assert
            model.Should().NotBeNull();
            model.Count.Should().Be(2);
        }

        [Fact]
        public async Task CustomerController_GetCustomerByName_Return_ActionResult()
        {
            //arrange
            var controller = new CustomersController();

            //act
            var actionResult = await controller.GetCustomerByName("Nathaniel");
            
            //assert
            actionResult.Should().BeOfType<ActionResult<Customer>>();

        }

        [Fact]
        public async Task CustomerController_GetCustomerByName_Return_Null()
        {
            //arrange
            var controller = new CustomersController();

            //act
            var actionResult = await controller.GetCustomerByName("qsdfgh");

            //assert
            actionResult.Should().BeNull();

        }

        [Fact]
        public async Task CustomerController_GetCustomerByName_Return_IdNathaniel()
        {
            //arrange
            var controller = new CustomersController();

            //act
            var actionResult = await controller.GetCustomerByName("Nathaniel");
            OkObjectResult okObjectResult = actionResult.Result.As<OkObjectResult>();  
            Customer model = okObjectResult.Value.As<Customer>(); 

            //assert
            model.Should().NotBeNull();
            model.Id.Should().Be(2);
        }

    }
}