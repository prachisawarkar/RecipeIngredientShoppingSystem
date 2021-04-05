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
using System.Configuration;
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.Exceptions;
using RecipeIngredientSystem.BL;

namespace RecipeIngredientSystem.PL
{
    /// <summary>
    /// Interaction logic for AddToCart.xaml
    /// </summary>
    public partial class AddToCart : Window
    {
        public AddToCart(string username, int id)
        {
            InitializeComponent();
            //Customer username
            txtusername1.Text = username.ToUpper();
            //recipe id
            txtid.Text = id.ToString();
        }
        //Take only Numeric data 
        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);
        }

        private bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);
        }

        private void AddToCart_Load(object sender, EventArgs e)
        {
           
        }
        //on grid row selection 
        private void listofingredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Ingredient ingredient = listofingredients.SelectedItem as Ingredient;
                if (ingredient != null)
                {
                    //validate data for null values
                    if (ingredient.IngredientId >= 0)
                        txtingredient.Text = Convert.ToString(ingredient.IngredientId);//ingredient id textbox
                    if (ingredient.Price >= 0)
                        txtprice.Text = Convert.ToString(ingredient.Price);//ingredient price textbox
                }
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //view ingredients of selected recipe
        private void viewbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txtid.Text != null)
                {
                    int recipeid = Convert.ToInt32(txtid.Text);
                    AddToCartBL addtocartBL = new AddToCartBL();
                    //get list of recipe ingredients
                    listofingredients.ItemsSource = addtocartBL.GetIngredientBL(recipeid);
                }
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
            //listofingredients.ItemsSource = dt.DefaultView;
        }

        private void addtocartbtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addtocartbtn_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Cart cartAdded = new Cart();
                string username = "";
                AddToCartBL cartBL = new AddToCartBL();

                //Check for null values 
                if (!string.IsNullOrEmpty(txtusername1.Text))
                {
                    username = txtusername1.Text;//username textbox
                }
                if (!string.IsNullOrEmpty(txtingredient.Text))
                {
                    cartAdded.IngredientID = Convert.ToInt32(txtingredient.Text);//ingredient id textbox
                }
                if (!string.IsNullOrEmpty(txtquantity.Text))
                {
                    cartAdded.IngredientQuantity = Convert.ToDecimal(txtquantity.Text);//ingredient quantity textbox
                }
                if (!string.IsNullOrEmpty(txtamount.Text))
                {
                    cartAdded.Amount = Convert.ToDecimal(txtamount.Text);//amount textbox
                }
                
                bool result = cartBL.AddCartBL(cartAdded, username);
                if (result == true)
                {
                    MessageBox.Show("Ingredient Added to Cart!");
                    this.Close();
                    OrderIngredient orderpage = new OrderIngredient(txtusername1.Text);
                    //Redirect to order page 
                    orderpage.Show();
                }
                else
                {
                    MessageBox.Show("Ingredient Not Added to Cart!");
                }
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtquantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            Cart cartAdded = new Cart();
            //Check for null values
            try
            {
                if (!string.IsNullOrEmpty(txtprice.Text))
                {
                    if (!string.IsNullOrEmpty(txtquantity.Text))
                    {
                        //calculate amount 
                        //amount = price of 1 ingredient x quantity
                        txtamount.Text = (float.Parse(txtprice.Text) * float.Parse(txtquantity.Text)).ToString();
                    }
                }
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //My Carts
        private void cartbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            OrderIngredient orderpage = new OrderIngredient(txtusername1.Text);
            //redirect to order page
            orderpage.Show();
        }
        //logout
        private void logoutbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainpage = new MainWindow();
            //redirect to main page
            mainpage.Show();
        }
        //back button - take to the select recipe page
        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            SelectRecipe recipepage = new SelectRecipe(txtusername1.Text);
            //redirect to select recipe page
            recipepage.Show();
        }
    }
}
