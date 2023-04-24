using ClothingApplication.DAL;
using ClothingApplication.MVVM.Model;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using ClothingApplication.Migrations;
using System.Linq;
using System.Collections.Generic;
using System;

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
            pantsCB.DisplayMemberPath = "_brandName";

            cmb.ItemsSource = Context.Cloth.Local;
            cmb.DisplayMemberPath = "DiscriminatorValue";

            Datagrid.ItemsSource = Context.Cloth.Local;

            Context.Cloth.Load();
            Context.brand.Load();
        }

        private void CreateObject_Click(object sender, RoutedEventArgs e)
        {

            if (cmb.Text.Equals("Pants"))
            {
                Pants pants = new Pants();

                pants._price = Convert.ToInt32(price.Text);
                pants._waistSize = Convert.ToInt32(waistsize.Text);
                pants._inventory = Convert.ToInt32(inventory.Text);
                pants._fabric = fabric.Text;
                pants._color = color.Text;
                pants._pantsSize = size.Text;

                Brand thisBrand = (from b in Context.brand
                               where b._brandName.Equals(cmb.Text)
                               select b).FirstOrDefault();

                pants._brand = thisBrand;

                Context.Pants.Add(pants);
                Context.SaveChanges();

            }
            else if (cmb.Text.Equals("Jacekt"))
            {
                Jacket jacket = new Jacket();

                jacket._price = Convert.ToInt32(price.Text);
                jacket._inventory = Convert.ToInt32(inventory.Text);   
                jacket._fabric = fabric.Text;
                jacket._color = color.Text;
                jacket._jacketSize = size.Text;

                if ((bool)hasHood.IsChecked)
                {
                    jacket._hasHood = true;
                } else if ((bool)!hasHood.IsChecked){
                    jacket._hasHood = false;
                }

                Brand thisBrand = (from b in Context.brand
                                  where b._brandName.Equals(cmb.Text)
                                  select b).FirstOrDefault();

                jacket._brand = thisBrand;

                Context.Jacket.Add(jacket);
                Context.SaveChanges();
            }
            else if (cmb.Text.Equals("¨T-shirt"))
            {
                T_shirt tshirt = new T_shirt();

                tshirt._price = Convert.ToInt32(price.Text);
                tshirt._inventory = Convert.ToInt32(inventory.Text);
                tshirt._fabric = fabric.Text;
                tshirt._color = color.Text;
                tshirt._tshirtSize = size.Text;

                Brand thisBrand = (from b in Context.brand
                                   where b._brandName.Equals(cmb.Text)
                                   select b).FirstOrDefault();

                tshirt._brand = thisBrand;

                Context.T_Shirt.Add(tshirt);
                Context.SaveChanges();
            }
        }

        private void RemoveObject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb.Text.Equals("Pants"))
            {
                
            }
        }
    }
}
