using ClothingApplication.DAL;
using ClothingApplication.MVVM.Model;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using ClothingApplication.Migrations;

namespace ClothingApplication.MVVM.View
{
    /// <summary>
    /// Interaction logic for CRUDView.xaml
    /// </summary>
    public partial class CRUDView : UserControl
    {
        private ClothContext Context = new ClothContext();

        public CRUDView()
        {
            InitializeComponent();

            var initializer = new MigrateDatabaseToLatestVersion<ClothContext, Configuration>();
            Database.SetInitializer(initializer);

            pantsCB.ItemsSource = Context.brand.Local;

            Datagrid.ItemsSource = Context.Cloth.Local;

            Context.Cloth.Load();
        }

        private void CreateObject_Click(object sender, RoutedEventArgs e)
        {
            Jacket J = new Jacket();

            J._brand = new Brand("Nike", "USA", "Checkmark");
            J._color = "Black";
            J._fabric = "100% Cotton";
            J._price = 2000;
            J._inventory = 20;
            J._jacketSize = "Medium";
            J._hasHood = true;

            Context.Jacket.Add(J);
            Context.SaveChanges();

        }

        private void RemoveObject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cmb.SelectionBoxItem.ToString().Equals("Pants"))
            {
                pantsCB.Visibility = Visibility.Visible;
                pantsLblPanel.Visibility = Visibility.Visible;
                pantsTxtboxPanel.Visibility = Visibility.Visible;
            } else if (cmb.SelectionBoxItem.ToString().Equals("Jackets"))
            {
                pantsCB.Visibility = Visibility.Hidden;
                pantsLblPanel.Visibility = Visibility.Hidden;
                pantsTxtboxPanel.Visibility = Visibility.Hidden;
            }
        }
    }
}
