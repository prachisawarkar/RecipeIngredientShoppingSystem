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
    /// Interaction logic for LoginAdmin.xaml
    /// </summary>
    public partial class LoginAdmin : Window
    {
        public LoginAdmin()
        {
            InitializeComponent();
        }
        private void btnsignin_Click(object sender, RoutedEventArgs e)    // Button for  Admin SignIn
        {
            try
            {
                Admin AdminAdd = new Admin();
                AdminAdd.UserName = txtusername.Text;
                AdminAdd.Password = txtpassword.Password;

                AdminBL Adminvalidate = new AdminBL();
                bool addresult = Adminvalidate.AdminLoginBL(AdminAdd);
                if (addresult == true)
                {
                    this.Close();
                    AdminMenu addrecipe = new AdminMenu(txtusername.Text);
                    addrecipe.Show();
                }
            }
            catch (RecipeIngredientSystemExceptions ex)//
            {//
                System.Windows.MessageBox.Show(ex.Message);//
            }//
        }
        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Login loginpage = new Login();
            loginpage.Show();
        }
        private void homepagebtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objPage = new MainWindow();
            objPage.Show();
        }
        private void btnforgotpass_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AdminForgotPassword cstforgotpasspage = new AdminForgotPassword();
            cstforgotpasspage.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AdminRegistration admregisterpage = new AdminRegistration();
            admregisterpage.Show();
        }
    }
}
