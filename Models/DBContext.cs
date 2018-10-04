using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web;

namespace Graubakken_Filmsjappe.Models
{
    public class DBContext : DbContext
    {
        public DBContext()
            : base("name=FilmWeb")
        {
            Database.CreateIfNotExists();

            //Database.SetInitializer(new DBInit());
        }
        public DbSet<KundeDB> Kunder { get; set; }
        public DbSet<Film> Filmer { get; set; }
        public DbSet<Skuespiller> Skuespillere { get; set; }
        public DbSet<Nyhet> Nyheter { get; set; }
        public DbSet<Stemme> Stemmer { get; set; }
        public DbSet<Sjanger> Sjangere { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
