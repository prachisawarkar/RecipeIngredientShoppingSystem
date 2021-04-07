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
    /// Interaction logic for CustomerRegistration.xaml
    /// </summary>
    public partial class CustomerRegistration : Window
    {
        public CustomerRegistration()
        {
            InitializeComponent();
        }
        private void btnsubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer CustomerAdd = new Customer();
                CustomerAdd.UserName = txtusername.Text;
                CustomerAdd.Password = txtpassword.Password;
                CustomerAdd.Address = txtaddress.Text;
                CustomerAdd.Name = txtname.Text;
                CustomerAdd.MobileNumber = mobilenum.Text;
                CustomerAdd.Email = txtemail.Text;

                CustomerBL Customervalidate = new CustomerBL();
                bool addresult = Customervalidate.AddCustomerBL(CustomerAdd);
                if (addresult == true)
                {
                    this.Close();
                    LoginCustomer login = new LoginCustomer();
                    login.Show();
                }
            }
            catch (RecipeIngredientSystemExceptions ex)//
            {//
                System.Windows.MessageBox.Show(ex.Message);//
            }//
        }
        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);
        }
        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);
        }
        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Registration registerpage = new Registration();
            registerpage.Show();
        }
        private void homepagebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow objPage = new MainWindow();
            objPage.Show();
        }
    }
}
