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
using RecipeIngredientSystem.BL;
using RecipeIngredientSystem.Exceptions;

namespace RecipeIngredientSystem.PL
{
    /// <summary>
    /// Interaction logic for AdminAddRecipe.xaml
    /// </summary>
    public partial class AdminAddRecipe : Window
    {
        public AdminAddRecipe()
        {
            InitializeComponent();
        }

        private void btnaddrecipe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Recipe recipeadd = new Recipe();

                recipeadd.Name = txtrecipename.Text;
                recipeadd.Description = txtrecipedescription.Text;
                AdminRecipeBL recipeValidations = new AdminRecipeBL();
                bool addresult = recipeValidations.AddRecipeBL(recipeadd);
                if (addresult)
                    MessageBox.Show("Recipe Added");
                else
                    MessageBox.Show("Recipe Not Added");

            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Recipe recipeupdate = CheckNulls();

                AdminRecipeBL recipeValidations = new AdminRecipeBL();
                bool updateresult = recipeValidations.UpdateRecipeBL(recipeupdate);
                if (updateresult)
                    MessageBox.Show("Recipe Updated");
                else

                    MessageBox.Show("Recipe Not Updated");
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private Recipe CheckNulls()
        {
            Recipe recipemodify = new Recipe();
            if (!string.IsNullOrEmpty(txtrecipeId.Text))
            {
                recipemodify.RecipeId = Convert.ToInt32(txtrecipeId.Text);
            }
            if (!string.IsNullOrEmpty(txtrecipename.Text))
            {
                recipemodify.Name = txtrecipename.Text;
            }
            if (!string.IsNullOrEmpty(txtrecipedescription.Text))
            {
                recipemodify.Description = txtrecipedescription.Text;
            }
            return recipemodify;
        }
        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Recipe deleterecipe = CheckNulls();
                //Recipe recipedelete = new Recipe();
                //recipedelete.RecipeId = Convert.ToInt32(txtrecipeId.Text);
                //recipedelete.RecipeName = txtrecipename.Text;
                //recipedelete.Description = txtrecipedescription.Text;
                AdminRecipeBL recipeValidations = new AdminRecipeBL();
                bool deleteresult = recipeValidations.DeleteRecipeBL(deleterecipe.RecipeId);
                if (deleteresult != null)
                {
                    bool recipedeleted = recipeValidations.DeleteRecipeBL(deleterecipe.RecipeId);
                    if (recipedeleted)
                        MessageBox.Show("Recipe Deleted");
                    else
                        MessageBox.Show("Recipe not Deleted");

                }
                else
                {
                    MessageBox.Show("No Recipe Details Available");
                }
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);

            }
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

        private void btnsearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Recipe recipeupdate = CheckNulls();
                // Recipe recipesearch = new Recipe();
                //recipesearch.RecipeId = Convert.ToInt32(txtrecipeId.Text);
                // recipesearch.RecipeName = txtrecipename.Text;
                // recipesearch.Description = txtrecipedescription.Text;
                AdminRecipeBL recipeValidations = new AdminRecipeBL();
                Recipe searchresult = recipeValidations.SearchRecipeBL(recipeupdate.RecipeId);
                txtrecipeId.Text = Convert.ToString(searchresult.RecipeId);
                txtrecipename.Text = Convert.ToString(searchresult.Name);
                txtrecipedescription.Text = Convert.ToString(searchresult.Description);
            }
            catch (RecipeIngredientSystemExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnclear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtrecipeId.Clear();
            txtrecipename.Clear();
            txtrecipedescription.Clear();
            dgrecipedetails.ItemsSource = null;
        }

        private void btnlist_Click(object sender, RoutedEventArgs e)
        {
            AdminRecipeBL recipeValidations = new AdminRecipeBL();
            // dgrecipedetails.DataContext = recipeValidations.GetRecipes();
            dgrecipedetails.ItemsSource = recipeValidations.GetRecipes();
            // dgrecipedetails.Items.Add( recipeValidations.GetRecipes());
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminMenu adminmenupage = new AdminMenu(txtusername1.Text);
            adminmenupage.Show();
        }

        private void logoutbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainpage = new MainWindow();
            mainpage.Show();
        }

        private void homepagebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login loginpage = new Login();
            loginpage.Show();
        }

        private void txtrecipename_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
