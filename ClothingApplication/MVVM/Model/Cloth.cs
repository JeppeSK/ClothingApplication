using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Controls;

namespace ClothingApplication.MVVM.Model
{
    abstract class Cloth
    {
        [Key] public int _id { get; set; }
        public Brand _brand { get; set; }
        public string _color { get; set; }
        public string _fabric { get; set; }
        public double _price { get; set; }
        public int _inventory { get; set; }
        public string _image { get; set; }
        public string _size { get; set; }
        public string DiscriminatorValue
        {
            get { return this.GetType().Name; }
        }

        public Cloth() { }  

        public Cloth(Brand brand, string color, string fabric, double price, int inventory, string size)
        {
            _brand = brand;
            _color = color;
            _fabric = fabric;
            _price = price;
            _inventory = inventory;
            _size = size;
        }
    }
}
