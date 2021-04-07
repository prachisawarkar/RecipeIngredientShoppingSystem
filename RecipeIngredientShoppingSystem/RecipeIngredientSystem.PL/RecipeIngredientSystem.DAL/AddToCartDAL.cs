using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.Exceptions;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace RecipeIngredientSystem.DAL
{
    public class AddToCartDAL
    {
        //to add ingredients to the cart
        public bool AddIngToCartDAL(Cart cartadd, string username)
        {
            bool CartAdded = false;//declare bool variable
            try
            {
                //Connection to database
                SqlConnection objCon = new SqlConnection(Database.ConnectionString);
                //get sql stored procedure to execute
                SqlCommand objCom = new SqlCommand(Database.ADDTOCART, objCon);

                //setting command type to stored procedure
                objCom.CommandType = CommandType.StoredProcedure;

                //declare variables
                int ingredientid;
                decimal quantity;
                decimal amount;

                //take data into varibales
                ingredientid = Convert.ToInt32(cartadd.IngredientID);
                quantity = Convert.ToDecimal(cartadd.IngredientQuantity);
                amount = Convert.ToDecimal(cartadd.Amount);

                //defining parameters
                SqlParameter objSP_custid = new SqlParameter();//customerid
                SqlParameter objSP_username = new SqlParameter("@username", username);//username
                SqlParameter objSP_id = new SqlParameter("@IngredientID", ingredientid);//ingredientid
                SqlParameter objSP_quantity = new SqlParameter("@IngredientQuantity", quantity);//quantity
                SqlParameter objSP_amount = new SqlParameter("@amount", amount);//amount

                //customer id parameter details
                objSP_custid.ParameterName = "@CustomerID";
                objSP_custid.SqlDbType = System.Data.SqlDbType.Int;
                objSP_custid.Direction = System.Data.ParameterDirection.Output;

                //Adding the parameters
                objCom.Parameters.Add(objSP_username);
                objCom.Parameters.Add(objSP_custid);
                objCom.Parameters.Add(objSP_id);
                objCom.Parameters.Add(objSP_quantity);
                objCom.Parameters.Add(objSP_amount);

                /*SqlDataAdapter da = new SqlDataAdapter(objCom);
                DataTable dt = new DataTable();
                da.Fill(dt);*/

                //open connection
                objCon.Open();

                //executes the query
                int i = objCom.ExecuteNonQuery();

                //close connection
                objCon.Close();
            
                if (i > 0)
                {
                    CartAdded = true;
                }
            }
            catch (Exception ex)
            {
                string errormessage;
                errormessage = ex.Message;//take error message
                throw new RecipeIngredientSystemExceptions(errormessage);//custom exception
            }
            return CartAdded;
        }

        //to view the cart details
        public List<Ingredient> GetIngredientDAL(int id) //id = recipe id
        {
            //define the list
            List<Ingredient> IngredientList = new List<Ingredient>();
            try
            {
                //Connection to database
                SqlConnection objCon = new SqlConnection(Database.ConnectionString);
                //get sql stored procedure to execute
                SqlCommand objCom = new SqlCommand(Database.VIEWALLINGREDIENTS, objCon);

                //setting command type to stored procedure
                objCom.CommandType = CommandType.StoredProcedure;
                //Defining parameters for StoredProcedure
                SqlParameter objSP_id = new SqlParameter("@id", id);
                objCom.Parameters.Add(objSP_id);

                SqlDataAdapter da = new SqlDataAdapter(objCom);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                //fill the dataset
                da.Fill(ds, "Ingredient");
                dt = ds.Tables["Ingredient"];

                //fetch values and create a list
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Ingredient objIngredient = new Ingredient();
                    objIngredient.IngredientId = Convert.ToInt32(dt.Rows[i]["IngredientId"]);
                    objIngredient.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    objIngredient.RecipeId = Convert.ToInt32(dt.Rows[i]["RecipeId"]);
                    objIngredient.ManufacturerName = Convert.ToString(dt.Rows[i]["ManufacturerName"]);
                    objIngredient.ManufacturerDate = Convert.ToDateTime(dt.Rows[i]["ManufacturerDate"]);
                    objIngredient.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                    objIngredient.ExpiryDate = Convert.ToDateTime(dt.Rows[i]["ExpiryDate"]);
                    objIngredient.Description = Convert.ToString(dt.Rows[i]["Description"]);
                    IngredientList.Add(objIngredient);
                }
            }
            catch (Exception ex)
            {
                throw new RecipeIngredientSystemExceptions(ex.Message);
            }
            return IngredientList;
        }
    }
}