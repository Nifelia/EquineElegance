using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Entities
{
    public class TackRoom : StableProduct
    {
        // TackRoom (zadelkamer) class die overerft van Product en StableProduct waarin je de hanger type kan kiezen

        [Required(ErrorMessage = "Selecteer het type hanger.")]
        public TackRoomHangerType TackRoomHangerType { get; set; }

        public TackRoom(string name, string description, decimal price, string image, int amountInStock, string dimensions, TackRoomHangerType tackRoomHangerType) :
            base(name, description, price, image, amountInStock, dimensions)
        {
            TackRoomHangerType = tackRoomHangerType;
            ProductType = ProductType.TackRoom;
        }

        public TackRoom()
        {
            
        }
    }
}
