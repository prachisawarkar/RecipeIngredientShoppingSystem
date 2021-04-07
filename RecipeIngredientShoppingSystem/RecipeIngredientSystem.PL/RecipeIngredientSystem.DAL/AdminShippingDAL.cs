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
    public class AdminShippingDAL
    {
        public bool UpdateRecipeDAL(Shipping shipupdate)
        {
            bool ShippingUpdated = false;
            try
            {
                //
                int shippingnumber;
                //int orderId;
                DateTime expecteddeliverydate;

                //
                shippingnumber = Convert.ToInt32(shipupdate.ShippingNumber);
                //orderId = Convert.ToInt32(shipupdate.OrderId);

                expecteddeliverydate = Convert.ToDateTime(shipupdate.ExpectedDeliveryDate);
                //
                SqlConnection objCon = new SqlConnection(Database.ConnectionString);
                SqlCommand objCom = new SqlCommand(Database.UPADTEADMINSHIP, objCon);
                objCom.CommandType = CommandType.StoredProcedure;
                //
                 SqlParameter objSqlParam_shippingnumber = new SqlParameter("@shippingNumber", SqlDbType.Int); // @ SHIPID 
                //SqlParameter objSqlParam_orderId = new SqlParameter("", SqlDbType.Int); // @ ORDERID

                SqlParameter objSqlParam_expecteddeliverydate = new SqlParameter("@ExpectedDeliveryDate", SqlDbType.DateTime);// @ EXP DTAE
                //
                objSqlParam_shippingnumber.Direction = ParameterDirection.Input;
               // objSqlParam_orderId.Direction = ParameterDirection.Input;

                objSqlParam_expecteddeliverydate.Direction = ParameterDirection.Input;
                //
                objSqlParam_shippingnumber.Value = shippingnumber;
              //  objSqlParam_orderId.Value = orderId;

                objSqlParam_expecteddeliverydate.Value = expecteddeliverydate;
                //
                objCom.Parameters.Add(objSqlParam_shippingnumber);
                //objCom.Parameters.Add(objSqlParam_orderId);

                objCom.Parameters.Add(objSqlParam_expecteddeliverydate);
                //
                objCon.Open();

                int noOfRowsAffected = objCom.ExecuteNonQuery();
                objCon.Close();
                if (noOfRowsAffected > 0)
                {
                    MessageBox.Show("Shipping Details Updated Successfully.");
                }
                ShippingUpdated = true;
            }
            catch (DbException ex)
            {
                string errormessage;

                switch (ex.ErrorCode)
                {
                    case -2146232060:
                        errormessage = "Database Does NotExists Or AccessDenied";
                        break;
                    default:
                        errormessage = ex.Message;
                        break;
                }
                throw new RecipeIngredientSystemExceptions(errormessage);
            }
            return ShippingUpdated;
        }
        public List<Shipping> GetAdminShippingDAL()
        {
            List<Shipping> ShippingItems = new List<Shipping>();

            SqlConnection objCon = new SqlConnection(Database.ConnectionString);
            SqlCommand objCom = new SqlCommand(Database.GETSHIP, objCon);
            objCom.CommandType = CommandType.StoredProcedure;
            objCon.Open();
            SqlDataReader objDR = objCom.ExecuteReader();

            while (objDR.Read())
            {
                Shipping getlist = new Shipping();
                getlist.ShippingNumber = objDR.GetInt32(0);
                getlist.OrderId = objDR.GetInt32(1);

                getlist.ExpectedDeliveryDate = objDR.GetDateTime(2);
                ShippingItems.Add(getlist);
            }
            DataTable objDT = new DataTable();
            objDT.Load(objDR);
            objCon.Close();
            return ShippingItems;
        }
    }
}
