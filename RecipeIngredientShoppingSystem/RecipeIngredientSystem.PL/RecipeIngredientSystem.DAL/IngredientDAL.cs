using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.Exceptions;
using System.Configuration;
using System.Data.Common;
using System.Windows;

namespace RecipeIngredientSystem.DAL
{
    public class IngredientDAL
    {
        public bool InsertIngredients(Ingredient ingredient)
        {

            bool IngredientAdded = false;
            try
            {
                int recipeId;
               // int ingredientId;
                string name;
                string manufacturer;
                DateTime manufacturedate;
                DateTime expirydate;
                decimal price;
                string description;

                recipeId = Convert.ToInt32(ingredient.RecipeId);
                //ingredientId = Convert.ToInt32(ingredient.IngredientId);
                name = ingredient.Name;
                manufacturer = ingredient.ManufacturerName;
                manufacturedate = Convert.ToDateTime(ingredient.ManufacturerDate);
                expirydate = Convert.ToDateTime(ingredient.ExpiryDate);
                price = Convert.ToDecimal(ingredient.Price);
                description = ingredient.Description;

                SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Sprint1"].ConnectionString);
                SqlCommand objCom = new SqlCommand("AddIngredient", objCon);
                objCom.CommandType = CommandType.StoredProcedure;

                SqlParameter objSqlParam_RecipeId = new SqlParameter("@recipeid", recipeId);
                //SqlParameter objSqlParam_IngredientId = new SqlParameter("@ingredientid", ingredientId);
                SqlParameter objSqlParam_Name = new SqlParameter("@name", name);
                SqlParameter objSqlParam_ManufacturerName = new SqlParameter("@manufacturername", manufacturer);
                SqlParameter objSqlParam_ManufactureDate = new SqlParameter("@manufacturerdate", manufacturedate);
                SqlParameter objSqlParam_Price = new SqlParameter("@price", price);
                SqlParameter objSqlParam_ExpiryDate = new SqlParameter("@expirydate", expirydate);
                SqlParameter objSqlParam_Description = new SqlParameter("@description", description);

                objCom.Parameters.Add(objSqlParam_RecipeId);
                //objCom.Parameters.Add(objSqlParam_IngredientId);
                objCom.Parameters.Add(objSqlParam_Name);
                objCom.Parameters.Add(objSqlParam_ManufacturerName);
                objCom.Parameters.Add(objSqlParam_ManufactureDate);
                objCom.Parameters.Add(objSqlParam_Price);
                objCom.Parameters.Add(objSqlParam_ExpiryDate);
                objCom.Parameters.Add(objSqlParam_Description);

                objCon.Open();
                int noOfRowsAffected = objCom.ExecuteNonQuery();
                objCon.Close();
                if (noOfRowsAffected > 0)
                {
                    MessageBox.Show("Ingredient inserted successfully....");
                }
                IngredientAdded = true;
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
            return IngredientAdded;
        }
        public bool DeleteIngredient(int ingredientDelete)
        {
            bool IngredientDeleted = false;
            try
            {
                int ingredientId;
                ingredientId = ingredientDelete;
                SqlParameter objSqlParam_Id = new SqlParameter("@ingredientid", SqlDbType.Int);
                objSqlParam_Id.Direction = ParameterDirection.Input;

                objSqlParam_Id.Value = ingredientId;

                SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Sprint1"].ConnectionString); ;
                SqlCommand objCom = new SqlCommand("DeleteIngredient", objCon);
                objCom.CommandType = CommandType.StoredProcedure;
                objCom.Parameters.Add(objSqlParam_Id);

                objCon.Open();
                int noOfRowsAffected = objCom.ExecuteNonQuery();
                objCon.Close();
                if (noOfRowsAffected > 0)
                {
                    MessageBox.Show("Ingredient deleted successfully....");
                }
                IngredientDeleted = true;
            }
            catch (DbException ex)
            {
                throw new RecipeIngredientSystemExceptions(ex.Message);
            }
            return IngredientDeleted;
        }
        public Ingredient SearchIngredient(int searchIngredient)
        {
            Ingredient searchingredient = new Ingredient();
            try
            {
                int ingredientId;
                ingredientId = Convert.ToInt32(searchIngredient);

                SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Sprint1"].ConnectionString);
                SqlCommand objCom = new SqlCommand("SearchIngredient", objCon);
                objCom.CommandType = CommandType.StoredProcedure;

                SqlParameter objSqlParam_IngredientId = new SqlParameter("@ingredientid", SqlDbType.Int);

                objSqlParam_IngredientId.Direction = ParameterDirection.Input;

                objSqlParam_IngredientId.Value = ingredientId;
                //
                objCom.Parameters.Add(objSqlParam_IngredientId);

                objCon.Open();
                SqlDataReader sqlDataReader = objCom.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    searchingredient.IngredientId = sqlDataReader.GetInt32(0);
                    searchingredient.Name = sqlDataReader.GetString(1);
                    searchingredient.RecipeId = sqlDataReader.GetInt32(2);
                    searchingredient.ManufacturerName = sqlDataReader.GetString(3);
                    searchingredient.ManufacturerDate = sqlDataReader.GetDateTime(4);
                    searchingredient.Price = sqlDataReader.GetDecimal(5);
                    searchingredient.ExpiryDate = sqlDataReader.GetDateTime(6);
                    searchingredient.Description = sqlDataReader.GetString(7);
                }
                objCon.Close();
            }
            catch (Exception ex)
            {
                throw new RecipeIngredientSystemExceptions(ex.Message);
            }
            return searchingredient;
        }
        public bool ModifyIngredient(Ingredient ingredient)
        {
            bool IndredientUpdated = false;
            try
            {
                int recipeId;
                int ingredientId;
                string name;
                string manufacturer;
                DateTime manufacturedate;
                DateTime expirydate;
                decimal price;
                string description;

                SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Sprint1"].ConnectionString); ;
                SqlCommand objCom = new SqlCommand("UpdateIngredient", objCon);
                objCom.CommandType = CommandType.StoredProcedure;

                ingredientId = Convert.ToInt32(ingredient.IngredientId);
                recipeId = Convert.ToInt32(ingredient.RecipeId);
                name = ingredient.Name;
                manufacturer = ingredient.ManufacturerName;
                manufacturedate = Convert.ToDateTime(ingredient.ManufacturerDate);
                expirydate = Convert.ToDateTime(ingredient.ExpiryDate);
                price = Convert.ToDecimal(ingredient.Price);
                description = ingredient.Description;

                SqlParameter[] objSqlParams = new SqlParameter[8];
                objSqlParams[0] = new SqlParameter("@recipeid", recipeId);
                objSqlParams[1] = new SqlParameter("@name", name);
                objSqlParams[2] = new SqlParameter("@manufacturername", manufacturer);
                objSqlParams[3] = new SqlParameter("@manufacturerdate", manufacturedate);
                objSqlParams[4] = new SqlParameter("@price", price);
                objSqlParams[5] = new SqlParameter("@expirydate", expirydate);
                objSqlParams[6] = new SqlParameter("@description", description);
                objSqlParams[7] = new SqlParameter("@ingredientid", ingredientId);
                objCom.Parameters.AddRange(objSqlParams);
                objCon.Open();
                int noOfRowsAffected = objCom.ExecuteNonQuery();
                objCon.Close();
                if (noOfRowsAffected > 0)
                {
                    MessageBox.Show("Ingredient updated successfully....");
                }
                IndredientUpdated = true;
            }
            catch (DbException ex)
            {
                throw new RecipeIngredientSystemExceptions(ex.Message);
            }
            return IndredientUpdated;
        }
        public List<Ingredient> GetIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Sprint1"].ConnectionString); ;
            SqlCommand objCom = new SqlCommand("GetIngredient", objCon);
            objCom.CommandType = CommandType.StoredProcedure;
            objCon.Open();
            SqlDataReader objDR = objCom.ExecuteReader();

            while (objDR.Read())
            {
                Ingredient getlist = new Ingredient();
                getlist.IngredientId = objDR.GetInt32(0);
                getlist.Name = objDR.GetString(1);
                getlist.RecipeId = objDR.GetInt32(2);
                getlist.ManufacturerName = objDR.GetString(3);
                getlist.ManufacturerDate = objDR.GetDateTime(4);
                getlist.Price = objDR.GetDecimal(5);
                getlist.ExpiryDate = objDR.GetDateTime(6);
                getlist.Description = objDR.GetString(7);
                ingredients.Add(getlist);
            }
            DataTable objDT = new DataTable();
            objDT.Load(objDR);
            objCon.Close();
            return ingredients;
        }
    }
}
