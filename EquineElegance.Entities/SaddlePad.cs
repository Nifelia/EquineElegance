using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public class SaddlePad : HorseProduct
    {
        // SaddlePad (dekjes) class die overerft van Product en HorseProduct en waarin je nog apart het type dekje kan ingeven

        [Required(ErrorMessage = "Selecteer een dekjesmaat.")]
        public SaddlePadType SaddlePadType { get; set; }

        public SaddlePad(string name, string description, decimal price, string image, int amountInStock, Color color, HorseSize horseSize, 
            SaddlePadType saddlePadType) : base(name, description, price, image, amountInStock, color, horseSize)
        {
            SaddlePadType = saddlePadType;
            ProductType = ProductType.SaddlePad;
        }

        public SaddlePad()
        {
            
        }
    }
}
