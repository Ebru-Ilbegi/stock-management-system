using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Concrete_dal
{
    public class Context : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
            //bunun sayesinde depo silinince movement kayıtları silinmiyor karşılıklı silmeyi kapattık
        {
            modelBuilder.Entity<Movement>()
                .HasRequired(m => m.Warehouse)   // Movement -> Warehouse ilişkisi
                .WithMany(w => w.Movements)      // Warehouse -> Movements ilişkisi
                .HasForeignKey(m => m.WareHouseId)
                .WillCascadeOnDelete(false);     // 🔑 Cascade delete kapatıldı

            base.OnModelCreating(modelBuilder);
        }


    }
}
