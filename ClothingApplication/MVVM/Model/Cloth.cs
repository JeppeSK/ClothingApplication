using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string DiscriminatorValue
        {
            get { return this.GetType().Name; }
        }

        public Cloth() { }  

        public Cloth(string brandname, string color, string fabric, double price, int inventory)
        {
            _brand._brandName = brandname;
            _color = color;
            _fabric = fabric;
            _price = price;
            _inventory = inventory;
        }
    }
}
