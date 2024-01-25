using CaseStudy.Concentrix.Abstraction.Interface;
using CaseStudy.Concentrix.Abstraction.Model;
using Serilog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Concentrix.Application
{
    public class OrderService : IOrderService
    {
        private readonly ConcurrentBag<Order> orderQueue = new ConcurrentBag<Order>();
        private readonly List<Order> orderList = new List<Order>();

        private readonly IOrderStorage _OrderStorage;
        private readonly ILogger _logger = Log.Logger.ForContext<OrderService>();
        public OrderService(ILogger logger,IOrderStorage orderStorage)
        {
            _OrderStorage = orderStorage?? throw new ArgumentNullException(nameof(orderStorage));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> PlaceOrderAsync(Order order)
        {
            // Add order to the queue for further processing
            //orderQueue.Add(order);
            //return order.Id;
            return await _OrderStorage.PlaceOrderAsync(order).ConfigureAwait(false);
        }

        public async Task<List<Order>> GetOrdersAsync(int page, int pageSize)
        {
            // Implement pagination logic for order list
            //return orderList.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return await _OrderStorage.GetOrdersAsync(page, pageSize).ConfigureAwait(false);
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            // Implement logic to get a single order by Id
            //return orderList.FirstOrDefault(o => o.Id == orderId);
            return await _OrderStorage.GetOrderByIdAsync(orderId).ConfigureAwait(false);
        }

    
    }
}
