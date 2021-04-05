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
    public class AdminOrderBL
    {
        public List<AdminOrder> GetOrderDetails()
        {
            // List<AdminOrders> adminOrders = null;
            //try
            //{
            AdminOrderDAL adminOrderDAL = new AdminOrderDAL();
            List<AdminOrder> orders = adminOrderDAL.GetOrderDetails();
            //}
            //catch (IngredientsRecipeShoppingExceptions ex)
            //{
            //    throw ex;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //return adminOrders;
            return orders;
        }
    }
}
