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
    public class RecipeDAL
    {
        //to get list of recipes
        public DataTable GetRecipeListDAL()
        {
            //List<Recipe> RecipeList = new List<Recipe>();
            try
            {
                //Connection to database
                SqlConnection objCon = new SqlConnection(Database.ConnectionString);
                //get sql stored procedure to execute
                SqlCommand objCom = new SqlCommand(Database.GETALLRECIPES, objCon);

                //setting command type to stored procedure
                objCom.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(objCom);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                //fill the dataset
                da.Fill(ds, "Recipe");
                dt = ds.Tables["Recipe"];

                /*for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Recipe objRecipe = new Recipe();
                    objRecipe.RecipeId = Convert.ToInt32(dt.Rows[i]["RecipeId"]);
                    objRecipe.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    objRecipe.Description = Convert.ToString(dt.Rows[i]["Description"]);
                    RecipeList.Add(objRecipe);
                }*/
                return dt;
            }
            catch (Exception ex)
            {
                string
                errormessage = ex.Message;//take error message
                throw new RecipeIngredientSystemExceptions(errormessage);//custom exception
            }
        }
        //to show details of selected recipe
        public DataTable ViewRecipeDAL(int recipeid)
        {
            try
            {
                //Connection to database
                SqlConnection objCon = new SqlConnection(Database.ConnectionString);
                //get sql stored procedure to execute
                SqlCommand objCom = new SqlCommand(Database.VIEWALLRECIPES, objCon);

                //setting command type to stored procedure
                objCom.CommandType = CommandType.StoredProcedure;

                //defining parameters
                int recipeId = Convert.ToInt32(recipeid);
                objCom.Parameters.AddWithValue("@recipeid", recipeId);

                SqlDataAdapter da = new SqlDataAdapter(objCom);
                DataTable dt = new DataTable();
                //fill the table
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                string
                errormessage = ex.Message;//take error message
                throw new RecipeIngredientSystemExceptions(errormessage);//custom exception
            }
        }
    }
}
