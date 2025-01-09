using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquineElegance.Dal;
using EquineElegance.Entities;

namespace EquineElegance.Bll
{
    public static class Caps
    {
        // CREATE
        public static bool Create(string name, string description, decimal price, string image, int amountInStock, Color color, CapSize capSize)
        {
            // Trim zorgt ervoor dat er geen whitespace voor en na de Trim aanwezig is
            name = name.Trim();
            description = description.Trim();

            Cap cap = new Cap(name, description, price, image, amountInStock, color, capSize);
            return CapDal.Create(cap);
        }

        // READ ALL
        public static List<Cap> Read()
        {
            List<Cap> lstCaps = CapDal.Read();
            return lstCaps;
        }

        // READ SINGLE
        public static Cap Read(int id)
        {
            Cap cap = CapDal.Read(id);

            // in het geval er geen member gevonden wordt
            if (cap == null)
            {
                cap = new Cap();
            }

            return cap;
        }

        // EDIT
        public static bool Update(int productId, string name, string description, decimal price, string image,
            int amountInStock, Color color, CapSize capSize)
        {
            name = name.Trim();
            description = description.Trim();

            Cap cap = CapDal.Read(productId);

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description))
            {
                cap.Name = name;
                cap.Description = description;
                cap.Price = price;
                cap.Image = image;
                cap.AmountInStock = amountInStock;
                cap.Color = color;
                cap.CapSize = capSize;
            }

            return CapDal.Update(cap);
        }

        // DELETE
        public static bool Delete(int productId)
        {
            Cap cap = CapDal.Read(productId);
            return CapDal.Delete(cap);
        }
    }
}
