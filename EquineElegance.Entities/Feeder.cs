using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public class Feeder : StableProduct
    {
        // Feeder (voedingsbakken/tonnen) die overerft van Product en Stableproduct waarbij je kan ingeven hoeveel er in de bak/ton kan

        public string Capacity { get; set; }

        public Feeder(string name, string description, double price, string image, int amountInStock, string dimensions, string capacity) : 
            base(name, description, price, image, amountInStock, dimensions)
        {
            Capacity = capacity;
        }

        public Feeder()
        {
            
        }
    }
}
