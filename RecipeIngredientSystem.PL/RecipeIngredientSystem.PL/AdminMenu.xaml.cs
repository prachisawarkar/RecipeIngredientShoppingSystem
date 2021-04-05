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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void recipebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminAddRecipe recipe = new AdminAddRecipe();
            recipe.Show();
        }

        private void ingredientsbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminIngredientManagement recipe = new AdminIngredientManagement();
            recipe.Show();
        }

        private void ordersbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminViewOrder recipe = new AdminViewOrder();
            recipe.Show();
        }

        private void shippingbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminShipping recipe = new AdminShipping();
            recipe.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            {
                this.Hide();
                LoginAdmin loginpage = new LoginAdmin();
                loginpage.Show();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow objPage = new MainWindow();
            objPage.Show();
        }
    }
}
