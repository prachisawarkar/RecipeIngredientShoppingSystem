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

namespace RecipeIngredientSystem.PL
{
    /// <summary>
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        public AdminMenu(string username)
        {
            InitializeComponent();
            txtusername.Text = username;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void recipebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AdminAddRecipe recipe = new AdminAddRecipe(txtusername.Text);
            recipe.Show();
        }

        private void ingredientsbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AdminIngredientManagement recipe = new AdminIngredientManagement(txtusername.Text);
            recipe.Show();
        }

        private void ordersbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AdminViewOrder recipe = new AdminViewOrder(txtusername.Text);
            recipe.Show();
        }

        private void shippingbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AdminShipping recipe = new AdminShipping(txtusername.Text);
            recipe.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            {
                this.Close();
                LoginAdmin loginpage = new LoginAdmin();
                loginpage.Show();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow objPage = new MainWindow();
            objPage.Show();
        }
    }
}
