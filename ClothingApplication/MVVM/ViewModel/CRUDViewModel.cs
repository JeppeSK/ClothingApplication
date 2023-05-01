using ClothingApplication.Core;
using ClothingApplication.DAL;
using ClothingApplication.MVVM.Model;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Data.SqlTypes;
using System.Collections.ObjectModel;

namespace ClothingApplication.MVVM.ViewModel
{
    internal class CRUDViewModel : ObservableObject
    {

        private ObservableCollection<string> availableTypes = new ObservableCollection<string>();
        public CRUDViewModel() 
        {
            AvailableTypes.Add("Pants");
            AvailableTypes.Add("Jacket");
            AvailableTypes.Add("Shoes");
            AvailableTypes.Add("Tshirt");
        }

        public ObservableCollection<string> AvailableTypes
        {
            get { return availableTypes; }
            set { OnPropertyChanged(); }
        }
    }
}
