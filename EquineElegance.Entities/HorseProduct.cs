using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public class HorseProduct : Product
    {
        // de hoofdclass voor de producttypes die onder Horse (Paard) zullen vallen

        [Required(ErrorMessage = "Selecteer een kleur.")]
        public Color Color { get; set; }
        [Required(ErrorMessage = "Selecteer een paardenmaat.")]
        public HorseSize HorseSize { get; set; }

        public HorseProduct(string name, string description, decimal price, string image, int amountInStock, Color color, HorseSize horseSize) : 
            base(name, description, price, image, amountInStock)
        {
            Color = color;
            HorseSize = horseSize;
        }

        public HorseProduct()
        {
            
        }
    }
}
