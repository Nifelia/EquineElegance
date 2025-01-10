using EquineElegance.Dal;
using EquineElegance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Bll
{
    public static class TackRooms
    {
        // CREATE
        public static bool Create(string name, string description, decimal price, string image, int amountInStock, string dimensions, TackRoomHangerType tackRoomHangerType)
        {
            // Trim zorgt ervoor dat er geen whitespace voor en na de Trim aanwezig is
            name = name.Trim();
            description = description.Trim();

            TackRoom tr = new TackRoom(name, description, price, image, amountInStock, dimensions, tackRoomHangerType);
            return TackRoomDal.Create(tr);
        }

        // READ ALL
        public static List<TackRoom> Read()
        {
            List<TackRoom> lstTackRooms = TackRoomDal.Read();
            return lstTackRooms;
        }

        // READ SINGLE
        public static TackRoom Read(int id)
        {
            TackRoom tr = TackRoomDal.Read(id);

            // in het geval er geen tackroom gevonden wordt
            if (tr == null)
            {
                tr = new TackRoom();
            }

            return tr;
        }

        // EDIT
        public static bool Update(int productId, string name, string description, decimal price, string image,
            int amountInStock, string dimensions, TackRoomHangerType tackRoomHangerType)
        {
            name = name.Trim();
            description = description.Trim();

            TackRoom tr = TackRoomDal.Read(productId);

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description))
            {
                tr.Name = name;
                tr.Description = description;
                tr.Price = price;
                tr.Image = image;
                tr.AmountInStock = amountInStock;
                tr.Dimensions = dimensions;
                tr.TackRoomHangerType = tackRoomHangerType;
            }

            return TackRoomDal.Update(tr);
        }

        // een andere Update voor makkelijker gebruik in de Cart om de stock te updaten
        public static bool Update(TackRoom tr)
        {
            // Call the existing method with the cap object's properties
            return Update(
                tr.ProductId,
                tr.Name,
                tr.Description,
                tr.Price,
                tr.Image,
                tr.AmountInStock,
                tr.Dimensions,
                tr.TackRoomHangerType
            );
        }

        // DELETE
        public static bool Delete(int productId)
        {
            TackRoom tr = TackRoomDal.Read(productId);
            return TackRoomDal.Delete(tr);
        }
    }
}
