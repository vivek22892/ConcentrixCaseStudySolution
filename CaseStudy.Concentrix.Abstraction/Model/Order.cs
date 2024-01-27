using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;

namespace CaseStudy.Concentrix.Abstraction.Model
{
    public class Order:Base
    {

        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$")]
        public string BuyerEmail { get; set; }
        public Address ShipToAddressEntity { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal Total { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, this.GetType());
        }

    }
}
