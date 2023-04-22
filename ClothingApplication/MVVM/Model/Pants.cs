using ClothingApplication.Model;

namespace ClothingApplication.MVVM.Model
{
    internal class Pants : Cloth
    {
        public string _pantsSize { get; set; }
        public int _waistSize { get; set; }

        public Pants() { }

        public Pants(Brand brand, string color, string fabric, double price, int inventory, string size, int waistSize) : base(brand, color, fabric, price, inventory)
        {
            _pantsSize = size;
            _waistSize = waistSize;
        }

        public override string ToString()
        {
            return

                "Type: Pants " +
                " Brand: " + _brand + 
                " Color: " + _color + 
                " Fabric: " + _fabric + 
                " Price: " + _price + 
                " Inventory: " + _inventory + 
                " Size: " + _pantsSize +
                " Waist Size: " + _waistSize;
        }

    }
}
