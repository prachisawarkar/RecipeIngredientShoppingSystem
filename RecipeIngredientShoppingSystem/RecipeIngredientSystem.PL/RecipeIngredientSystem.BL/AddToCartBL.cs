using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.Exceptions;
using RecipeIngredientSystem.DAL;

namespace RecipeIngredientSystem.BL
{
    public class AddToCartBL
    {
        //validation of cart
        public static bool ValidateCart(Cart cart)
        {
            StringBuilder sb = new StringBuilder();
            bool validCart = true;
            
            if (cart.IngredientID <= 0)
            {
                validCart = false;
                sb.Append(Environment.NewLine + "Invalid Ingredient ID");
            }
            if (cart.IngredientQuantity <= 0)
            {
                validCart = false;
                sb.Append(Environment.NewLine + "Invalid Ingredient Quantity");
            }
            if (cart.Amount <= 0)
            {
                validCart = false;
                sb.Append(Environment.NewLine + "Invalid Ingredient Amount");
            }

            if (validCart == false)
                throw new RecipeIngredientSystemExceptions(sb.ToString());
            return validCart;
        }
        //add details to cart
        public bool AddCartBL(Cart cart, string username)
        {
            try
            {
                if(cart != null) 
                {
                    //validate cart before adding
                    if(ValidateCart(cart))
                    {
                        AddToCartDAL addtocartDAL = new AddToCartDAL();
                        //call to AddToCartDAL function
                        if (addtocartDAL.AddIngToCartDAL(cart, username))
                        {
                            return true;
                        }
                    }
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
            return false;
        }
        /*public bool CartAddBL(Cart cart, string username)
        {
            
            bool cartAdded = false;
            try
            {
                if(ValidateCart(cart))
                {
                    AddToCartDAL addtocartDAL = new AddToCartDAL();
                    cartAdded = addtocartDAL.AddIngToCartDAL(cart, username);
                }
            }
            catch(RecipeIngredientSystemExceptions)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return cartAdded;
        }*/
        //get list of selected recipe ingredient
        public List<Ingredient> GetIngredientBL(int id)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            try
            {
                AddToCartDAL addtocartDAL = new AddToCartDAL();
                //call to AddToCartDAL function
                ingredients = addtocartDAL.GetIngredientDAL(id);
            }
            catch (RecipeIngredientSystemExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ingredients;
        }
    }
}
