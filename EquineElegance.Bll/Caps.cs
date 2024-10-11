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
    }
}
