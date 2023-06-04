using ClothingApplication.MVVM.Model;
using System.Collections;
using System.Data.Entity;
using System.Linq;

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

                context.SaveChanges();

                var getBrands = context.brand.ToList();

                context.Pants.Add(new Pants { _brand = getBrands.ElementAt(1), _color = "Grey", _fabric = "Denim", _image = null, _inventory = 40, _price = 799, _size = "Medium", _waistSize = 38 });
                context.Jacket.Add(new Jacket { _brand = getBrands.ElementAt(2), _color = "Black", _fabric = "Leather", _image = null, _inventory = 30, _price = 1100, _size = "Medium", _hasHood = false });
                context.Jacket.Add(new Jacket { _brand = getBrands.ElementAt(3), _color = "Beige", _fabric = "Denim", _image = null, _inventory = 30, _price = 900, _size = "Medium", _hasHood = true });
                context.T_Shirt.Add(new T_shirt { _brand = getBrands.ElementAt(4), _color = "Yellow", _fabric = "100% Cotton", _image = null, _inventory = 100, _price = 550, _size = "Small" });
            }
        }

        public virtual DbSet<Cloth> Cloth { get; set; }
        public virtual DbSet<Brand> brand { get; set; }
        public virtual DbSet<Jacket> Jacket { get; set; }
        public virtual DbSet<Pants> Pants { get; set; }
        public virtual DbSet<T_shirt> T_Shirt { get; set; }


    }
}
