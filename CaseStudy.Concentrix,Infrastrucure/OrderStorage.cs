using AutoMapper;
using CaseStudy.Concentrix.Abstraction.Interface;
using CaseStudy.Concentrix.Abstraction.Model;
using CaseStudy.Concentrix.Application;
using Serilog;

namespace CaseStudy.Concentrix_Infrastrucure
{
    public class OrderStorage : IOrderStorage
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger = Log.Logger.ForContext<OrderStorage>();
        public OrderStorage(IMapper mapper,ILogger logger)
        {
            this._mapper = mapper;
            this._logger = logger;
        }
        public Task<Order> GetOrderByIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<int> PlaceOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
