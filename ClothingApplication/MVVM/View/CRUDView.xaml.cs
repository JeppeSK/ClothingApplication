using ClothingApplication.DAL;
using ClothingApplication.MVVM.Model;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using ClothingApplication.Migrations;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Windows.Interop;
using System.Windows.Media.Animation;

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
                
            brandsCB.ItemsSource = Context.brand.Local;
            brandsCB.DisplayMemberPath = "_brandName";

            cmb.ItemsSource = Context.Cloth.Local;
            cmb.DisplayMemberPath = "DiscriminatorValue";
        
            Datagrid.ItemsSource = Context.Cloth.Local;

            Context.Cloth.Load();
            Context.brand.Load();
        }

        private void CreateObject_Click(object sender, RoutedEventArgs e)
        {

            Cloth ComboboxItemValue = cmb.SelectedItem as Cloth;
            Brand ComboboxBrandValue = brandsCB.SelectedItem as Brand;

            if (ComboboxItemValue.DiscriminatorValue.Equals("Pants"))
            {
                Pants pants = new Pants();

                pants._price = Convert.ToInt32(price.Text);
                pants._waistSize = Convert.ToInt32(waistsizetxt.Text);
                pants._inventory = Convert.ToInt32(inventory.Text);
                pants._fabric = fabric.Text;
                pants._color = color.Text;
                pants._pantsSize = size.Text;

                Brand thisBrand = (from b in Context.brand
                               where b._brandName.Equals(ComboboxBrandValue._brandName.ToString())
                               select b).FirstOrDefault();

                pants._brand = thisBrand;

                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to create " + pants.ToString(),
                    "Create Confirmation",
                    System.Windows.MessageBoxButton.YesNo);

                if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
                {
                    Context.Pants.Add(pants);
                    Context.SaveChanges();
                }

            }
            else if (ComboboxItemValue.DiscriminatorValue.Equals("Jacket"))
            {
                Jacket jacket = new Jacket();

                jacket._price = Convert.ToInt32(price.Text);
                jacket._inventory = Convert.ToInt32(inventory.Text);   
                jacket._fabric = fabric.Text;
                jacket._color = color.Text;
                jacket._jacketSize = size.Text;

                if ((bool)hasHoodRadio.IsChecked)
                {
                    jacket._hasHood = true;
                } else if ((bool)!hasHoodRadio.IsChecked){
                    jacket._hasHood = false;
                }

                Brand thisBrand = (from b in Context.brand
                                  where b._brandName.Equals(ComboboxBrandValue._brandName.ToString())
                                  select b).FirstOrDefault();

                jacket._brand = thisBrand;

                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to create " + jacket.ToString(),
                    "Create Confirmation",
                    System.Windows.MessageBoxButton.YesNo);

                if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
                {
                    Context.Jacket.Add(jacket);
                    Context.SaveChanges();
                }

            }
            else if (ComboboxItemValue.DiscriminatorValue.Equals("T_shirt"))
            {
                T_shirt tshirt = new T_shirt();

                tshirt._price = Convert.ToInt32(price.Text);
                tshirt._inventory = Convert.ToInt32(inventory.Text);
                tshirt._fabric = fabric.Text;
                tshirt._color = color.Text;
                tshirt._tshirtSize = size.Text;

                Brand thisBrand = (from b in Context.brand
                                   where b._brandName.Equals(ComboboxBrandValue._brandName.ToString())
                                   select b).FirstOrDefault();

                tshirt._brand = thisBrand;

                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to create " + tshirt.ToString(),
                    "Create Confirmation",
                    System.Windows.MessageBoxButton.YesNo);

                if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
                {
                    Context.T_Shirt.Add(tshirt);
                    Context.SaveChanges();
                }
            }
        }

        private void RemoveObject_Click(object sender, RoutedEventArgs e)
        {
            int cloth_id = (Datagrid.SelectedItem as Cloth)._id;

            Cloth cloth = (from c in Context.Cloth
                           where c._id == cloth_id
                           select c).FirstOrDefault();

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to create " + cloth.ToString(),
           "Remove Confirmation",
           System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                Context.Cloth.Remove(cloth);
                Context.SaveChanges();
                Datagrid.ItemsSource = Context.Cloth.Local;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Cloth ComboboxItemValue = cmb.SelectedItem as Cloth;

            if (ComboboxItemValue.DiscriminatorValue.Equals("Pants"))
            {
                //Hide Panels unnecessary panels.
                hasHoodRadio.Visibility = Visibility.Hidden;
                Hashoodlbl.Visibility = Visibility.Hidden;

                //Always Visible when any item is selected.
                pantsTxtboxPanel.Visibility = Visibility.Visible;
                StandardLblPanel.Visibility = Visibility.Visible;
                brandsCB.Visibility = Visibility.Visible;

                //Only Visible with the Pants selected.
                waistsizelbl.Visibility = Visibility.Visible;
                waistsizetxt.Visibility = Visibility.Visible;

            }
            else if (ComboboxItemValue.DiscriminatorValue.Equals("Jacket"))
            {
                //Hide Panels unnecessary panels.
                waistsizelbl.Visibility = Visibility.Hidden;
                waistsizetxt.Visibility = Visibility.Hidden;

                //Always Visible when any item is selected.
                pantsTxtboxPanel.Visibility = Visibility.Visible;
                StandardLblPanel.Visibility = Visibility.Visible;
                brandsCB.Visibility = Visibility.Visible;

                //Only visible with the jacket selected.
                hasHoodRadio.Visibility = Visibility.Visible;
                Hashoodlbl.Visibility = Visibility.Visible;

            }
            else if (ComboboxItemValue.DiscriminatorValue.Equals("T_shirt"))
            {
                //Hide Panels unnecessary panels.
                waistsizelbl.Visibility = Visibility.Hidden;
                waistsizetxt.Visibility = Visibility.Hidden;
                hasHoodRadio.Visibility = Visibility.Hidden;
                Hashoodlbl.Visibility = Visibility.Hidden;

                //Always Visible when any item is selected.
                pantsTxtboxPanel.Visibility = Visibility.Visible;
                StandardLblPanel.Visibility = Visibility.Visible;
                brandsCB.Visibility = Visibility.Visible;
            }
        }

        private void textPrevention_forTextBoxes(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(price.Text, "[^0-9]"))
            {
                MessageBox.Show("Please only enter numbers.");
                price.Text = price.Text.Remove(price.Text.Length -1);
            }
        }

        private void EditObject_Click(object sender, RoutedEventArgs e)
        {
            int cloth_id = (Datagrid.SelectedItem as Cloth)._id;

            Cloth updateCloth = (from c in Context.Cloth
                                 where c._id == cloth_id
                                 select c).FirstOrDefault();

            updateCloth._price = Convert.ToInt32(price.Text);
            updateCloth._inventory = Convert.ToInt32(inventory.Text);
            updateCloth._fabric = fabric.Text;
            updateCloth._color = color.Text;

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to Update " + updateCloth.ToString(),
            "Remove Confirmation",
            System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                Context.SaveChanges();
                Datagrid.ItemsSource = Context.Cloth.Local;
            }
        }
    }
}
