using ClothingApplication.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApplication.Model
{
    abstract class Cloth
    {

        public int _id { get; set; }
        public Brand _brand { get; set; }
        public string _color { get; set; }
        public string _fabric { get; set; }
        public double _price { get; set; }
        public int _inventory { get; set; }

        public Cloth() { }  

        public Cloth(Brand brand, string color, string fabric, double price, int inventory)
        {
            _brand = brand;
            _color = color;
            _fabric = fabric;
            _price = price;
            _inventory = inventory;
        }
    }
}
