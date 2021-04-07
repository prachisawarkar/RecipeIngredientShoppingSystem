using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace RecipeIngredientSystem.DAL
{
    public class OrderIngredientDAL
    {
        //get my cart list
        public List<MyCart> GetMyCartDAL(string username)
        {
            //define cartlist
            List<MyCart> MyCartList = new List<MyCart>();
            try
            {
                //Connection to database
                SqlConnection objCon = new SqlConnection(Database.ConnectionString);
                //get sql stored procedure to execute
                SqlCommand objCom = new SqlCommand(Database.VIEWMYCARTS, objCon);

                //setting command type to stored procedure
                objCom.CommandType = CommandType.StoredProcedure;
                //Defining parameters for StoredProcedure
                SqlParameter objSP_username = new SqlParameter("@username", username);
                //Add parameter
                objCom.Parameters.Add(objSP_username);

                //open connection
                objCon.Open();
                SqlDataReader sqlDataReader = objCom.ExecuteReader();
                
                //fetch data
                while (sqlDataReader.Read())
                {
                    //mycart entity object
                    MyCart mycart = new MyCart();

                    mycart.CartId = sqlDataReader.GetInt32(0);
                    mycart.Name = sqlDataReader.GetString(1);
                    mycart.IngredientQuantity = sqlDataReader.GetDecimal(2);
                    mycart.Price = sqlDataReader.GetDecimal(3);
                    mycart.Amount = sqlDataReader.GetDecimal(4);
                    MyCartList.Add(mycart);
                }
                //clsoe connection
                objCon.Close();
            }
            catch (Exception ex)
            {
                throw new RecipeIngredientSystemExceptions(ex.Message);
            }
            return MyCartList;

                /*SqlDataAdapter da = new SqlDataAdapter(objCom);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds);

                dt = ds.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                { 
                    MyCart objMyCart = new MyCart();
                    objMyCart.CartId = Convert.ToInt32(dt.Rows[i]["CartId"]);
                    objMyCart.IngredientName = Convert.ToString(dt.Rows[i]["IngredientName"]);
                    objMyCart.IngredientQuantity = Convert.ToDecimal(dt.Rows[i]["IngredientQuantity"]);
                    objMyCart.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                    objMyCart.Amount = Convert.ToDecimal(dt.Rows[i]["Amount"]);
                    MyCartList.Add(objMyCart);
                }
            return MyCartList;*/
            
        }
        //add order
        public bool AddOrderDAL(OrderCartIngredient orderadd, string username)
        {
            bool orderAdded = false;
            //Connection to database
            SqlConnection objCon = new SqlConnection(Database.ConnectionString);
            //get sql stored procedure to execute
            SqlCommand objCom = new SqlCommand(Database.PLACEORDER, objCon);

            //setting command type to stored procedure
            objCom.CommandType = CommandType.StoredProcedure;

            //declare the variables
            string mobilenum;
            string address;
            decimal tamount;
            decimal gtotal;

            //assign values to the variables
            mobilenum = orderadd.MobileNumber;
            address = orderadd.DeliveryAddress;
            tamount = orderadd.TotalBillAmount;
            gtotal = orderadd.GrandTotal;

            //define sql parameters
            SqlParameter objSP_username = new SqlParameter("@username", username);
            SqlParameter objSP_mobilenum = new SqlParameter("@MobileNumber", mobilenum);
            SqlParameter objSP_address = new SqlParameter("@DeliveryAddress", address);
            SqlParameter objSP_tamount = new SqlParameter("@TotalBillAmount", tamount);
            SqlParameter objSP_gtotal = new SqlParameter("@GrandTotal", gtotal);

            //add parameters
            objCom.Parameters.Add(objSP_username);
            objCom.Parameters.Add(objSP_mobilenum);
            objCom.Parameters.Add(objSP_address);
            objCom.Parameters.Add(objSP_tamount);
            objCom.Parameters.Add(objSP_gtotal);

            //open connection
            objCon.Open();
            int i = objCom.ExecuteNonQuery();
            //close connection
            objCon.Close();
            try
            {
                if (i > 0)
                {
                    orderAdded = true;
                }
            }
            catch (Exception ex)
            {
                string
                errormessage = ex.Message;
                throw new RecipeIngredientSystemExceptions(errormessage);
            }
            return orderAdded;
        }

        //Update cart
        public bool UpdateCartDAL(Cart cart)
        {
            bool cartUpdated = false;
            //Connection to database
            SqlConnection objCon = new SqlConnection(Database.ConnectionString);
            //get sql stored procedure to execute
            SqlCommand objCom = new SqlCommand(Database.UPDATECART, objCon);

            //setting command type to stored procedure
            objCom.CommandType = CommandType.StoredProcedure;

            //declare variables
            int cartid;
            decimal quantity;
            decimal amount;

            //assign values
            cartid = cart.CartId;
            quantity = cart.IngredientQuantity;
            amount = cart.Amount;

            //define sql parameters
            SqlParameter objSP_cartid = new SqlParameter("@cartid", cartid);
            SqlParameter objSP_quantity = new SqlParameter("@quantity", quantity);
            SqlParameter objSP_amount = new SqlParameter("@amount", amount);

            //add parameters
            objCom.Parameters.Add(objSP_cartid);
            objCom.Parameters.Add(objSP_quantity);
            objCom.Parameters.Add(objSP_amount);

            //open connection
            objCon.Open();
            //executes the stored procedure
            int i = objCom.ExecuteNonQuery();
            //close connection
            objCon.Close();

            try
            {
                if (i > 0)
                {
                    cartUpdated = true;
                }
            }
            catch (Exception ex)
            {
                string
                errormessage = ex.Message;//take error message
                throw new RecipeIngredientSystemExceptions(errormessage);//custom exception
            }
            return cartUpdated;
        }
        //Delete cart
        public bool DeleteCartDAL(Cart cart)
        {
            bool cartDeleted = false;
            //Connection to database
            SqlConnection objCon = new SqlConnection(Database.ConnectionString);
            //get sql stored procedure to execute
            SqlCommand objCom = new SqlCommand(Database.DELETECART, objCon);

            //setting command type to stored procedure
            objCom.CommandType = CommandType.StoredProcedure;

            //declare variables
            int cartid;
            //assign values
            cartid = cart.CartId;

            //define sql parameters
            SqlParameter objSP_cartid = new SqlParameter("@cartid", cartid);
            //add parameters
            objCom.Parameters.Add(objSP_cartid);

            //open connection
            objCon.Open();
            int i = objCom.ExecuteNonQuery();
            //close connection
            objCon.Close();

            try
            {
                if (i > 0)
                {
                    cartDeleted = true;
                }
            }
            catch (Exception ex)
            {
                string
                errormessage = ex.Message; //take error message
                throw new RecipeIngredientSystemExceptions(errormessage);//custom exception
            }
            return cartDeleted;
        }
        //get total amount
        public List<Cart> TotalAmountDAL(string username)
        {
            //Connection to database
            SqlConnection objCon = new SqlConnection(Database.ConnectionString);
            //get sql stored procedure to execute
            SqlCommand objCom = new SqlCommand(Database.CUSTOMERCARTS, objCon);

            //setting command type to stored procedure
            objCom.CommandType = CommandType.StoredProcedure;

            //define sql parameters
            SqlParameter objSP_username = new SqlParameter("@username", username);
            //add parameters
            objCom.Parameters.Add(objSP_username);

            SqlDataAdapter da = new SqlDataAdapter(objCom);
            DataSet ds = new DataSet();
            //fill the dataset
            da.Fill(ds, "Cart");
            DataTable dtCart = ds.Tables["Cart"];

            List<Cart> CartList = new List<Cart>();

            //fetch data and create  a list
            for (int i = 0; i < dtCart.Rows.Count; i++)
            {
                Cart objCart = new Cart();
                objCart.CartId = Convert.ToInt32(dtCart.Rows[i]["CartId"]);
                objCart.IngredientQuantity = Convert.ToDecimal(dtCart.Rows[i]["IngredientQuantity"]);
                objCart.Amount = Convert.ToDecimal(dtCart.Rows[i]["Amount"]);
                CartList.Add(objCart);
            }
            return CartList;
        }
    }
}
