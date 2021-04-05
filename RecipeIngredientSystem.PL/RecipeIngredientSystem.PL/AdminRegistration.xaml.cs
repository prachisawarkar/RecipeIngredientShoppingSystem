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
    /// Interaction logic for AdminRegistration.xaml
    /// </summary>
    public partial class AdminRegistration : Window
    {
        public AdminRegistration()
        {
            InitializeComponent();
        }

        private void btnsubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Admin AdminAdd = new Admin();
                AdminAdd.UserName = txtusername.Text;
                AdminAdd.Password = txtpassword.Password;
                AdminAdd.SecurityQuestion = txtsecurityquestion.Text;
                AdminAdd.SecurityAnswer = txtsecurityanswer.Text;

                AdminBL Adminvalidate = new AdminBL();
                bool addresult = Adminvalidate.AddAdminBL(AdminAdd);
                if (addresult == true)
                {
                    this.Hide();
                    LoginAdmin login = new LoginAdmin();
                    login.Show();
                }
            }
            catch (RecipeIngredientSystemExceptions ex)//
            {//
                System.Windows.MessageBox.Show(ex.Message);//
            }//
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Registration registerpage = new Registration();
            registerpage.Show();
        }

        private void homepagebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow objPage = new MainWindow();
            objPage.Show();
        }
    }
}
