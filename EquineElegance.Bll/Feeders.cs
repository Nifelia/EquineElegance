using EquineElegance.Dal;
using EquineElegance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Bll
{
    public static class Feeders
    {
        // CREATE
        public static bool Create(string name, string description, decimal price, string image, int amountInStock, string dimensions, string capacity)
        {
            // Trim zorgt ervoor dat er geen whitespace voor en na de Trim aanwezig is
            name = name.Trim();
            description = description.Trim();

            Feeder f = new Feeder(name, description, price, image, amountInStock, dimensions, capacity);
            return FeederDal.Create(f);
        }

        // READ ALL
        public static List<Feeder> Read()
        {
            List<Feeder> lstFeeders = FeederDal.Read();
            return lstFeeders;
        }

        // READ SINGLE
        public static Feeder Read(int id)
        {
            Feeder f = FeederDal.Read(id);

            // in het geval er geen feeder gevonden wordt
            if (f == null)
            {
                f = new Feeder();
            }

            return f;
        }

        // EDIT
        public static bool Update(int productId, string name, string description, decimal price, string image,
            int amountInStock, string dimensions, string capacity)
        {
            name = name.Trim();
            description = description.Trim();

            Feeder f = FeederDal.Read(productId);

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description))
            {
                f.Name = name;
                f.Description = description;
                f.Price = price;
                f.Image = image;
                f.AmountInStock = amountInStock;
                f.Dimensions = dimensions;
                f.Capacity = capacity;
            }

            return FeederDal.Update(f);
        }

        // een andere Update voor makkelijker gebruik in de Cart om de stock te updaten
        public static bool Update(Feeder f)
        {
            // Call the existing method with the cap object's properties
            return Update(
                f.ProductId,
                f.Name,
                f.Description,
                f.Price,
                f.Image,
                f.AmountInStock,
                f.Dimensions,
                f.Capacity
            );
        }

        // DELETE
        public static bool Delete(int productId)
        {
            Feeder f = FeederDal.Read(productId);
            return FeederDal.Delete(f);
        }
    }
}
