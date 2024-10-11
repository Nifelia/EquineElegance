using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public class Cap : RiderProduct
    {
        public CapSize CapSize { get; set; }

        public Cap(string name, string description, double price, string image, int amountInStock, Color color, CapSize capSize) : 
            base(name, description, price, image, amountInStock, color)
        {
            CapSize = capSize;
        }

        public Cap()
        {
            
        }
    }
}
