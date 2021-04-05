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
using RecipeIngredientSystem.BL;
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.Exceptions;
using System.Windows.Forms;

namespace RecipeIngredientSystem.PL
{
    /// <summary>
    /// Interaction logic for AdminIngredientManagement.xaml
    /// </summary>
    public partial class AdminIngredientManagement : Window
    {
        public AdminIngredientManagement()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = new Ingredient();
           // ingredient.IngredientId = Convert.ToInt32(txtingrid.Text);
            ingredient.RecipeId = Convert.ToInt32(txtrecid.Text);
            ingredient.Name = txtingrName.Text;
            ingredient.ManufacturerName = txtmanu.Text;
            ingredient.ManufacturerDate = Convert.ToDateTime(txtmanudate.DisplayDate);
            ingredient.ExpiryDate = Convert.ToDateTime(txtexpdate.DisplayDate);
            ingredient.Price = Convert.ToDecimal(txtprice.Text);
            ingredient.Description = txtdescrpt.Text;

            AdminIngredientBL ingredientValidations = new AdminIngredientBL();
            bool addresult = ingredientValidations.AddIngredient(ingredient);
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingredientDelete = CheckNulls();

            try
            {
                //ingredient.IngredientId = Convert.ToInt32(txtingrid.Text);                
                AdminIngredientBL ingredientValidations = new AdminIngredientBL();
                bool deleteresult = ingredientValidations.DeleteIngredient(ingredientDelete.IngredientId);
                if (deleteresult != null)//
                {//
                    bool recipedeleted = ingredientValidations.DeleteIngredient(ingredientDelete.RecipeId);//
                    if (recipedeleted)//
                        System.Windows.MessageBox.Show("Ingredient Deleted");//
                    else //
                        System.Windows.MessageBox.Show("Ingredient not Deleted");//

                }
                else
                {
                    System.Windows.MessageBox.Show("No Ingredient Available");//
                }
            }

            catch (RecipeIngredientSystemExceptions ex)//
            {//
                System.Windows.MessageBox.Show(ex.Message);//
            }//
        }

        private void ButtonModify_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Ingredient ingredientUpdate = CheckNulls();
                AdminIngredientBL ingredientValidations = new AdminIngredientBL();

                bool updateresult = ingredientValidations.ModifyIngredient(ingredientUpdate);
                if (updateresult)
                    System.Windows.MessageBox.Show("Ingredient Updated");//
                else

                    System.Windows.MessageBox.Show("Ingredient Not Updated");
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
        private Ingredient CheckNulls()
        {
            Ingredient ingredientChanges = new Ingredient();
            if (!string.IsNullOrEmpty(txtingrid.Text))
            {
                ingredientChanges.IngredientId = Convert.ToInt32(txtingrid.Text);
            }
            if (!string.IsNullOrEmpty(txtingrName.Text))
            {
                ingredientChanges.Name = txtingrName.Text;
            }
            if (!string.IsNullOrEmpty(txtrecid.Text))
            {
                ingredientChanges.RecipeId = Convert.ToInt32(txtrecid.Text);
            }
            if (!string.IsNullOrEmpty(txtmanu.Text))
            {
                ingredientChanges.ManufacturerName = txtmanu.Text;
            }
            if (!string.IsNullOrEmpty(txtmanudate.Text))
            {
                ingredientChanges.ManufacturerDate = Convert.ToDateTime(txtmanudate.Text);
            }
            if (!string.IsNullOrEmpty(txtprice.Text))
            {
                ingredientChanges.Price = Convert.ToDecimal(txtprice.Text);
            }
            if (!string.IsNullOrEmpty(txtexpdate.Text))
            {
                ingredientChanges.ExpiryDate = Convert.ToDateTime(txtexpdate.Text);
            }
            if (!string.IsNullOrEmpty(txtdescrpt.Text))
            {
                ingredientChanges.Description = txtdescrpt.Text;
            }

            return ingredientChanges;
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingredientSearch = CheckNulls();
            //ingredient.IngredientId = Convert.ToInt32(txtingrid.Text);
            try
            {
                AdminIngredientBL ingredientValidations = new AdminIngredientBL();
                Ingredient searchingredient = ingredientValidations.SearchIngredient(ingredientSearch.IngredientId);
                txtingrid.Text = searchingredient.IngredientId.ToString();
                txtingrName.Text = searchingredient.Name;
                txtrecid.Text = searchingredient.RecipeId.ToString();
                txtmanu.Text = searchingredient.ManufacturerName;
                txtmanudate.Text = searchingredient.ManufacturerDate.ToString();
                txtexpdate.Text = searchingredient.ExpiryDate.ToString();
                txtprice.Text = searchingredient.Price.ToString();
                txtdescrpt.Text = searchingredient.Description;
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void ButtonList_Click(object sender, RoutedEventArgs e)
        {
            AdminIngredientBL ingredientValidations = new AdminIngredientBL();
            ingredientdata.ItemsSource = ingredientValidations.GetIngredient();
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            txtdescrpt.Clear();
            txtingrName.Clear();
            //txtexpdate.DisplayDateStart = new DateTime(0001, 1, 1);
            txtexpdate.ClearValue(DatePicker.SelectedDateProperty);
            txtingrid.Clear();
            txtmanu.Clear();
            txtmanudate.ClearValue(DatePicker.SelectedDateProperty); 
            txtprice.Clear();
            txtrecid.Clear();
        }
        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);
        }
        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminMenu adminMenu = new AdminMenu(txtusername.Text);
            adminMenu.Show();
        }

        private void HomeButton_Click1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void LogoutButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow objMain = new MainWindow();
            objMain.Show();
        }

        
    }
}
