using ClothingApplication.Model;
using ClothingApplication.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApplication.DAL
{
    internal class ClothContext : DbContext
    {

        public ClothContext() : base("Cloth")
        {

        }

        public DbSet<Cloth> Cloth { get; set; }
        public DbSet<Jacket> Jacket { get; set; }
        public DbSet<Pants> Pants { get; set; }
        public DbSet<T_shirt> T_Shirt { get; set; }


    }
}
