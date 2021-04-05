using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.Exceptions;
using RecipeIngredientSystem.DAL;
using System.Windows;
using System.Data;
using System.Data.Common;

namespace RecipeIngredientSystem.BL
{
    public class AdminRecipeBL
    {
        public static bool ValidateAddRecipe(Recipe addrecipe)
        {
            bool validRecipe = true;
            if (addrecipe.Name == string.Empty)
            {
                validRecipe = false;
                MessageBox.Show("Recipe Name Required");
            }

            if (addrecipe.Description == string.Empty)
            {
                validRecipe = false;
                MessageBox.Show("Recipe Description Required");
            }

            // if (validRecipe == false)
            //  throw new IngredientsRecipeShoppingExceptions();
            return validRecipe;
        }
        public static bool ValidateRecipe(Recipe recipe)
        {

            bool validRecipe = true;
            if (recipe.RecipeId <= 0)
            {
                validRecipe = false;
                MessageBox.Show("Invalid RecipeId");
            }
            if (recipe.Name == string.Empty)
            {
                validRecipe = false;
                MessageBox.Show("Recipe Name Required");
            }

            if (recipe.Description == string.Empty)
            {
                validRecipe = false;
                MessageBox.Show("Recipe Description Required");
            }
            // if (validRecipe == false)
            //  throw new IngredientsRecipeShoppingExceptions();
            return validRecipe;
        }

        public bool AddRecipeBL(Recipe recipeadd)
        {
            bool recipeAdded = false;
            try
            {
                if (ValidateAddRecipe(recipeadd))
                {
                    AdminRecipeDAL recipeDAL = new AdminRecipeDAL();
                    recipeAdded = recipeDAL.AddRecipeDAL(recipeadd);
                }
            }
            catch (RecipeIngredientSystemExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return recipeAdded;
        }


        public bool UpdateRecipeBL(Recipe recipeupdate)
        {
            bool RecipeUpdated = false;
            try
            {
                if (ValidateRecipe(recipeupdate))
                {
                    AdminRecipeDAL recipeDAL = new AdminRecipeDAL();
                    RecipeUpdated = recipeDAL.UpdateRecipeDAL(recipeupdate);
                }
            }
            catch (RecipeIngredientSystemExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RecipeUpdated;
        }


        public bool DeleteRecipeBL(int deleteRecipeId)
        {
            bool RecipeDeleted = false;
            try
            {
                if (deleteRecipeId > 0)
                {
                    AdminRecipeDAL recipeDAL = new AdminRecipeDAL();
                    RecipeDeleted = recipeDAL.DeleteRecipeDAL(deleteRecipeId);
                }
                else
                {
                    throw new RecipeIngredientSystemExceptions("Invalid Recipe ID");
                }
            }
            catch (RecipeIngredientSystemExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RecipeDeleted;
        }

        public Recipe SearchRecipeBL(int searchRecipeId)
        {
            Recipe searchRecipe = null;
            try
            {
                Recipe recipe = new Recipe();
               
                
                    AdminRecipeDAL recipeDAL = new AdminRecipeDAL();
                    searchRecipe = recipeDAL.SearchRecipeDAL(searchRecipeId);
                
              

            }

            catch (RecipeIngredientSystemExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchRecipe;
        }

        public List<Recipe> GetRecipes()
        {
            AdminRecipeDAL recipeDAL = new AdminRecipeDAL();
            List<Recipe> recipes = recipeDAL.GetRecipe();
            return recipes;
        }
    }
}
