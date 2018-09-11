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

            Database.SetInitializer(new DBInit());
        }
        public DbSet<Kunde> Kunder { get; set; }
        public DbSet<Film> Filmer { get; set; }
        public DbSet<Skuespiller> Skuespillere { get; set; }
        public DbSet<Stemmer> Stemmer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
