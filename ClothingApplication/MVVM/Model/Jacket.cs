using ClothingApplication.MVVM.Model;

namespace ClothingApplication.MVVM.Model
{
    internal class Jacket : Cloth
    {
        public bool _hasHood { get; set; }
        public string _jacketSize { get; set; }

        public Jacket() { }
        public Jacket(Brand brand, string color, string fabric, double price, int inventory, string size, bool hasHood) : base(brand, color, fabric, price, inventory)
        {
            _jacketSize = size;
            _hasHood = hasHood;
        }
        public override string ToString()
        {
            return 
                
                "Type: Jacket " +
                " Brand: " + _brand +
                " Color: " + _color +
                " Fabric: " + _fabric +
                " Price: " + _price +
                " Inventory: " + _inventory +
                " Size: " + _jacketSize +
                " Hashood: " + _hasHood;
        }

    }
}
