using ClothingApplication.DAL;
using System.Data.Entity;
using System.Windows.Controls;


namespace ClothingApplication.MVVM.View
{
    /// <summary>
    /// Interaction logic for InventoryView.xaml
    /// </summary>
    public partial class InventoryView : UserControl
    {
        private ClothContext Context = new ClothContext();
        public InventoryView()
        {
            InitializeComponent();

            Datagrid.ItemsSource = Context.Cloth.Local;

            Context.Cloth.Load();
            Context.brand.Load();
        }
    }
}
