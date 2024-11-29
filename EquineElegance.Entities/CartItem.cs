using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public class CartItem
    {
        public Product Product { get; set; }
        public ProductType ProductType { get; set; }
        public int Amount { get; set; }
    }
}
