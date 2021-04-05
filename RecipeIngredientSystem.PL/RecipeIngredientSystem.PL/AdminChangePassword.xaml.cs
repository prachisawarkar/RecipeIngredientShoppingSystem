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
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.Exceptions;
using RecipeIngredientSystem.BL;

namespace RecipeIngredientSystem.PL
{
    /// <summary>
    /// Interaction logic for AdminChangePassword.xaml
    /// </summary>
    public partial class AdminChangePassword : Window
    {
        public AdminChangePassword()
        {
            InitializeComponent();
        }

        private void changepassbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Admin Changepass = new Admin();
                Changepass.UserName = txtusername.Text;
                Changepass.Password = txtpassword.Password;
                Changepass.SecurityQuestion = txtquestion.Text;
                Changepass.SecurityAnswer = txtanswer.Text;
                Changepass.NewPassword = txtconfirmpass.Password;

                AdminBL Passvalidate = new AdminBL();
                bool addresult = Passvalidate.AdminChangePaasBL(Changepass);
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
            AdminForgotPassword forgotpasspage = new AdminForgotPassword();
            forgotpasspage.Show();
        }

        private void homepagebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow objPage = new MainWindow();
            objPage.Show();
        }
    }
}
