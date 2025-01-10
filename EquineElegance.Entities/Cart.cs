using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; }
        public string DiscountCode { get; set; }
        public decimal DiscountAmount { get; set; } 

        public Cart()
        {
            CartItems = new List<CartItem>();
        }
    }
}
