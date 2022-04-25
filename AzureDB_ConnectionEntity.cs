using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ConstruccionDeSoftware_ProyectoFinal
{
<<<<<<<< HEAD:Model1.cs
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DB_Connection_Entity")
========
    public partial class AzureDB_ConnectionEntity : DbContext
    {
        public AzureDB_ConnectionEntity()
            : base("name=AzureDB_ConnectionEntity")
>>>>>>>> 56a22f7ad8bdb78ea11d796441a59a73487fad4c:AzureDB_ConnectionEntity.cs
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
