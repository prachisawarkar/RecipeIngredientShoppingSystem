using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.Exceptions;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Data.Common;

namespace RecipeIngredientSystem.DAL
{
    public class ShippingDAL
    {
        //list of shipping details
        public List<Shipping> ViewShippingDetail(string username)
        {
            List<Shipping> ShippingList = new List<Shipping>();
            try
            {
                //Connection to database
                SqlConnection objCon = new SqlConnection(Database.ConnectionString);
                //get sql stored procedure to execute
                SqlCommand objCom = new SqlCommand(Database.VIEWSHIPPINGDETAILS, objCon);

                //setting command type to stored procedure
                objCom.CommandType = CommandType.StoredProcedure;
                //Defining parameters for StoredProcedure
                SqlParameter objSP_username = new SqlParameter("@username", username);
                objCom.Parameters.Add(objSP_username);

                SqlDataAdapter da = new SqlDataAdapter(objCom);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                //fill the dataset
                da.Fill(ds, "Shipping");
                dt = ds.Tables["Shipping"];

                //fetch data and create a list
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Shipping objShipping = new Shipping();
                    objShipping.ShippingNumber = Convert.ToInt32(dt.Rows[i]["ShippingNumber"]);
                    objShipping.OrderId = Convert.ToInt32(dt.Rows[i]["OrderId"]);
                    objShipping.ExpectedDeliveryDate = Convert.ToDateTime(dt.Rows[i]["ExpectedDeliveryDate"]);
                    ShippingList.Add(objShipping);
                }
            }
            catch (DbException ex)
            {
                string errormessage;//take error message

                switch (ex.ErrorCode)
                {
                    case -2146232060:
                        errormessage = "Try again !";
                        break;
                    default:
                        errormessage = ex.Message;
                        break;
                }
                throw new RecipeIngredientSystemExceptions(errormessage);
            }
            return ShippingList;
        }
    }
}
