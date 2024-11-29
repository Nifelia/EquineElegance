using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public class Blanket : HorseProduct
    {
        // Blanket (deken) class met de overerving van Product & HorseProduct waarin het type dekje kan bepaald worden

        public BlanketType BlanketType { get; set; }

        public Blanket(string name, string description, decimal price, string image, int amountInStock, Color color, HorseSize horseSize, 
            BlanketType blanketType) : base(name, description, price, image, amountInStock, color, horseSize)
        {
            BlanketType = blanketType;
            ProductType = ProductType.Blanket;
        }

        public Blanket()
        {
            
        }
    }
}
