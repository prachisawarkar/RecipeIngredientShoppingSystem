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
    public class AdminDAL
    {
        public bool RegistrationAdminDAL(Admin Add)   // Function for Admin Registration
        {
            bool AdminAdded = false;
           try {
                string username;
                string password;
                string securityquestion;
                string securityanswer;

                username = Add.UserName;
                password = Add.Password;
                securityquestion = Add.SecurityQuestion;
                securityanswer = Add.SecurityAnswer;

                SqlConnection objCon = new SqlConnection(Database.ConnectionString);
                SqlCommand objCom = new SqlCommand(Database.ADDADMIN, objCon);
                objCom.CommandType = CommandType.StoredProcedure;

                SqlParameter objSP_username = new SqlParameter("@username", username);
                SqlParameter objSP_password = new SqlParameter("@password", password);
                SqlParameter objSP_securityquestion = new SqlParameter("@securityquestion", securityquestion);
                SqlParameter objSP_securityanswer = new SqlParameter("@securityanswer", securityanswer);

                objCom.Parameters.Add(objSP_username);
                objCom.Parameters.Add(objSP_password);
                objCom.Parameters.Add(objSP_securityquestion);
                objCom.Parameters.Add(objSP_securityanswer);
                //
                objCon.Open();

                int noOfRowsAffected = objCom.ExecuteNonQuery();
                objCon.Close();
                if (noOfRowsAffected > 0)
                {
                    MessageBox.Show("Admin Added successfully.");
                }
                AdminAdded = true;
            }
            catch (DbException ex)
            {
                string errormessage;

                switch (ex.ErrorCode)
                {
                    case -2146232060:
                        errormessage = "Username is already taken please try another !";
                        break;
                    default:
                        errormessage = ex.Message;
                        break;
                }
                throw new RecipeIngredientSystemExceptions(errormessage);
            }
            return AdminAdded;
        }
        public bool AdminLoginDAL(Admin admin)   // Function for Admin Login
        {
            bool AdminLogin = false;
            try
            {
                SqlConnection objCon = new SqlConnection(Database.ConnectionString);
                SqlCommand objCom = new SqlCommand(Database.ADMINLOGIN, objCon);
                objCom.CommandType = CommandType.StoredProcedure;
                objCom.Parameters.AddWithValue("@username", admin.UserName); //Adding Username Parameter
                objCom.Parameters.AddWithValue("@password", admin.Password); //Adding Password Parameter
                SqlDataAdapter da = new SqlDataAdapter(objCom);
                DataSet ds = new DataSet();
                da.Fill(ds, "Admin");
                DataTable dt = ds.Tables["Admin"];
                objCon.Open();
                int CustomerCount = objCom.ExecuteNonQuery();
                objCon.Close();
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login Successful!");
                    AdminLogin = true;
                }
                else
                {
                    MessageBox.Show("Login Unsuccessful!");
                    AdminLogin = false;
                }
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

            return AdminLogin;
        }
        public bool AdminChangPassDAL(Admin admin)   // Function for Changepassword of Admin
        {
            bool AdminChangePass = false;
            try
            {
                SqlConnection objCon = new SqlConnection(Database.ConnectionString);
                SqlCommand objCom = new SqlCommand(Database.ADMINCHANGEPASS, objCon);
                objCom.CommandType = CommandType.StoredProcedure;
                objCom.Parameters.AddWithValue("@username", admin.UserName); //Adding Username Parameter
                objCom.Parameters.AddWithValue("@password", admin.Password); //Adding Password Parameter
                objCom.Parameters.AddWithValue("@securityanswer", admin.SecurityAnswer);
                objCom.Parameters.AddWithValue("@securityquestion", admin.SecurityQuestion);

                objCon.Open();
               
                int AdminCount = (Int32)objCom.ExecuteNonQuery();
                objCon.Close();
                if (AdminCount == 1)
                {
                    MessageBox.Show("Password Changed Successful!");
                    AdminChangePass = true;
                }
                else
                {
                    MessageBox.Show("Password Changed Unsuccessful!");
                }
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
            return AdminChangePass;
        }
        public bool AdminForgetDAL(string searchadmin)    // Function for Forget of Admin
        {
            bool searchAdmin = false;
            try
            {
                Admin ad = new Admin();

                string adminUsername;
                adminUsername = Convert.ToString(searchadmin);

                SqlConnection objCon = new SqlConnection(Database.ConnectionString);
                SqlCommand objCom = new SqlCommand(Database.ADMINFORGET, objCon);
                objCom.CommandType = CommandType.StoredProcedure;

                SqlParameter objSqlParam_UserName = new SqlParameter("@username", SqlDbType.VarChar);

                objSqlParam_UserName.Direction = ParameterDirection.Input;

                objSqlParam_UserName.Value = adminUsername;

                objCom.Parameters.Add(objSqlParam_UserName);

                SqlDataAdapter sda = new SqlDataAdapter(objCom);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                
                if (dt.Rows.Count > 0)
                {
                    searchAdmin = true;
                }
            }
            catch (Exception ex)
            {
                string
                errormessage = ex.Message;
                throw new RecipeIngredientSystemExceptions(errormessage);
            }
            return searchAdmin;
        }
    }
}
