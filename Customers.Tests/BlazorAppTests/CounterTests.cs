using Bunit;
using Customers.BlazorApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Tests.BlazorAppTests
{
    public class CounterTests : TestContext
    {
        [Fact]
        public void CounterIncrement_ClickCheckValue()
        {
            //arrange
            var cut = RenderComponent<Counter>();

            //Act
            cut.Find("button").Click();

            //Assert
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 3</p>");
        }

        [Fact]
        public void CounterIncrementToto_ClickCheckValue()
        {
            //arrange
            var cut = RenderComponent<Counter>(parameters => parameters.Add(p => p.toto, 3));

            //Act
            cut.Find("button").Click();

            //Assert
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 3</p>");
        }

    }
}
