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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnadminsignin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LoginAdmin adminloginpage = new LoginAdmin();
            adminloginpage.Show();
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow objPage = new MainWindow();
            objPage.Show();
        }

        private void btncustsignin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LoginCustomer customerloginpage = new LoginCustomer();
            customerloginpage.Show();
        }
    }
}
