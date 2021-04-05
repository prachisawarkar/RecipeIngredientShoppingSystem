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
    /// Interaction logic for AdminViewOrder.xaml
    /// </summary>
    public partial class AdminViewOrder : Window
    {
        public AdminViewOrder()
        {
            InitializeComponent();
        }

        private void ButtonView_Click(object sender, RoutedEventArgs e)
        {
            AdminOrderBL adminOrderBL = new AdminOrderBL();
            dgadminorder.ItemsSource = adminOrderBL.GetOrderDetails();
            //IngredientValidations ingredientValidations = new IngredientValidations();
            //ingredientdata.ItemsSource = ingredientValidations.GetIngredient();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow objMain = new MainWindow();
            objMain.Show();
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            //AdminMenu menu = new AdminMenu();
            //menu.Show();
        }
    }
}
