using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public class Cap : RiderProduct
    {
        // Cap (helm) class die overerft van Product en RiderProduct waarin je de maat kan beslissen

        public CapSize CapSize { get; set; }

        public Cap(string name, string description, decimal price, string image, int amountInStock, Color color, CapSize capSize) : 
            base(name, description, price, image, amountInStock, color)
        {
            CapSize = capSize;
        }

        public Cap()
        {
            
        }
    }
}
