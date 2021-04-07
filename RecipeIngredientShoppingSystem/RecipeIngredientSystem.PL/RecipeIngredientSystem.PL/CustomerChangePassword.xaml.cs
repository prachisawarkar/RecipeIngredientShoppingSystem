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
    /// Interaction logic for CustomerChangePassword.xaml
    /// </summary>
    public partial class CustomerChangePassword : Window
    {
        public CustomerChangePassword()
        {
            InitializeComponent();
        }
        private void homepagebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow objPage = new MainWindow();
            objPage.Show();
        }
        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            CustomerForgotPassword forgotpasspage = new CustomerForgotPassword();
            forgotpasspage.Show();
        }
        private void changepassbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer Changepass = new Customer();
                if(!String.IsNullOrEmpty(txtusername.Text))
                    Changepass.UserName = txtusername.Text;
                if(!String.IsNullOrEmpty(txtmobilenum.Text))
                    Changepass.MobileNumber = txtmobilenum.Text;
                if(!String.IsNullOrEmpty(txtpassword.Password))
                    Changepass.Password = txtpassword.Password;
                if(!String.IsNullOrEmpty(txtconfirmpaassword.Password))
                    Changepass.NewPassword = txtconfirmpaassword.Password;
                
                if((!String.IsNullOrEmpty(txtpassword.Password)) || (!String.IsNullOrEmpty(txtconfirmpaassword.Password)))
                {
                    if (Changepass.Password.Equals(Changepass.NewPassword))
                    {
                        CustomerBL Passvalidate = new CustomerBL();
                        bool addresult = Passvalidate.CustomerChangePaasBL(Changepass);
                        if (addresult == true)
                        {
                            this.Close();
                            LoginCustomer login = new LoginCustomer();
                            login.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show(" Password Does Not Match !");
                    }
                }
            }
            catch (RecipeIngredientSystemExceptions ex)//
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
    }
}
