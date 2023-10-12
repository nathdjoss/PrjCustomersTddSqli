using Customers.API.Data;
using Customers.API.Entites;
using Customers.API.Services;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using Customers.API.Config;

namespace Customers.Tests
{
    public class CustomersServiceTest
    {
        
        
        [Fact]
        public async Task CustomersService_Return()
        {
            //arrange
            var expectedResponse = await CustomersFixture.GetCustomers();
            var handlerMock = MockHttpMessageHandler<Customer>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var endpoint = "https://www.google.com/";
            var config = Options.Create(new CustomersApiOptions { Endpoint = endpoint });
            var svc = new CustomersService(httpClient, config);

            //act
            await svc.GetCustomers();

            //assert
            handlerMock.Protected()
                .Verify("SendAsync", 
                    Times.Exactly(1),
                    ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                    ItExpr.IsAny<CancellationToken>()
                    );
            
        }
        
        [Fact]
        public async Task CustomersService_GetCustomers_Return_ListProduit()
        {
            //arrange
            var expectedResponse =await CustomersFixture.GetCustomers();
            var handlerMock = MockHttpMessageHandler<Customer>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var endpoint = "https://www.google.com/";
            var config = Options.Create(new CustomersApiOptions { Endpoint = endpoint });
            var svc = new CustomersService(httpClient, config);

            //act
            var result = await svc.GetCustomers();

            //assert
            result.Should().BeOfType<List<Customer>>();

        }
        
        
        [Fact]
        public async Task CustomersService_GetCustomers_Return_CountProduit()
        {
            //arrange
            var expectedResponse = await CustomersFixture.GetCustomers();
            var handlerMock = MockHttpMessageHandler<Customer>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var endpoint = "https://www.google.com/";
            var config = Options.Create(new CustomersApiOptions { Endpoint = endpoint });
            var svc = new CustomersService(httpClient, config);

            //act
            var result = await svc.GetCustomers();

            //assert
            result.Count.Should().Be(expectedResponse.Count);

        }
        
        
        [Fact]
        public async Task CustomersService_GetCustomers_Return_InvokesExternalUrl()
        {
            //arrange
            var expectedResponse = await CustomersFixture.GetCustomers();
            var endpoint = "https://www.google.com/";
            var handlerMock = MockHttpMessageHandler<Customer>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var config = Options.Create(new CustomersApiOptions { Endpoint = endpoint });
            var svc = new CustomersService(httpClient, config);

            //act
            var result = await svc.GetCustomers();

            //assert
            result.Count.Should().Be(expectedResponse.Count);

        }


    }
}
