using ClothingApplication.MVVM.Model;
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

        public virtual DbSet<Cloth> Cloth { get; set; }
        public virtual DbSet<Brand> brand { get; set; }
        public virtual DbSet<Jacket> Jacket { get; set; }
        public virtual DbSet<Pants> Pants { get; set; }
        public virtual DbSet<T_shirt> T_Shirt { get; set; }


    }
}
