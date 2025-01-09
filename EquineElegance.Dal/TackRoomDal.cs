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
    public static class TackRoomDal
    {
        // CREATE
        public static bool Create(TackRoom tr)
        {
            using (var db = new EquineEleganceDbContext())
            {
                db.TackRooms.Add(tr);
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
        public static List<TackRoom> Read()
        {
            using (var db = new EquineEleganceDbContext())
            {
                List<TackRoom> lstTackRooms = db.TackRooms.ToList();
                return lstTackRooms;
            }
        }

        // READ SINGLE
        public static TackRoom Read(int id)
        {
            using (var db = new EquineEleganceDbContext())
            {
                TackRoom tr = db.TackRooms.Find(id);
                return tr;
            }
        }

        // EDIT
        public static bool Update(TackRoom updatedTr)
        {
            using (var db = new EquineEleganceDbContext())
            {
                try
                {
                    db.TackRooms.AddOrUpdate(updatedTr);
                    return db.SaveChanges() > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        // DELETE
        public static bool Delete(TackRoom tr)
        {
            using (var db = new EquineEleganceDbContext())
            {
                db.Entry(tr).State = EntityState.Deleted;
                return db.SaveChanges() > 0;
            }
        }
    }
}
