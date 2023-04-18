using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApplication.MVVM.Model
{
    internal class Brand
    {
        public string _brandName;
        public string _country;
        public string _logo;

        public Brand(string name, string country, string logo)
        {
            _brandName = name;
            _country = country;
            _logo = logo;

        }
    }
}
