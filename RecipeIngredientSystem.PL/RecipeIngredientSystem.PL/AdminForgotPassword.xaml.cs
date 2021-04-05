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

        private void changepassbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminChangePassword changepasswordpage = new AdminChangePassword();
            changepasswordpage.Show();
        }

        private Admin CheckNulls()
        {
            Admin Adminmodify = new Admin();

            if (!string.IsNullOrEmpty(txtValue.Text.ToString()))
            {
                Adminmodify.UserName = txtValue.Text.ToString();
            }

            return Adminmodify;
        }

        private void searchbtn_Click(object sender, RoutedEventArgs e)
        {
            bool searchresult = false;
            try
            {
                Admin admin = new Admin();
                admin.UserName = txtValue.Text;
                //Admin Forget = CheckNulls();
                AdminBL Passvalidate = new AdminBL();
                searchresult = Passvalidate.AdminForget(admin.UserName);
                if (searchresult == true)
                {
                    MessageBox.Show("Username Found!");
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

        private void homepagebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow objPage = new MainWindow();
            objPage.Show();
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginAdmin loginpage = new LoginAdmin();
            loginpage.Show();
        }
    }
}
