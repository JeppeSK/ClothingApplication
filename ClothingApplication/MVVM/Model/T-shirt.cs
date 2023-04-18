using ClothingApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApplication.MVVM.Model
{
    internal class T_shirt : Cloth
    {
        public string _size;
        public T_shirt(Brand brand, string color, string fabric, double price, int inventory, string size) : base(brand, color, fabric, price, inventory)
        {
            _size = size;
        }
        public override string ToString()
        {
            return _brand + " " + _color + " " + _fabric + " " + _price + " " + _inventory + " " + _size;
        }

    }
}
