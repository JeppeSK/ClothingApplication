﻿using ClothingApplication.MVVM.Model;

namespace ClothingApplication.MVVM.Model
{
    internal class T_shirt : Cloth
    {
        public string _tshirtSize { get; set; }

        public T_shirt() { }

        public T_shirt(Brand brand, string color, string fabric, double price, int inventory, string size) : base(brand, color, fabric, price, inventory)
        {
            _tshirtSize = size;
        }
        public override string ToString()
        {
            return 

                "Type: Tshirt " + 
                " Brand: " + _brand + 
                " Color: " + _color + 
                " Fabric: " + _fabric + 
                " Price: " + _price + 
                " Inventory: " + _inventory + 
                " Size: " + _tshirtSize;
        }

    }
}
