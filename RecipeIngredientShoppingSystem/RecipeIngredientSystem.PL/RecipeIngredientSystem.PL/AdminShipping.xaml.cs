using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using RecipeIngredientSystem.BL;
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.Exceptions;

namespace RecipeIngredientSystem.PL
{
    /// <summary>
    /// Interaction logic for AdminShipping.xaml
    /// </summary>
    public partial class AdminShipping : Window
    {
        public AdminShipping(string username)
        {
            InitializeComponent();
            txtusername.Text = username;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Shipping shipupdate = new Shipping();
                if (!String.IsNullOrEmpty(shipnum.Text))
                    shipupdate.ShippingNumber = Convert.ToInt32(shipnum.Text);
                /// shipupdate.OrderId = Convert.ToInt32(shiporderid.Text);
                if (!String.IsNullOrEmpty(expdate.Text))
                {
                    shipupdate.ExpectedDeliveryDate = Convert.ToDateTime(expdate.Text);
                }
                else
                {
                    MessageBox.Show("Please select valid date.");
                    return;
                }
                AdminShippingBL ShipValidations = new AdminShippingBL();
                bool updateresult = ShipValidations.UpdateAdminShippingBL(shipupdate);
                if (updateresult == true)
                {
                    Clear();
                    MessageBox.Show("Updated successfully !");
                }
                else
                {
                    MessageBox.Show("Not Updated !");
                }
            }
            catch (RecipeIngredientSystemExceptions ex)//
            {//
                System.Windows.MessageBox.Show(ex.Message);//
            }//
        }
        public void Clear()
        {
            shipnum.Clear();
            expdate.ClearValue(DatePicker.SelectedDateProperty);
            shiporderid.Clear();
            datagrid.ItemsSource = null;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminShippingBL ShipValidations = new AdminShippingBL();
            datagrid.ItemsSource = ShipValidations.GetAdminShiipingBL();
        }

        private void homepagebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Login loginpage = new Login();
            loginpage.Show();
        }

        private void logoutbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainpage = new MainWindow();
            mainpage.Show();
        }
        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AdminMenu adminmenupage = new AdminMenu(txtusername1.Text);
            adminmenupage.Show();
        }
        private void shipnum_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Shipping ship = datagrid.SelectedItem as Shipping;
                if (ship != null)
                {
                    if (ship.ShippingNumber >= 0)
                    {
                        shipnum.Text = Convert.ToString(ship.ShippingNumber);
                    }
                    if (ship.OrderId >= 0)
                    {
                        shiporderid.Text = Convert.ToString(ship.OrderId);
                    }
                    expdate.Text = Convert.ToString(ship.ExpectedDeliveryDate);
                }
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtusername1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

