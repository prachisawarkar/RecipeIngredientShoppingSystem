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
    public class CustomerDAL
    {
       /* public bool LoginCustomerDAL(Customer customer)
        {
            bool LoginCustomer = false;
            //Connection to database
            SqlConnection objCon = new SqlConnection(Database.ConnectionString);
            SqlCommand objCom = new SqlCommand(Database.CUSTOMERLOGIN, objCon);
            
            //setting command type to stored procedure
            objCom.CommandType = CommandType.StoredProcedure;
            
            //Defining parameters for StoredProcedure
            objCom.Parameters.AddWithValue("@username", customer.UserName); //Adding Username Parameter
            objCom.Parameters.AddWithValue("@password", customer.Password); //Adding Password Parameter
            
            SqlDataAdapter da = new SqlDataAdapter(objCom);
            DataSet ds = new DataSet();
            da.Fill(ds, "Customer");
            DataTable dt = ds.Tables["Customer"];

            //Open Connection
            objCon.Open();
            int CustomerCount = objCom.ExecuteNonQuery();
            //Close Connection
            objCon.Close();

            try
            {
                if (dt.Rows.Count > 0)
                {
                    LoginCustomer = true;
                }
            }
            catch(Exception ex)
            {
                string 
                errormessage = ex.Message;
                throw new RecipeIngredientSystemExceptions(errormessage);
            }
            return LoginCustomer;
        }*/

        public bool RegistrationCustomerDAL(Customer Add)
        {
            bool CustomerAdded = false;

            try{
                string name;
                string email;
                string username;
                string password;
                string address;
                string mobilenumber;

                username = Add.UserName;
                password = Add.Password;
                address = Add.Address;
                mobilenumber = Add.MobileNumber;
                name = Add.Name;
                email = Add.Email;

                //SqlCommand objCom = new SqlCommand(query, con);
                SqlConnection objCon = new SqlConnection(Database.ConnectionString);
                SqlCommand objCom = new SqlCommand(Database.ADDCUSTOMER, objCon);
                objCom.CommandType = CommandType.StoredProcedure;

                SqlParameter objSP_username = new SqlParameter("@username", username);
                SqlParameter objSP_password = new SqlParameter("@password", password);
                SqlParameter objSP_name = new SqlParameter("@name", name);
                SqlParameter objSP_email = new SqlParameter("@email", email);
                SqlParameter objSP_address = new SqlParameter("@address", address);
                SqlParameter objSP_mobilenumber = new SqlParameter("@mobilenumber", mobilenumber);

                objCom.Parameters.Add(objSP_username);
                objCom.Parameters.Add(objSP_password);
                objCom.Parameters.Add(objSP_name);
                objCom.Parameters.Add(objSP_email);
                objCom.Parameters.Add(objSP_address);
                objCom.Parameters.Add(objSP_mobilenumber);
                //
                objCon.Open();

                int noOfRowsAffected = objCom.ExecuteNonQuery();
                objCon.Close();
                if (noOfRowsAffected > 0)
                {
                    MessageBox.Show("Customer Added successfully.");
                }
                CustomerAdded = true;
            }
            catch (DbException ex)
            {
                string errormessage;

                switch (ex.ErrorCode)
                {
                    case -2146232060:
                        errormessage = "Username or Moblie number is already taken !";
                        break;
                    default:
                        errormessage = ex.Message;
                        break;
                }
                throw new RecipeIngredientSystemExceptions(errormessage);
            }
            return CustomerAdded;
        }
        public bool CustomerLoginDAL(Customer customer)
        {
            bool CustomerLogin = false;
           try {
                SqlConnection objCon = new SqlConnection(Database.ConnectionString);
                SqlCommand objCom = new SqlCommand(Database.CUSTOMERLOGIN, objCon);
                objCom.CommandType = CommandType.StoredProcedure;
                objCom.Parameters.AddWithValue("@username", customer.UserName); //Adding Username Parameter
                objCom.Parameters.AddWithValue("@password", customer.Password); //Adding Password Parameter

                SqlDataAdapter da = new SqlDataAdapter(objCom);
                DataSet ds = new DataSet();
                da.Fill(ds, "Customer");
                DataTable dt = ds.Tables["Customer"];
                objCon.Open();
                int CustomerCount = objCom.ExecuteNonQuery();
                objCon.Close();
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login Successful!");
                    CustomerLogin = true;
                }
                else
                {
                    MessageBox.Show("Login Unsuccessful!");
                    CustomerLogin = false;
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
            return CustomerLogin;
        }
        public bool CustomerChangPassDAL(Customer customer)
        {

            bool CustomerChangePass = false;
            try
            {
                SqlConnection objCon = new SqlConnection(Database.ConnectionString);
                SqlCommand objCom = new SqlCommand(Database.CUSTOMERCHANGEPASS, objCon);
                objCom.CommandType = CommandType.StoredProcedure;
                objCom.Parameters.AddWithValue("@username", customer.UserName); //Adding Username Parameter
                objCom.Parameters.AddWithValue("@password", customer.Password); //Adding Password Parameter
                objCom.Parameters.AddWithValue("@mobilenumber", customer.MobileNumber);
                objCon.Open();

                int CustomerCount = (Int32)objCom.ExecuteNonQuery();
                objCon.Close();
                if (CustomerCount > 0)
                {
                    MessageBox.Show("Password Changed Successfully!");
                    CustomerChangePass = true;
                }
                else
                {
                    MessageBox.Show("Password Does not Changed!");
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
            return CustomerChangePass;
        }
        public bool CustomerForgetDAL(string searchcustomer) // void Or the of entity class 
        {
            bool searchCustomer = false;
            try
            {
                Customer ad = new Customer();

                string customerUsername;
                customerUsername = Convert.ToString(searchcustomer);

                SqlConnection objCon = new SqlConnection(Database.ConnectionString);
                SqlCommand objCom = new SqlCommand(Database.CUSTOMERFORGET, objCon);
                objCom.CommandType = CommandType.StoredProcedure;

                SqlParameter objSqlParam_UserName = new SqlParameter("@username", SqlDbType.VarChar);

                //objCom.Parameters.AddWithValue("@username", SqlDbType.VarChar); //Adding Username Parameter
                objSqlParam_UserName.Direction = ParameterDirection.Input;

                objSqlParam_UserName.Value = customerUsername;

                objCom.Parameters.Add(objSqlParam_UserName);

                SqlDataAdapter sda = new SqlDataAdapter(objCom);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //
                /*objCon.Open();
                SqlDataReader sqlDataReader = objCom.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    ad.UserName = sqlDataReader.GetString(0);
                }
                objCon.Close();*/
                if (dt.Rows.Count > 0)
                {
                    searchCustomer = true;
                }
            }
            catch (Exception ex)
            {
                string
                errormessage = ex.Message;
                throw new RecipeIngredientSystemExceptions(errormessage);
            }
            return searchCustomer;
        }
    }
}
