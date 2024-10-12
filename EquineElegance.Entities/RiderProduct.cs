using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public class RiderProduct : Product
    {
        // de hoofdclass voor de producttypes die onder Rider (Ruiter) zullen vallen

        [Required(ErrorMessage = "Selecteer een kleur.")]
        public Color Color { get; set; }

        public RiderProduct(string name, string description, decimal price, string image, int amountInStock, Color color)
            : base(name, description, price, image, amountInStock)
        {
            Color = color;
        }

        public RiderProduct()
        {
            
        }
    }
}
