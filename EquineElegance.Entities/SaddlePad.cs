using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public class SaddlePad : HorseProduct
    {
        public SaddlePadType SaddlePadType { get; set; }

        public SaddlePad(string name, string description, double price, string image, int amountInStock, Color color, HorseSize horseSize, 
            SaddlePadType saddlePadType) : base(name, description, price, image, amountInStock, color, horseSize)
        {
            SaddlePadType = saddlePadType;
        }

        public SaddlePad()
        {
            
        }
    }
}
