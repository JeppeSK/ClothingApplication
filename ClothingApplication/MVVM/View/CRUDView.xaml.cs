using ClothingApplication.DAL;
using ClothingApplication.MVVM.Model;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System;


namespace ClothingApplication.MVVM.View
{
    /// <summary>
    /// Interaction logic for CRUDView.xaml
    /// </summary>
    public partial class CRUDView : UserControl
    {
        private readonly ClothContext Context = new ClothContext();

        public CRUDView()
        {
            InitializeComponent();
                
            brandsCB.ItemsSource = Context.brand.Local;
            brandsCB.DisplayMemberPath = "_brandName";
        
            Datagrid.ItemsSource = Context.Cloth.Local;

            Context.Cloth.Load();
            Context.brand.Load();
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if (Datagrid.SelectedIndex != -1)
            {

                int cloth_id = (Datagrid.SelectedItem as Cloth)._id;

                Cloth selectedItem = (from c in Context.Cloth
                                  where c._id == cloth_id
                                  select c).FirstOrDefault();

            if (selectedItem.DiscriminatorValue.Equals("Pants"))
            {
                Pants seletedPants = (from p in Context.Pants
                                      where p._id == cloth_id
                                      select p).FirstOrDefault();

                cmb.SelectedIndex = 0;

                brandsCB.SelectedItem = seletedPants._brand;

                price.Text = seletedPants._price.ToString();
                waistsizetxt.Text = seletedPants._waistSize.ToString();
                inventory.Text = seletedPants._inventory.ToString();
                fabric.Text = seletedPants._fabric;
                color.Text = seletedPants._color;
                size.Text = seletedPants._size;
            }
            else if (selectedItem.DiscriminatorValue.Equals("Jacket"))
            {
                Jacket selectedJacket = (from j in Context.Jacket
                                         where j._id == cloth_id
                                         select j).FirstOrDefault();

                cmb.SelectedIndex = 1;

                brandsCB.SelectedItem = selectedJacket._brand;

                price.Text = selectedJacket._price.ToString();
                inventory.Text = selectedJacket._inventory.ToString();
                fabric.Text = selectedJacket._fabric;
                color.Text = selectedJacket._color;
                size.Text = selectedJacket._size;
                if (selectedJacket._hasHood == true)
                {
                    hasHoodCheckBox.IsChecked = true;

                }
                else if (selectedJacket._hasHood == false)
                {
                    hasHoodCheckBox.IsChecked = false;
                }
            }
            else if (selectedItem.DiscriminatorValue.Equals("T_shirt"))
            {
                T_shirt selectedTshirt = (from t in Context.T_Shirt
                                          where t._id == cloth_id
                                          select t).FirstOrDefault();

                cmb.SelectedIndex = 2;

                brandsCB.SelectedItem = selectedTshirt._brand;

                price.Text = selectedTshirt._price.ToString();
                inventory.Text = selectedTshirt._inventory.ToString();
                fabric.Text = selectedTshirt._fabric;
                color.Text = selectedTshirt._color;
                size.Text = selectedTshirt._size;

                }
            }
        }

        private void CreateObject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Brand ComboboxBrandValue = brandsCB.SelectedItem as Brand;

