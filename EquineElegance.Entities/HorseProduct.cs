using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public class HorseProduct : Product
    {
        // de hoofdclass voor de producttypes die onder Horse (Paard) zullen vallen

        public Color Color { get; set; }
        public HorseSize HorseSize { get; set; }

        public HorseProduct(string name, string description, double price, string image, int amountInStock, Color color, HorseSize horseSize) : 
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
