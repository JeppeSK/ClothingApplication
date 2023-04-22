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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Cloth> Cloth { get; set; }
        public virtual DbSet<Jacket> Jacket { get; set; }
        public virtual DbSet<Pants> Pants { get; set; }
        public virtual DbSet<T_shirt> T_Shirt { get; set; }


    }
}
