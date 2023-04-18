using ClothingApplication.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApplication.MVVM.Model
{
    internal class Pants : Cloth
    {
        public string _size;
        public int _waistSize;
        public Pants(Brand brand, string color, string fabric, double price, int inventory, string size, int waistSize) : base(brand, color, fabric, price, inventory)
        {
            _size = size;
            _waistSize = waistSize;
        }

        public override string ToString()
        {
            return _brand + " " + _color + " " + _fabric + " " + _price + " " + _inventory + " " + _size;
        }

    }
}
