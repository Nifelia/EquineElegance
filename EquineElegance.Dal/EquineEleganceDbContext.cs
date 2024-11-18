using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquineElegance.Entities;

namespace EquineElegance.Dal
{
    internal class EquineEleganceDbContext : DbContext
    {
        public DbSet<Blanket> Blankets { get; set; }
        public DbSet<Cap> Caps { get; set; }
        public DbSet<Feeder> Feeders { get; set; }
        public DbSet<RidingPant> RidingPants { get; set; }
        public DbSet<SaddlePad> SaddlePads { get; set; }
        public DbSet<TackRoom> TackRooms { get; set; }

        public EquineEleganceDbContext() : base(@"Data Source=.\SQLEXPRESS;Initial Catalog=EquineElegance;Integrated Security=True")
        {
            
        }

        // stap 1: Migraties inschakelen --> dit moet je slechts één keer doen
        // EntityFramework6\Enable-Migrations

        // Stap 2: Voeg een migratie toe --> elke keer je iets verandert aan je Entities classes
        // EntityFramework6\Add-Migration naam

        // Stap 3: Update de database --> altijd nadat je eerst Add-Migration (stap2) gedaan hebt
        // EntityFramework6\Update-Database
    }
}
