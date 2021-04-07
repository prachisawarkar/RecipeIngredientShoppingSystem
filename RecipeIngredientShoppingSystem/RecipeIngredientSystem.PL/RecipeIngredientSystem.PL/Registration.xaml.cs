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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void btnaddadmin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AdminRegistration adminregistrationpage = new AdminRegistration();
            adminregistrationpage.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            CustomerRegistration customerregistrationpage = new CustomerRegistration();
            customerregistrationpage.Show();
        }
        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow objPage = new MainWindow();
            objPage.Show();
        }
    }
}
