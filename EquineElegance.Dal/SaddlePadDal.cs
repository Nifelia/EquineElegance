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
    public static class SaddlePadDal
    {
        // CREATE
        public static bool Create(SaddlePad sp)
        {
            using (var db = new EquineEleganceDbContext())
            {
                db.SaddlePads.Add(sp);
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
        public static List<SaddlePad> Read()
        {
            using (var db = new EquineEleganceDbContext())
            {
                List<SaddlePad> lstSaddlePads = db.SaddlePads.ToList();
                return lstSaddlePads;
            }
        }

        // READ SINGLE
        public static SaddlePad Read(int id)
        {
            using (var db = new EquineEleganceDbContext())
            {
                SaddlePad sp = db.SaddlePads.Find(id);
                return sp;
            }
        }

        // EDIT
        public static bool Update(SaddlePad updatedSp)
        {
            using (var db = new EquineEleganceDbContext())
            {
                try
                {
                    db.SaddlePads.AddOrUpdate(updatedSp);
                    return db.SaveChanges() > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        // DELETE
        public static bool Delete(SaddlePad sp)
        {
            using (var db = new EquineEleganceDbContext())
            {
                db.Entry(sp).State = EntityState.Deleted;
                return db.SaveChanges() > 0;
            }
        }
    }
}
