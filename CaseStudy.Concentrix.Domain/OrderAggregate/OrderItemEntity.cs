using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy.Concentrix.Domain.OrderAggregate
{
    public class OrderItemEntity: BaseEntity
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
