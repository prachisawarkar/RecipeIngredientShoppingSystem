using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.Exceptions;
using RecipeIngredientSystem.DAL;
using System.Windows;

namespace RecipeIngredientSystem.BL
{
    public class AdminIngredientBL
    {
        public static bool ValidateIngredientadd(Ingredient ingredientadd)
        {
            StringBuilder sb = new StringBuilder();
            bool validIngredient = true;
            //if (ingredientadd.IngredientId <= 0)
            //{
            //    validIngredient = false;
            //}
            if (ingredientadd.Name == string.Empty)
            {
                validIngredient = false;
                sb.Append(Environment.NewLine + "Name Required");
            }
            if (ingredientadd.RecipeId <= 0)
            {
                validIngredient = false;
                sb.Append(Environment.NewLine + "RecipeId Required");
            }
            if (ingredientadd.ManufacturerName == string.Empty)
            {
                validIngredient = false;
                sb.Append(Environment.NewLine + "Manufacturer Name Required");
            }
            /*if (ingredientadd.ManufacturerDate < ingredientadd.ExpiryDate)
            {
                validIngredient = false;
                sb.Append(Environment.NewLine + "Manufacturer Date Required");
            }*/
            if (ingredientadd.Price <= 0)
            {
                validIngredient = false;
                sb.Append(Environment.NewLine + "Price Required");
            }
            if (ingredientadd.Description == string.Empty)
            {
                validIngredient = false;
                sb.Append(Environment.NewLine + "Description Required");
            }
            /*if (ingredientadd.ExpiryDate.ToShortDateString() > ingredientadd.ManufacturerDate.ToShortDateString())
            {
                validIngredient = false;
                sb.Append(Environment.NewLine + "ManufacturerDate Required");
            }*/
            if(DateTime.Compare(ingredientadd.ManufacturerDate, ingredientadd.ExpiryDate) > 0)
            {
                validIngredient = false;
                sb.Append(Environment.NewLine + "Manufacturer Date should be less than Expiry Date");
            }
            if (validIngredient == false)
                throw new RecipeIngredientSystemExceptions(sb.ToString());
            return validIngredient;
        }
        public static bool ValidateIngredient(Ingredient ingredient)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool validIngredient = true;
            if (ingredient.IngredientId <= 0)
            {
                validIngredient = false;
                stringBuilder.Append(Environment.NewLine + "IngredientId Required");
            }
            if (ingredient.Name == string.Empty)
            {
                validIngredient = false;
                stringBuilder.Append(Environment.NewLine + "Name Required");
            }
            if (ingredient.RecipeId <= 0)
            {
                validIngredient = false;
                stringBuilder.Append(Environment.NewLine + "RecipeId Required");
            }
            if (ingredient.ManufacturerName == string.Empty)
            {
                validIngredient = false;
                stringBuilder.Append(Environment.NewLine + "Manufacturer Name Required");
            }
            if (ingredient.Price <= 0)
            {
                validIngredient = false;
                stringBuilder.Append(Environment.NewLine + "Price Required");
            }
            if (ingredient.Description == string.Empty)
            {
                validIngredient = false;
                stringBuilder.Append(Environment.NewLine + "Description Required");
            }
            if (validIngredient == false)
                throw new RecipeIngredientSystemExceptions(stringBuilder.ToString());
            return validIngredient;
        }
        public bool AddIngredient(Ingredient ingredient)
        {
            bool ingredientAdded = false;
            try
            {
                if (ValidateIngredientadd(ingredient))
                {
                    IngredientDAL ingredientDAL = new IngredientDAL();
                    ingredientAdded = ingredientDAL.InsertIngredients(ingredient);
                }
            }
            catch (RecipeIngredientSystemExceptions)
            {
                throw;
                //MessageBox.Show("Do not leave any field blank.");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ingredientAdded;
        }
        public bool ModifyIngredient(Ingredient ingredient)
        {
            bool ingredientUpdated = false;
            try
            {
                if (ValidateIngredient(ingredient))
                {
                    IngredientDAL ingredientDAL = new IngredientDAL();
                    ingredientUpdated = ingredientDAL.ModifyIngredient(ingredient);
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
            return ingredientUpdated;
        }

        public bool DeleteIngredient(int ingredientId)
        {
            bool ingredientDeleted = false;
            try
            {
                if (ingredientId > 0)
                {
                    IngredientDAL ingredientDAL = new IngredientDAL();
                    ingredientDeleted = ingredientDAL.DeleteIngredient(ingredientId);
                }
                else
                {
                    throw new RecipeIngredientSystemExceptions("Invalid Ingredient ID");
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

            return ingredientDeleted;
        }

        public Ingredient SearchIngredient(int IngredientId)
        {
            Ingredient searchIngredient = null;
            try
            {
                IngredientDAL ingredientDAL = new IngredientDAL();
                searchIngredient = ingredientDAL.SearchIngredient(IngredientId);
            }

            catch (RecipeIngredientSystemExceptions)
            {
                MessageBox.Show("Enter valid IngredientId to search an ingredient.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchIngredient;
        }
        public List<Ingredient> GetIngredient()
        {
            IngredientDAL ingredientDAL = new IngredientDAL();
            List<Ingredient> ingredients = ingredientDAL.GetIngredients();
            return ingredients;
        }
    }
}
