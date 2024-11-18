using EquineElegance.Dal;
using EquineElegance.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Bll
{
    public static class RidingPants
    {
        // CREATE
        public static bool Create(string name, string description, decimal price, string image, int amountInStock, Color color, Gender gender, PantsSize pantsSize)
        {
            // Trim zorgt ervoor dat een geen whitespace voor en na de Trim aanwezig is
            name = name.Trim();
            description = description.Trim();

            RidingPant rp = new RidingPant(name, description, price, image, amountInStock, color, gender, pantsSize);
            return RidingPantDal.Create(rp);
        }

        // READ ALL
        public static List<RidingPant> Read()
        {
            List<RidingPant> lstRidingPants = RidingPantDal.Read();
            return lstRidingPants;
        }

        // READ SINGLE
        public static RidingPant Read(int id)
        {
            RidingPant rp = RidingPantDal.Read(id);

            // in het geval er geen member gevonden wordt
            if (rp == null)
            {
                rp = new RidingPant();
            }

            return rp;
        }

        // EDIT
        public static bool Update(int productId, string name, string description, decimal price, string image,
            int amountInStock, Color color, Gender gender, PantsSize pantsSize)
        {
            name = name.Trim();
            description = description.Trim();

            RidingPant rp = RidingPantDal.Read(productId);

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description))
            {
                rp.Name = name;
                rp.Description = description;
                rp.Price = price;
                rp.Image = image;
                rp.AmountInStock = amountInStock; 
                rp.Color = color;
                rp.Gender = gender;
                rp.PantsSize = pantsSize;
                
            }

            return RidingPantDal.Update(rp);
        }

        // DELETE
        public static bool Delete(int productId)
        {
            RidingPant rp = RidingPantDal.Read(productId);
            return RidingPantDal.Delete(rp);
        }
    }
}
