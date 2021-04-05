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
    /// Interaction logic for CustomerForgotPassword.xaml
    /// </summary>
    public partial class CustomerForgotPassword : Window
    {
        public CustomerForgotPassword()
        {
            InitializeComponent();
        }

        private void changepassbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide(); 
            CustomerChangePassword changepasswordpage = new CustomerChangePassword();
            changepasswordpage.Show();
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginCustomer loginpage = new LoginCustomer();
            loginpage.Show();
        }

        private void homepagebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow objPage = new MainWindow();
            objPage.Show();
        }

        private void searchbtn_Click(object sender, RoutedEventArgs e)
        {
            bool searchresult = false;
            try
            {
                Customer customer = new Customer();
                customer.UserName = txtValue.Text;

                CustomerBL Passvalidate = new CustomerBL();
                searchresult = Passvalidate.CustomerForget(customer.UserName);
                if (searchresult == true)
                {
                    MessageBox.Show("Username Found!");
                }
                else
                {
                    MessageBox.Show("Username Not Found!");
                }
            }
            catch (RecipeIngredientSystemExceptions ex)//
            {//
                System.Windows.MessageBox.Show(ex.Message);//
            }//
        }
    }
}
