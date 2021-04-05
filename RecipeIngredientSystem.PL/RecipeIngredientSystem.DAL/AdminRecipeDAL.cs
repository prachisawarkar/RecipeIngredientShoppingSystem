using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.Exceptions;
using System.Windows;
using System.Data.Common;

namespace RecipeIngredientSystem.DAL
{
    public class AdminRecipeDAL
    {
        public bool AddRecipeDAL(Recipe recipeadd)
        {
            bool RecipeAdded = false;
            try
            {
                string name;
                string description;
                //
                name = recipeadd.Name;
                description = recipeadd.Description;
                //
                SqlConnection objCon = new SqlConnection(Database.ConnectionString);
                SqlCommand objCom = new SqlCommand(Database.ADDRECIPE, objCon);
                objCom.CommandType = CommandType.StoredProcedure;
                //
                SqlParameter objSqlParam_Name = new SqlParameter("@Name", name);
                SqlParameter objSqlParam_Description = new SqlParameter("@Description", description);
                //
                objCom.Parameters.Add(objSqlParam_Name);
                objCom.Parameters.Add(objSqlParam_Description);
                //
                objCon.Open();

                int noOfRowsAffected = objCom.ExecuteNonQuery();
                objCon.Close();
                if (noOfRowsAffected > 0)
                {
                    MessageBox.Show("Recipe Added successfully.");
                }

                RecipeAdded = true;
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
            return RecipeAdded;

        }


        public bool UpdateRecipeDAL(Recipe recipeupdate)
        {
            bool RecipeUpdated = false;
            try
            {
                int recipeid;
                string name;
                string description;
                //
                recipeid = Convert.ToInt32(recipeupdate.RecipeId);
                name = recipeupdate.Name;
                description = recipeupdate.Description;
                //
                SqlConnection objCon = new SqlConnection(Database.ConnectionString);
                SqlCommand objCom = new SqlCommand(Database.UPDATERECIPE, objCon);
                objCom.CommandType = CommandType.StoredProcedure;
                //
                SqlParameter objSqlParam_RecipeId = new SqlParameter("@RecipeId", SqlDbType.Int);
                SqlParameter objSqlParam_Name = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                SqlParameter objSqlParam_Description = new SqlParameter("@Description", SqlDbType.VarChar, 300);
                //
                objSqlParam_RecipeId.Direction = ParameterDirection.Input;
                objSqlParam_Name.Direction = ParameterDirection.Input;
                objSqlParam_Description.Direction = ParameterDirection.Input;
                //
                objSqlParam_RecipeId.Value = recipeid;
                objSqlParam_Name.Value = name;
                objSqlParam_Description.Value = description;
                //
                objCom.Parameters.Add(objSqlParam_RecipeId);
                objCom.Parameters.Add(objSqlParam_Name);
                objCom.Parameters.Add(objSqlParam_Description);
                //
                objCon.Open();

                int noOfRowsAffected = objCom.ExecuteNonQuery();
                objCon.Close();
                if (noOfRowsAffected > 0)
                {
                    MessageBox.Show("Recipe Updated Successfully.");
                }
                RecipeUpdated = true;
            }
            catch (DbException ex)
            {
                throw new RecipeIngredientSystemExceptions(ex.Message);
            }
            return RecipeUpdated;
        }
        public bool DeleteRecipeDAL(int recipedelete)
        {
            bool RecipeDeleted = false;
            try
            {
                int recipeid;
                //
                recipeid = recipedelete;
                //
                SqlConnection objCon = new SqlConnection(Database.ConnectionString);
                SqlCommand objCom = new SqlCommand(Database.DELETERECIPE, objCon);
                objCom.CommandType = CommandType.StoredProcedure;
                //
                SqlParameter objSqlParam_RecipeId = new SqlParameter("@RecipeId", SqlDbType.Int);
                //
                objSqlParam_RecipeId.Direction = ParameterDirection.Input;
                //
                objSqlParam_RecipeId.Value = recipeid;
                //
                objCom.Parameters.Add(objSqlParam_RecipeId);
                //
                objCon.Open();


                int noOfRowsAffected = objCom.ExecuteNonQuery();
                objCon.Close();
                if (noOfRowsAffected > 0)
                {
                    MessageBox.Show("Recipe deleted Successfully.");
                }
                RecipeDeleted = true;
            }
            catch (DbException ex)
            {
                throw new RecipeIngredientSystemExceptions(ex.Message);
            }
            return RecipeDeleted;
        }
        public Recipe SearchRecipeDAL(int searchRecipe)
        {
            Recipe searchrecipe = new Recipe();
            try
            {
                int recipeid;
                //
                recipeid = Convert.ToInt32(searchRecipe);
                //
                SqlConnection objCon = new SqlConnection(Database.ConnectionString);
                SqlCommand objCom = new SqlCommand(Database.SEARCHRECIPE, objCon);
                objCom.CommandType = CommandType.StoredProcedure;
                //
                SqlParameter objSqlParam_RecipeId = new SqlParameter("@RecipeId", SqlDbType.Int);
                //
                objSqlParam_RecipeId.Direction = ParameterDirection.Input;
                //
                objSqlParam_RecipeId.Value = recipeid;
                //
                objCom.Parameters.Add(objSqlParam_RecipeId);
                //
                objCon.Open();
                SqlDataReader sqlDataReader = objCom.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    searchrecipe.RecipeId = sqlDataReader.GetInt32(0);
                    searchrecipe.Name = sqlDataReader.GetString(1);
                    searchrecipe.Description = sqlDataReader.GetString(2);
                }
                objCon.Close();
                return searchrecipe;
            }
            catch (Exception ex)
            {
                throw new RecipeIngredientSystemExceptions(ex.Message);
            }
            return searchrecipe;
        }

        public List<Recipe> GetRecipe()
        {
            List<Recipe> recipeItems = new List<Recipe>();

            SqlConnection objCon = new SqlConnection(Database.ConnectionString);
            SqlCommand objCom = new SqlCommand(Database.GETRECIPE, objCon);
            objCom.CommandType = CommandType.StoredProcedure;
            objCon.Open();
            SqlDataReader objDR = objCom.ExecuteReader();

            while (objDR.Read())
            {
                Recipe getlist = new Recipe();
                getlist.RecipeId = objDR.GetInt32(0);
                getlist.Name = objDR.GetString(1);
                getlist.Description = objDR.GetString(2);
                recipeItems.Add(getlist);
            }
            DataTable objDT = new DataTable();
            objDT.Load(objDR);

            objCon.Close();
            return recipeItems;
        }
    }
}
