using CaseStudy.Concentrix.Abstraction.Interface;
using CaseStudy.Concentrix.Abstraction.Model;
using CaseStudy.Concentrix.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace CaseStudyTest
{
    public class Tests
    {
        private  Mock<ILogger<OrderController>> _logger;
        private  Mock<IOrderService> _orderService;
        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<OrderController>>();
            _orderService = new Mock<IOrderService>();
        }

        [Test]
        public void Test1()

        {

            //Arrange
            OrderController order = new OrderController(_orderService.Object, _logger.Object);

            Order o = new Order
            {
                BuyerEmail="Vks@gmail.com",
                Id = 1,
                OrderItems = new List<OrderItem> {
                    new OrderItem
                    {
                        Id=1,
                        Price=10,
                        Quantity=100
                    }
                },
                ShipToAddressEntity = new Address
                {
                    City = "a",
                    FirstName = "v",
                    Id = 10,
                    LastName = "d",
                    State = "sa",
                    Street = "d",
                    ZipCode = "dad"
                },
                Total = 10,
            };

            _orderService.Setup(x => x.PlaceOrderAsync(o)).ReturnsAsync(o);
            
            //Act
            var result = order.PlaceOrder(o);

            // Asset
            Assert.AreEqual(o.Id,result.Id);
        }
    }
}