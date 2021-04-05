using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RecipeIngredientSystem.DAL;
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.Exceptions;

namespace RecipeIngredientSystem.BL
{
    public class RecipeBL
    {
        //get recipe list in combobox
        public DataTable GetRecipeListBL()
        {
            try
            {
                RecipeDAL recipeDAL = new RecipeDAL();
                //call the RecipeDAL function
                DataTable dt = recipeDAL.GetRecipeListDAL();
                return dt;
            }
            catch (RecipeIngredientSystemExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //view selected recipe details
        public DataTable ViewRecipeBL(int recipeid)
        {
            try
            {
                RecipeDAL recipeDAL = new RecipeDAL();
                //call the RecipeDAL function
                DataTable dt = recipeDAL.ViewRecipeDAL(recipeid);
                return dt;
            }
            catch (RecipeIngredientSystemExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
