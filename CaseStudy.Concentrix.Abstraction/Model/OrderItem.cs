using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy.Concentrix.Abstraction.Model
{
    public class OrderItem: Base
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
