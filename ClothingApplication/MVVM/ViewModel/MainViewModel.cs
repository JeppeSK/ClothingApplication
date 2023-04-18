using ClothingApplication.Core;
using System;
using System.ComponentModel;

namespace ClothingApplication.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand InventoryViewCommand { get; set; }
        public RelayCommand CRUDViewCommand { get; set; }

        public InventoryViewModel InventoryVm { get; set; }
        public CRUDViewModel CRUDVm { get; set; }

        private object _currentView;

        public object currentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            InventoryVm = new InventoryViewModel();

            currentView = InventoryVm;

            InventoryViewCommand = new RelayCommand(o =>
            {
                currentView = InventoryVm;
            });

            CRUDViewCommand = new RelayCommand(o =>
            {
                currentView = CRUDVm;
            });

        }

    }
}
