using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public class RidingPants : RiderProduct
    {
        public Gender Gender { get; set; }
        public PantsSize PantsSize { get; set; }

        public RidingPants(string name, string description, double price, string image, int amountInStock, Color color, Gender gender, PantsSize pantsSize) : 
            base(name ,description, price, image, amountInStock, color)
        {
            Gender = gender;
            PantsSize = pantsSize;
        }

        public RidingPants()
        {
            
        }
    }
}
