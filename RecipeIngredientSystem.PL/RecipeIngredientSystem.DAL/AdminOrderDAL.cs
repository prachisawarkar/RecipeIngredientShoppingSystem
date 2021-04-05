using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.Exceptions;

namespace RecipeIngredientSystem.DAL
{
    public class AdminOrderDAL
    {
        public List<AdminOrder> GetOrderDetails()
        {
            List<AdminOrder> adminOrders = new List<AdminOrder>();
            //try{

            SqlConnection objCon = new SqlConnection(Database.ConnectionString);
            SqlCommand objCom = new SqlCommand(Database.ADMINORDERMANAGER, objCon);
            objCom.CommandType = CommandType.StoredProcedure;
            objCon.Open();
            SqlDataReader objDR = objCom.ExecuteReader();

            while (objDR.Read())
            {
                AdminOrder getlist = new AdminOrder();
                getlist.OrderIngredientId = objDR.GetInt32(0);
                getlist.CustomerId = objDR.GetInt32(1);
                //getlist.IngredientId = objDR.GetInt32(2);
                //getlist.CartId = objDR.GetInt32(2);
                getlist.DateOfOrder = objDR.GetDateTime(2);
                getlist.MobileNumber = objDR.GetString(3);
                getlist.DeliveryAddress = objDR.GetString(4);
                getlist.TotalBillAmount = objDR.GetDecimal(5);
                getlist.NumberOfIngredients = objDR.GetInt32(6);
                getlist.GrandTotal = objDR.GetDecimal(7);

                adminOrders.Add(getlist);
            }

            DataTable objDT = new DataTable();
            objDT.Load(objDR);
            objCon.Close();

            //}
            //catch (DbException ex)
            //{
            //    throw new IngredientsRecipeShoppingExceptions(ex.Message);
            //}
            return adminOrders;
        }
    }
}
