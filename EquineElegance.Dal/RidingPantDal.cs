using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquineElegance.Entities;

namespace EquineElegance.Dal
{
    public static class RidingPantDal
    {
        // CREATE
        public static bool Create(RidingPant rp)
        {
            using (var db = new EquineEleganceDbContext())
            {
                db.RidingPants.Add(rp);
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
        public static List<RidingPant> Read()
        {
            using (var db = new EquineEleganceDbContext())
            {
                List<RidingPant> lstRidingPants = db.RidingPants.ToList();
                return lstRidingPants;
            }
        }

        // READ SINGLE
        public static RidingPant Read(int id)
        {
            using (var db = new EquineEleganceDbContext())
            {
                RidingPant rp = db.RidingPants.Find(id);
                return rp;
            }
        }

        // EDIT
        public static bool Update(RidingPant updatedRp)
        {
            using (var db = new EquineEleganceDbContext())
            {
                try
                {
                    db.RidingPants.AddOrUpdate(updatedRp);
                    return db.SaveChanges() > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        // DELETE
        public static bool Delete(RidingPant rp)
        {
            using (var db = new EquineEleganceDbContext())
            {
                db.Entry(rp).State = EntityState.Deleted;
                return db.SaveChanges() > 0;
            }
        }
    }
}
