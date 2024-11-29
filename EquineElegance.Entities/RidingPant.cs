using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public class RidingPant : RiderProduct
    {
        // RidingPants (rijbroek) class die overerft van Product en RiderProduct waarin je het geslacht en maat kan ingeven

        public Gender Gender { get; set; }
        public PantsSize PantsSize { get; set; }

        public RidingPant(string name, string description, decimal price, string image, int amountInStock, Color color, Gender gender, PantsSize pantsSize) : 
            base(name, description, price, image, amountInStock, color)
        {
            Gender = gender;
            PantsSize = pantsSize;
            ProductType = ProductType.RidingPant;
        }

        public RidingPant()
        {
            
        }
    }
}
