using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy.Concentrix.Domain.OrderAggregate
{
    public class OrderEntity: BaseEntity
    {
     
        public string BuyerEmail { get; set; }

        public AddressEntity ShipToAddressEntity { get; set; }
        public IReadOnlyList<OrderItemEntity> OrderEntityItems { get; set; }
        public decimal Total { get; set; }
    }
}
