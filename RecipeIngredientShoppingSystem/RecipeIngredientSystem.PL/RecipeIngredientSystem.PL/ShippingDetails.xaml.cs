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
using System.Data;
using RecipeIngredientSystem.BL;
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.Exceptions;

namespace RecipeIngredientSystem.PL
{
    /// <summary>
    /// Interaction logic for ShippingDetails.xaml
    /// </summary>
    public partial class ShippingDetails : Window
    {
        public ShippingDetails(string username)
        {
            InitializeComponent();
            //customer username 
            txtusername.Text = username.ToUpper();
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //back button
        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            OrderIngredient orderpage = new OrderIngredient(txtusername.Text);
            //redirect to order page
            orderpage.Show();
        }
        //view shipping details of particular order to the customer
        private void ViewShippingButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = "";
                //check null values
                if (!string.IsNullOrEmpty(txtusername.Text))
                {
                    username = txtusername.Text;//take username 
                    ShippingBL shippingBL = new ShippingBL();
                    
                    grid.ItemsSource = shippingBL.GetShippingDetails(username);
                    //show textbox message
                    txtmsg.Text = "THANK YOU FOR SHOPPING";
                }
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //logout
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainpage = new MainWindow();
            //redirect to main page
            mainpage.Show();
        }
        private void txtmsg_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
