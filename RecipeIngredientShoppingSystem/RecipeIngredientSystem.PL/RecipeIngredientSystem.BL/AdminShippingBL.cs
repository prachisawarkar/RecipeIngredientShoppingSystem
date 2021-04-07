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
    public class AdminShippingBL
    {
        public static bool ValidateDetails(Shipping ship)
        {
            bool validship = true;

            if (ship.ShippingNumber <= 0)
            {
                 validship = false;
            }
            //if (ship.OrderId <= 0 || ship.OrderId ==null)
            //{
            //    validship = false;
            //}
            return validship;
        }
        public bool UpdateAdminShippingBL(Shipping shipupdate)
        {
            bool Shipupdated = false;
            try
            {
                if (ValidateDetails(shipupdate))
                {
                    AdminShippingDAL shipDAL = new AdminShippingDAL();
                    Shipupdated = shipDAL.UpdateRecipeDAL(shipupdate);
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
            return Shipupdated;
        }
        public List<Shipping> GetAdminShiipingBL()
        {
            AdminShippingDAL shipDAL = new AdminShippingDAL();
            List<Shipping> ship = shipDAL.GetAdminShippingDAL();
            return ship;
        }
    }
}
