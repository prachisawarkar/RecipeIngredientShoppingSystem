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
    /// Interaction logic for AdminForgotPassword.xaml
    /// </summary>
    public partial class AdminForgotPassword : Window
    {
        public AdminForgotPassword()
        {
            InitializeComponent();
        }
        private void changepassbtn_Click(object sender, RoutedEventArgs e)  // Button for  Admin  ChangePassword
        {
            this.Close();
            AdminChangePassword changepasswordpage = new AdminChangePassword();
            changepasswordpage.Show();
        }
        private Admin CheckNulls()     // CheckNull function
        {
            Admin Adminmodify = new Admin();

            if (!string.IsNullOrEmpty(txtValue.Text.ToString()))
            {
                Adminmodify.UserName = txtValue.Text.ToString();
            }
            return Adminmodify;
        }
        private void searchbtn_Click(object sender, RoutedEventArgs e)  // Button for  Admin Forgot Password
        {
            bool searchresult = false;
            try
            {
                Admin admin = new Admin();
                admin.UserName = txtValue.Text;
                
                AdminBL Passvalidate = new AdminBL();
                searchresult = Passvalidate.AdminForget(admin.UserName);
                if (searchresult == true)
                {
                    MessageBox.Show("Username Found!");
                    this.Close();
                    AdminChangePassword pass = new AdminChangePassword();
                    pass.Show();
                }
                else
                {
                    MessageBox.Show("Username Not Found!");
                }
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
        private void homepagebtn_Click(object sender, RoutedEventArgs e)   // Button to go to home 
        {
            this.Close();
            MainWindow objPage = new MainWindow();
            objPage.Show();
        }
        private void backbtn_Click(object sender, RoutedEventArgs e)  // Button to go back
        {
            this.Close();
            LoginAdmin loginpage = new LoginAdmin();
            loginpage.Show();
        }
    }
}
