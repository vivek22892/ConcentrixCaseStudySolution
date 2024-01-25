using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Concentrix.Abstraction.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public int OrderQuantity { get; set; }
    }
}
