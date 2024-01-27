using CaseStudy.Concentrix.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Concentrix.Abstraction.Interface
{
    public interface IOrderService
    {
        Task<int> PlaceOrderAsync(Order order);
        Task<List<Order>> GetOrders(int page, int pageSize);
        Task<Order> GetOrderById(int orderId);
    }
}
