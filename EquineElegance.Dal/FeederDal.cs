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
    public static class FeederDal
    {
        // CREATE
        public static bool Create(Feeder f)
        {
            using (var db = new EquineEleganceDbContext())
            {
                db.Feeders.Add(f);
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
        public static List<Feeder> Read()
        {
            using (var db = new EquineEleganceDbContext())
            {
                List<Feeder> lstFeeders = db.Feeders.ToList();
                return lstFeeders;
            }
        }

        // READ SINGLE
        public static Feeder Read(int id)
        {
            using (var db = new EquineEleganceDbContext())
            {
                Feeder f = db.Feeders.Find(id);
                return f;
            }
        }

        // EDIT
        public static bool Update(Feeder updatedF)
        {
            using (var db = new EquineEleganceDbContext())
            {
                try
                {
                    db.Feeders.AddOrUpdate(updatedF);
                    return db.SaveChanges() > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        // DELETE
        public static bool Delete(Feeder f)
        {
            using (var db = new EquineEleganceDbContext())
            {
                db.Entry(f).State = EntityState.Deleted;
                return db.SaveChanges() > 0;
            }
        }
    }
}
