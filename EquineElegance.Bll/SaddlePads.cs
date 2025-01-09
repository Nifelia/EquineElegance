using EquineElegance.Dal;
using EquineElegance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Bll
{
    public static class SaddlePads
    {
        // CREATE
        public static bool Create(string name, string description, decimal price, string image, int amountInStock, Color color, HorseSize horseSize, SaddlePadType saddlePadType)
        {
            // Trim zorgt ervoor dat een geen whitespace voor en na de Trim aanwezig is
            name = name.Trim();
            description = description.Trim();

            SaddlePad sp = new SaddlePad(name, description, price, image, amountInStock, color, horseSize, saddlePadType);
            return SaddlePadDal.Create(sp);
        }

        // READ ALL
        public static List<SaddlePad> Read()
        {
            List<SaddlePad> lstSaddlePads = SaddlePadDal.Read();
            return lstSaddlePads;
        }

        // READ SINGLE
        public static SaddlePad Read(int id)
        {
            SaddlePad sp = SaddlePadDal.Read(id);

            // in het geval er geen gevonden wordt
            if (sp == null)
            {
                sp = new SaddlePad();
            }

            return sp;
        }

        // EDIT
        public static bool Update(int productId, string name, string description, decimal price, string image,
            int amountInStock, Color color, HorseSize horseSize, SaddlePadType saddlePadType)
        {
            name = name.Trim();
            description = description.Trim();

            SaddlePad sp = SaddlePadDal.Read(productId);

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description))
            {
                sp.Name = name;
                sp.Description = description;
                sp.Price = price;
                sp.Image = image;
                sp.AmountInStock = amountInStock;
                sp.Color = color;
                sp.HorseSize = horseSize;
                sp.SaddlePadType = saddlePadType;
            }

            return SaddlePadDal.Update(sp);
        }

        // DELETE
        public static bool Delete(int productId)
        {
            SaddlePad sp = SaddlePadDal.Read(productId);
            return SaddlePadDal.Delete(sp);
        }
    }
}
