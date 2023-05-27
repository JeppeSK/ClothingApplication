using ClothingApplication.DAL;
// using ClothingApplication.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

//            var initializer = new MigrateDatabaseToLatestVersion<ClothContext, Configuration>();
//            Database.SetInitializer(initializer);

            Datagrid.ItemsSource = Context.Cloth.Local;

            Context.Cloth.Load();
            Context.brand.Load();
        }
    }
}
