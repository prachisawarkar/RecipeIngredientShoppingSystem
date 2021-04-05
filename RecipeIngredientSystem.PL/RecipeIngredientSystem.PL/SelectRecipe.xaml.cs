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
using System.Data.SqlClient;
using System.Data;
using RecipeIngredientSystem.BL;
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.Exceptions;

namespace RecipeIngredientSystem.PL
{
    /// <summary>
    /// Interaction logic for SelectRecipe.xaml
    /// </summary>
    public partial class SelectRecipe : Window
    {
        public SelectRecipe(string username)
        {
            InitializeComponent();
            //Customer username
            txtusername.Text = username.ToUpper();
            //function called to have list of recipe in combobox
            GetRecipes(cmbbox);
        }
        //get list of recipes in combobox
        private void GetRecipes(ComboBox cmbname)
        {
            //Recipe recipe = new Recipe(txtusername.Text);
            try
            {
                RecipeBL recipeBL = new RecipeBL();
                DataTable dt = recipeBL.GetRecipeListBL();
                cmbname.ItemsSource = dt.DefaultView;
                //shows the name of the recipes
                cmbname.DisplayMemberPath = dt.Columns["Name"].ToString();
                //selected value will be the recipeid
                cmbname.SelectedValuePath = dt.Columns["RecipeId"].ToString();
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //clicking on view button in datagrid 
        private void btnshow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                if (dataRowView[0].ToString() != null)
                {
                    int id = Convert.ToInt32(dataRowView[0].ToString());
                    this.Close();
                    AddToCart cartpage = new AddToCart(txtusername.Text, id);
                    //redirect to Add To Cart page
                    cartpage.Show();
                }
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //cart page button
        private void cartbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            OrderIngredient orderpage = new OrderIngredient(txtusername.Text);
            //redirect to order page
            orderpage.Show();
        }
        //get the selected combobox value
        private void cmbbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RecipeBL recipeBL = new RecipeBL();
            int recipeid;
            try
            {
                //chack value of ComboBox
                if (cmbbox.SelectedValue != null)
                {
                    recipeid = Convert.ToInt32(cmbbox.SelectedValue);
                    //shows the details of the recipe in data grid
                    DataTable dt = recipeBL.ViewRecipeBL(recipeid);
                    grid.ItemsSource = dt.DefaultView;
                }
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //back button
        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LoginCustomer objlogin = new LoginCustomer();
            //redirect to customer login page
            objlogin.Show();
        }
        //logout button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow objMain = new MainWindow();
            //redirect to main page
            objMain.Show();
        }
    }
}
