using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquineElegance.Entities;

namespace EquineElegance.Dal
{
    public static class CapDal
    {
        // CREATE
        public static bool Create(Cap cap)
        {
            using (var db = new EquineEleganceDbContext())
            {
                db.Caps.Add(cap);
                int numberOfChanges = db.SaveChanges();

                // controleren als het wel gelukt is
                if (numberOfChanges > 0)
                {
                    return true;
                }

                return false;
            }
        }

        // READ ALL
        public static List<Cap> Read()
        {
            using (var db = new EquineEleganceDbContext())
            {
                List<Cap> lstCaps = db.Caps.ToList();
                return lstCaps;
            }
        }

        // READ SINGLE
        public static Cap Read(int id)
        {
            using (var db = new EquineEleganceDbContext())
            {
                Cap cap = db.Caps.Find(id);
                return cap;
            }
        }
    }
}