                if (cmb.SelectedItem.Equals("Pants"))
                {
                    Pants pants = new Pants();

                    pants._price = Convert.ToInt32(price.Text);
                    pants._waistSize = Convert.ToInt32(waistsizetxt.Text);
                    pants._inventory = Convert.ToInt32(inventory.Text);
                    pants._fabric = fabric.Text;
                    pants._color = color.Text;
                    pants._size = size.Text;

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
                else if (cmb.SelectedItem.Equals("Jacket"))
                {
                    Jacket jacket = new Jacket();

                    jacket._price = Convert.ToInt32(price.Text);
                    jacket._inventory = Convert.ToInt32(inventory.Text);
                    jacket._fabric = fabric.Text;
                    jacket._color = color.Text;
                    jacket._size = size.Text;

                    if ((bool)hasHoodCheckBox.IsChecked)
                    {
                        jacket._hasHood = true;
                    }
                    else if ((bool)!hasHoodCheckBox.IsChecked)
                    {
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
                else if (cmb.SelectedItem.Equals("Tshirt"))
                {

                    T_shirt tshirt = new T_shirt();

                    tshirt._price = Convert.ToInt32(price.Text);
                    tshirt._inventory = Convert.ToInt32(inventory.Text);
                    tshirt._fabric = fabric.Text;
                    tshirt._color = color.Text;
                    tshirt._size = size.Text;

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
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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

            if (cmb.SelectedItem.Equals("Pants"))
            {
                //Hide Panels unnecessary panels.
                hasHoodCheckBox.Visibility = Visibility.Hidden;
                Hashoodlbl.Visibility = Visibility.Hidden;

                //Always Visible when any item is selected.
                pantsTxtboxPanel.Visibility = Visibility.Visible;
                StandardLblPanel.Visibility = Visibility.Visible;
                brandsCB.Visibility = Visibility.Visible;

                //Only Visible with the Pants selected.
                waistsizelbl.Visibility = Visibility.Visible;
                waistsizetxt.Visibility = Visibility.Visible;


            }
            else if (cmb.SelectedItem.Equals("Jacket"))
            {
                //Hide Panels unnecessary panels.
                waistsizelbl.Visibility = Visibility.Hidden;
                waistsizetxt.Visibility = Visibility.Hidden;

                //Always Visible when any item is selected.
                pantsTxtboxPanel.Visibility = Visibility.Visible;
                StandardLblPanel.Visibility = Visibility.Visible;
                brandsCB.Visibility = Visibility.Visible;

                //Only visible with the jacket selected.
                hasHoodCheckBox.Visibility = Visibility.Visible;
                Hashoodlbl.Visibility = Visibility.Visible;

            }
            else if (cmb.SelectedItem.Equals("Tshirt"))
            {
                //Hide Panels unnecessary panels.
                waistsizelbl.Visibility = Visibility.Hidden;
                waistsizetxt.Visibility = Visibility.Hidden;
                hasHoodCheckBox.Visibility = Visibility.Hidden;
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
            MessageBoxResult messageBoxResult = new MessageBoxResult();

            int cloth_id = (Datagrid.SelectedItem as Cloth)._id;
            Brand ComboboxBrandValue = brandsCB.SelectedItem as Brand;

            Cloth updateCloth = (from c in Context.Cloth
                                 where c._id == cloth_id
                                 select c).FirstOrDefault();

            if (updateCloth.DiscriminatorValue.Equals("Pants"))
            {
                Pants updatePants = (from p in Context.Pants
                                     where p._id == cloth_id
                                     select p).FirstOrDefault();

                updatePants._price = Convert.ToInt32(price.Text);
                updatePants._waistSize = Convert.ToInt32(waistsizetxt.Text);
                updatePants._inventory = Convert.ToInt32(inventory.Text);
                updatePants._fabric = fabric.Text;
                updatePants._color = color.Text;
                updatePants._size = size.Text;

                Brand thisBrand = (from b in Context.brand
                                   where b._brandName.Equals(ComboboxBrandValue._brandName.ToString())
                                   select b).FirstOrDefault();

                messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to Update " + updatePants.ToString(),
                    "Edit Confirmation", System.Windows.MessageBoxButton.YesNo);

                if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
                {
                    Context.SaveChanges();
                    Context.Cloth.Load();
                    Datagrid.ItemsSource = null;
                    Datagrid.ItemsSource = Context.Cloth.Local;
                }


            } else if (updateCloth.DiscriminatorValue.Equals("Jacket"))
            {
                Jacket updateJacket = (from j in Context.Jacket
                                       where j._id == cloth_id
                                       select j).FirstOrDefault();

                updateJacket._price = Convert.ToInt32(price.Text);
                updateJacket._inventory = Convert.ToInt32(inventory.Text);
                updateJacket._fabric = fabric.Text;
                updateJacket._color = color.Text;
                updateJacket._size = size.Text;

                if (hasHoodCheckBox.IsChecked == false)
                {
                    updateJacket._hasHood = false;
                } 
                else if (hasHoodCheckBox.IsChecked == true)
                {
                    updateJacket._hasHood = true;
                }

                    Brand thisBrand = (from b in Context.brand
                                   where b._brandName.Equals(ComboboxBrandValue._brandName.ToString())
                                   select b).FirstOrDefault();

                messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to Update " + updateJacket.ToString(),
                    "Edit Confirmation", System.Windows.MessageBoxButton.YesNo);

                if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
                {
                    Context.SaveChanges();
                    Context.Cloth.Load();
                    Datagrid.ItemsSource = null;
                    Datagrid.ItemsSource = Context.Cloth.Local;
                }

            } else if (updateCloth.DiscriminatorValue.Equals("Tshirt"))
            {
                T_shirt updateTshirt = (from t in Context.T_Shirt
                                        where t._id == cloth_id
                                        select t).FirstOrDefault();

                updateTshirt._price = Convert.ToInt32(price.Text);
                updateTshirt._inventory = Convert.ToInt32(inventory.Text);
                updateTshirt._fabric = fabric.Text;
                updateTshirt._color = color.Text;
                updateTshirt._size = size.Text;

                Brand thisBrand = (from b in Context.brand
                                   where b._brandName.Equals(ComboboxBrandValue._brandName.ToString())
                                   select b).FirstOrDefault();

                messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to Update " + updateTshirt.ToString(),
                    "Edit Confirmation", System.Windows.MessageBoxButton.YesNo);

                if (messageBoxResult == System.Windows.MessageBoxResult.Yes)
                {
                    Context.SaveChanges();
                    Context.Cloth.Load();
                    Datagrid.ItemsSource = null;
                    Datagrid.ItemsSource = Context.Cloth.Local;
                }

            }
        }
    }
}
