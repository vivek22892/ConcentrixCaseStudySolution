using CaseStudy.Concentrix.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Concentrix.Abstraction.Interface
{
    public interface IOrderStorage
    {
        Task<int> PlaceOrderAsync(Order order);
        Task<List<Order>> GetOrdersAsync(int page, int pageSize);
        Task<Order> GetOrderByIdAsync(int orderId);
    }
}
