using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ConstruccionDeSoftware_ProyectoFinal
{
    public partial class AzureDB_ConnectionEntity : DbContext
    {
        public AzureDB_ConnectionEntity()
            : base("name=AzureDB_ConnectionEntity")
        {
        }

        public virtual DbSet<List> Lists { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
