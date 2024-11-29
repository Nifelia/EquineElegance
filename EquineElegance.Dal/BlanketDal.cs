using EquineElegance.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquineElegance.Dal
{
    public static class BlanketDal
    {
        // CREATE
        public static bool Create(Blanket b)
        {
            using (var db = new EquineEleganceDbContext())
            {
                db.Blankets.Add(b);
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
        public static List<Blanket> Read()
        {
            using (var db = new EquineEleganceDbContext())
            {
                List<Blanket> lstBlankets = db.Blankets.ToList();
                return lstBlankets;
            }
        }

        // READ SINGLE
        public static Blanket Read(int id)
        {
            using (var db = new EquineEleganceDbContext())
            {
                Blanket b = db.Blankets.Find(id);
                return b;
            }
        }

        // EDIT
        public static bool Update(Blanket updatedB)
        {
            using (var db = new EquineEleganceDbContext())
            {
                try
                {
                    db.Blankets.AddOrUpdate(updatedB);
                    return db.SaveChanges() > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        // DELETE
        public static bool Delete(Blanket b)
        {
            using (var db = new EquineEleganceDbContext())
            {
                db.Entry(b).State = EntityState.Deleted;
                return db.SaveChanges() > 0;
            }
        }
    }
}
