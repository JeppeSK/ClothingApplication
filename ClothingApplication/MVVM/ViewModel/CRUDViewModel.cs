using ClothingApplication.Core;
using ClothingApplication.MVVM.Model;
using System.Linq;
namespace ClothingApplication.MVVM.ViewModel
{
    internal class CRUDViewModel : ObservableObject
    {

        public Cloth cloth { get; set; }
        public Brand brand { get; set; }

        public string brandName
        {
            get { return brand._brandName; }
            set
            {
                brand._brandName = value;
                OnPropertyChanged();
            }
        }

        public CRUDViewModel() { }

    }
}
