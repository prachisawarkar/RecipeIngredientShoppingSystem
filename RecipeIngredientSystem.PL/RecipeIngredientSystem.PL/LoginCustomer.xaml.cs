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
    /// Interaction logic for LoginCustomer.xaml
    /// </summary>
    public partial class LoginCustomer : Window
    {
        public LoginCustomer()
        {
            InitializeComponent();
        }
        private void btnsignin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer customer = new Customer();
                customer.UserName = txtusername.Text;
                customer.Password = txtpassword.Password;

                CustomerBL customerBL = new CustomerBL();
                bool result = customerBL.CustomerLoginBL(customer);

                if (result == true)
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    SelectRecipe recipepage = new SelectRecipe(customer.UserName);
                    recipepage.Show();
                }
                else
                {
                    MessageBox.Show("Login Unsuccessful!");
                }
            }
            catch (RecipeIngredientSystemExceptions ex)//
            {//
                System.Windows.MessageBox.Show(ex.Message);//
            }//
        }

        private void btnforgotpass_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CustomerForgotPassword forgotpasswordpage = new CustomerForgotPassword();
            forgotpasswordpage.Show();
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login loginpage = new Login();
            loginpage.Show();
        }

        private void homepagebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow objPage = new MainWindow();
            objPage.Show();
        }

        private void signupbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CustomerRegistration cstregisterpage = new CustomerRegistration();
            cstregisterpage.Show();
        }
    }
}
