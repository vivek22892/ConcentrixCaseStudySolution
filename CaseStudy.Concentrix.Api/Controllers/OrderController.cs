using CaseStudy.Concentrix.Abstraction.Interface;
using CaseStudy.Concentrix.Abstraction.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CaseStudy.Concentrix.Api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] Order order)
        {
            try
            {
                _logger.LogDebug("Placing order");
                if (ModelState.IsValid)
                {
                    int orderId = await _orderService.PlaceOrderAsync(order);
                    _logger.LogDebug("Placed order");
                    return Ok(new { OrderId = orderId });
                }
                _logger.LogDebug("Unable to Place");
                return BadRequest(ModelState);

            }
            catch (Exception ex)
            {
                _logger.LogError("Placing order");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders(int page = 1, int pageSize = 10)
        {
            try
            {
                _logger.LogDebug("Getting orders");
                List<Order> orders = await _orderService.GetOrders(page, pageSize);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError("not able find orders");
                return BadRequest("Failed to get Orders:" + ex.Message);
            }

        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            try
            {
                _logger.LogDebug("Getting specific order");
                Order order = await _orderService.GetOrderById(orderId);

                if (order == null)
                {
                    _logger.LogWarning("Order not found");
                    return NotFound();
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError("Not able to find order");
                return BadRequest("Failed to get Order:" + ex.Message); ;
            }
           
        }
    }
}
