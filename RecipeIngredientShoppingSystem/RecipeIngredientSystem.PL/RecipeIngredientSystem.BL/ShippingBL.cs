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
    public class ShippingBL
    {
        //shipping details list
        public List<Shipping> GetShippingDetails(string username)
        {
            List<Shipping> shippings = new List<Shipping>();

            try
            {
                ShippingDAL shippingDAL = new ShippingDAL();
                //call to ShippingDAL function
                shippings = shippingDAL.ViewShippingDetail(username);
            }
            catch (RecipeIngredientSystemExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return shippings;
        }
    }
}
