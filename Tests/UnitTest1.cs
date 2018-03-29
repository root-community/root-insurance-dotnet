using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.Extensions;
using RootSDK;
using RootSDK.Insurance;
using RootSDK.Insurance.Models;
using RootSDK.Insurance.Services;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ListGadgetModelsShouldRetunAListOfGadgetModels()
        {
            // Arrange
            var mockInsuranceClient= Substitute.For<IRootInsuranceClient>();
            var mockQuoteService= Substitute.For<IQuoteService>();
            var mock = new RootClient(mockInsuranceClient);
            mockInsuranceClient.ReturnsForAll(mockQuoteService);
            
            var taskResponse= Substitute.For<IList<Gadget>>();
            
            mockQuoteService.ReturnsForAll(taskResponse);

            // foo = Act
            var foo = mock.Insurance.Quotes.ListGadgetModels();

            // Assert
            Assert.Equal(taskResponse, foo.Result);
        }
    }
}