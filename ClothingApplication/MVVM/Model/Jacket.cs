using ClothingApplication.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ClothingApplication.MVVM.Model
{
    internal class Jacket : Cloth
    {
        public bool _hasHood;
        public string _size;
        public Jacket(Brand brand, string color, string fabric, double price, int inventory, string size, bool hasHood) : base(brand, color, fabric, price, inventory)
        {
            _size = size;
            _hasHood = hasHood;
        }
        public override string ToString()
        {
            return _brand + " " + _color + " " + _fabric + " " + _price + " " + _inventory + " " + _size + " " + _hasHood;
        }

    }
}
