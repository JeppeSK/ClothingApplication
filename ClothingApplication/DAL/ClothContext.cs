using ClothingApplication.MVVM.Model;
using System.Collections;
using System.Data.Entity;


namespace ClothingApplication.DAL
{
    internal class ClothContext : DbContext
    {

        public ClothContext() : base("Cloth")
        {
            Database.SetInitializer(new ClothContextInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        private class ClothContextInitializer : DropCreateDatabaseIfModelChanges<ClothContext>
        {
            protected override void Seed(ClothContext context)
            {
                context.brand.Add(new Brand { _brandName = "Tiger Of Sweden", _country = "Sweden", _logo = "Tiger" });
                context.brand.Add(new Brand { _brandName = "Nike", _country = "USA", _logo = "Checkmark" });
                context.brand.Add(new Brand { _brandName = "Tommy Hilfinger", _country = "USA", _logo = "Red and Blue Square" });
                context.brand.Add(new Brand { _brandName = "Les Deux", _country = "Danmark", _logo = "II" });
            }
        }

        public virtual DbSet<Cloth> Cloth { get; set; }
        public virtual DbSet<Brand> brand { get; set; }
        public virtual DbSet<Jacket> Jacket { get; set; }
        public virtual DbSet<Pants> Pants { get; set; }
        public virtual DbSet<T_shirt> T_Shirt { get; set; }


    }
}
