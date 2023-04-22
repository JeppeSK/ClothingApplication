using System.ComponentModel.DataAnnotations;
using System.Windows.Media;

namespace ClothingApplication.MVVM.Model
{
    internal class Brand
    {
        [Key] public int brandId { get; set; }

        public string _brandName { get; set; }

        public string _country { get; set; }

        public string _logo { get; set; }

        public Brand() { }

        public Brand(string name, string country, string logo)
        {
            _brandName = name;
            _country = country;
            _logo = logo;
        }
    }
}
