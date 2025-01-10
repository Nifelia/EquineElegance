using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public class StableProduct : Product
    {
        // de hoofdclass voor alle Stable (Stal) producten

        [Required(ErrorMessage = "Geef de afmetingen in.")]
        public string Dimensions { get; set; }

        public StableProduct(string name, string description, decimal price, string image, int amountInStock, string dimensions) : 
            base(name, description, price, image, amountInStock)
        {
            Dimensions = dimensions;
        }

        public StableProduct()
        {
            
        }
    }
}
