using ClothingApplication.MVVM.Model;
using System.Collections;
using System.Data.Entity;


namespace ClothingApplication.DAL
{
    internal class ClothContext : DbContext
    {

        public ClothContext() : base("Cloth")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cloth> Cloth { get; set; }
        public DbSet<Brand> brand { get; set; }
        public DbSet<Jacket> Jacket { get; set; }
        public DbSet<Pants> Pants { get; set; }
        public DbSet<T_shirt> T_Shirt { get; set; }


    }
}
