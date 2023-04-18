using ClothingApplication.Model;
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

    }
}
