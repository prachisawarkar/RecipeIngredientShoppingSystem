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
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.BL;
using RecipeIngredientSystem.Exceptions;

namespace RecipeIngredientSystem.PL
{
    /// <summary>
    /// Interaction logic for OrderIngredient.xaml
    /// </summary>
    public partial class OrderIngredient : Window
    {
        public OrderIngredient(string username)
        {
            InitializeComponent();
            //Customer username
            txtusername.Text = username.ToUpper();
           
            /*OrderIngredientBL orderIngredientBL = new OrderIngredientBL();
            decimal totalamount = orderIngredientBL.Totalamount(username);
            //calculate total amount
            txttamount.Text = totalamount.ToString();
            //calculate gst
            txtgst1.Text = ((Convert.ToDecimal(txttamount.Text) * 18) / 100).ToString();

            //calculate grand total including gst
            txtgtotal.Text = (Convert.ToDecimal(txttamount.Text) + Convert.ToDecimal(txtgst1.Text)).ToString();*/
        }
        //To take only numeric data
        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);
        }
        private bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);
        }
        //check null for update cart
        private Cart CheckNulls()
        {
            Cart objCart = new Cart();
            if (!string.IsNullOrEmpty(txtcartid.Text))
            {
                objCart.CartId = Convert.ToInt32(txtcartid.Text);//cart id textbox
            }
            if (!string.IsNullOrEmpty(txtquantity1.Text))
            {
                objCart.IngredientQuantity = Convert.ToDecimal(txtquantity1.Text);//quantity textbox
            }
            if (!string.IsNullOrEmpty(txtamount1.Text))
            {
                objCart.Amount = Convert.ToDecimal(txtamount1.Text);//amount textbox
            }
            return objCart;
        }
        //update cart
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cart objCart = new Cart();
            OrderIngredientBL orderIngredientBL = new OrderIngredientBL();

            try
            {
                //check null values
                objCart = CheckNulls();

                bool result = orderIngredientBL.UpdateCartBL(objCart);
                if (result == true)
                {
                    MessageBox.Show("Cart Updated!");
                    //clear data
                    Clear();
                    //update the datagrid
                    gridview_data();
                }
                else
                {
                    MessageBox.Show("Cart Not Updated!");
                }
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //view my carts
        private void Viewcartbtn_Click(object sender, RoutedEventArgs e)
        {
            gridview_data();
        }
        //show grid data
        public void gridview_data()
        {
            try
            {
                string username;
                //check null values
                if (!string.IsNullOrEmpty(txtusername.Text))
                {
                    //take username
                    username = txtusername.Text;
                    OrderIngredientBL orderIngredientBL = new OrderIngredientBL();
                    //get cart details of customer
                    grid.ItemsSource = orderIngredientBL.GetCartBL(username);
                    //OrderIngredientBL orderIngredientBL = new OrderIngredientBL();
                    decimal totalamount = orderIngredientBL.Totalamount(username);
                    //calculate total amount
                    txttamount.Text = totalamount.ToString();
                    //calculate gst
                    txtgst1.Text = ((Convert.ToDecimal(txttamount.Text) * 18) / 100).ToString();

                    //calculate grand total including gst
                    txtgtotal.Text = (Convert.ToDecimal(txttamount.Text) + Convert.ToDecimal(txtgst1.Text)).ToString();
                }
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //check null values for add order
        private OrderCartIngredient CheckNullsforOrderAdd()
        {
            OrderCartIngredient orderAdded = new OrderCartIngredient();
            if (!string.IsNullOrEmpty(txtmobilenum.Text))
                orderAdded.MobileNumber = txtmobilenum.Text;//mobile number textbox
            if (!string.IsNullOrEmpty(txtaddress.Text))
                orderAdded.DeliveryAddress = txtaddress.Text;//delivery address textbox
            if (!string.IsNullOrEmpty(txttamount.Text))
                orderAdded.TotalBillAmount = Convert.ToDecimal(txttamount.Text);//total bill amount textbox
            if (!string.IsNullOrEmpty(txtgtotal.Text))
                orderAdded.GrandTotal = Convert.ToDecimal(txtgtotal.Text);//grand amount textbox

            return orderAdded;
        }
        private void Orderbtn_Click(object sender, RoutedEventArgs e)
        {
            OrderCartIngredient orderAdded = new OrderCartIngredient();
            OrderIngredientBL orderIngredientBL = new OrderIngredientBL();
            try
            {
                string username = "";
                //check null values
                if (!string.IsNullOrEmpty(txtusername.Text))
                    username = txtusername.Text;//username textbox

                orderAdded = CheckNullsforOrderAdd();

                bool result = orderIngredientBL.AddOrderBL(orderAdded, username);
                if (result == true)
                {
                    MessageBox.Show("Order Placed!");
                    this.Close();
                    ShippingDetails shipppingpage = new ShippingDetails(txtusername.Text);
                    //redirect to shipping details page
                    shipppingpage.Show();
                }
                else
                {
                    MessageBox.Show("Order not Placed!");
                }
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //on select grid row
        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                MyCart mycart = grid.SelectedItem as MyCart;
                //check null values
                if (mycart != null)
                {
                    if (mycart.CartId >= 0)
                        txtcartid.Text = Convert.ToString(mycart.CartId);//cart id textbox
                    if (mycart.Price >= 0)
                        txtprice1.Text = Convert.ToString(mycart.Price);//ingredient price textbox
                    if (mycart.IngredientQuantity >= 0)
                        txtquantity1.Text = Convert.ToString(mycart.IngredientQuantity);//ingredient quantity textbox
                }
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtquantity1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //check null values
                if (!string.IsNullOrEmpty(txtprice1.Text))
                {
                    if (!string.IsNullOrEmpty(txtquantity1.Text))
                    {
                        //calculate amount 
                        //amount = price of 1 ingredient x quantity
                        txtamount1.Text = (Convert.ToDecimal(txtprice1.Text) * Convert.ToDecimal(txtquantity1.Text)).ToString();
                    }
                }
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Delete button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Cart objCart = new Cart();
            OrderIngredientBL orderIngredientBL = new OrderIngredientBL();
            try
            {
                //check null values
                if (!string.IsNullOrEmpty(txtcartid.Text))
                    objCart.CartId = Convert.ToInt32(txtcartid.Text);
                //if cart contains data then only delete it
                if (objCart != null)
                {
                    bool result = orderIngredientBL.DeleteCartBL(objCart);
                    if (result == true)
                    {
                        MessageBox.Show("Cart Deleted!");
                        //Clear fields
                        Clear();
                        //show the updated datagrid
                        gridview_data();
                    }
                    else
                    {
                        MessageBox.Show("Cart Not Deleted!");
                    }
                }
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //back button
        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            SelectRecipe cartpage = new SelectRecipe(txtusername.Text);
            //redirect to select recipe page
            cartpage.Show();
        }
        //logout button
        private void logoutbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainpage = new MainWindow();
            //redirect to main page
            mainpage.Show();
        }
        //refresh button
        /*private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                string username;
                if (!string.IsNullOrEmpty(txtusername.Text))
                {
                    username = txtusername.Text;
                    OrderIngredientBL orderIngredientBL = new OrderIngredientBL();
                    grid.ItemsSource = orderIngredientBL.GetCartBL(username);
                }
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/

        //to clear the fields
        public void Clear()
        {
            txtcartid.Text = "";
            txtprice1.Text = "";
            txtquantity1.Text = "";
            txtamount1.Text = "";
        }
    }
}
