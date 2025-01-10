using EquineElegance.Dal;
using EquineElegance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Bll
{
    public static class Blankets
    {
        // CREATE
        public static bool Create(string name, string description, decimal price, string image, int amountInStock, Color color, HorseSize horseSize, BlanketType blanketType)
        {
            // Trim zorgt ervoor dat een geen whitespace voor en na de Trim aanwezig is
            name = name.Trim();
            description = description.Trim();

            Blanket b = new Blanket(name, description, price, image, amountInStock, color, horseSize, blanketType);
            return BlanketDal.Create(b);
        }

        // READ ALL
        public static List<Blanket> Read()
        {
            List<Blanket> lstBlankets = BlanketDal.Read();
            return lstBlankets;
        }

        // READ SINGLE
        public static Blanket Read(int id)
        {
            Blanket b = BlanketDal.Read(id);

            // in het geval er geen gevonden wordt
            if (b == null)
            {
                b = new Blanket();
            }

            return b;
        }

        // EDIT
        public static bool Update(int productId, string name, string description, decimal price, string image,
            int amountInStock, Color color, HorseSize horseSize, BlanketType blanketType)
        {
            name = name.Trim();
            description = description.Trim();

            Blanket b = BlanketDal.Read(productId);

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description))
            {
                b.Name = name;
                b.Description = description;
                b.Price = price;
                b.Image = image;
                b.AmountInStock = amountInStock;
                b.Color = color;
                b.HorseSize = horseSize;
                b.BlanketType = blanketType;
            }

            return BlanketDal.Update(b);
        }

        // een andere Update voor makkelijker gebruik in de Cart om de stock te updaten
        public static bool Update(Blanket b)
        {
            // Call the existing method with the cap object's properties
            return Update(
                b.ProductId,
                b.Name,
                b.Description,
                b.Price,
                b.Image,
                b.AmountInStock,
                b.Color,
                b.HorseSize,
                b.BlanketType
            );
        }

        // DELETE
        public static bool Delete(int productId)
        {
            Blanket b = BlanketDal.Read(productId);
            return BlanketDal.Delete(b);
        }
    }
}
