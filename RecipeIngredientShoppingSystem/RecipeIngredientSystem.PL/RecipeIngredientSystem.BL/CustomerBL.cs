using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.Exceptions;
using RecipeIngredientSystem.DAL;
using System.Data;
using System.Text.RegularExpressions;

namespace RecipeIngredientSystem.BL
{
    public class CustomerBL
    {
        /*public static bool ValidateCustomerLogin(Customer customer)
        {
            StringBuilder sb = new StringBuilder();
            bool validLogin = true;
            if(customer.UserName == string.Empty)
            {
                validLogin = false;
            }
            if(customer.Password == string.Empty)
            {
                validLogin = false;
            }
            if(validLogin == false)
            {
                throw new RecipeIngredientSystemExceptions(sb.ToString());
            }
            return validLogin;
        }

        public bool LoginCustomerBL(Customer customer)
        {
            bool customerLogin = false;
            try
            {
                if(ValidateCustomerLogin(customer))
                {
                    CustomerDAL customerDAL = new CustomerDAL();
                    customerLogin = customerDAL.LoginCustomerDAL(customer);
                }
            }
            catch(RecipeIngredientSystemExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customerLogin;
        }*/
        public static bool ValidateAddCustomer(Customer objcustomer)
        {
            StringBuilder sb = new StringBuilder();
            bool validcustomer = true;
            if (objcustomer.UserName == string.Empty)
            {
                validcustomer = false;
                sb.Append(Environment.NewLine + "Username Required");
            }
            if(!Regex.IsMatch(objcustomer.Email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                validcustomer = false;
                sb.Append(Environment.NewLine + "Enter Email Id in proper format!");
            }
            if (String.IsNullOrEmpty(objcustomer.MobileNumber) || objcustomer.MobileNumber.Length != 10)
            {
                validcustomer = false;
                sb.Append(Environment.NewLine + "Enter 10 digit mobile number!");
                //return false;
            }
            if (objcustomer.Password == string.Empty)
            {
                validcustomer = false;
                sb.Append(Environment.NewLine + "Password Required");
            }
            if (validcustomer == false)
                throw new RecipeIngredientSystemExceptions(sb.ToString());
            return validcustomer;
        }
        public static bool ValidateChangePassCustomer(Customer objcustomer)
        {
            StringBuilder sb = new StringBuilder();
            bool validcustomer = true;
            if (objcustomer.UserName == string.Empty)
            {
                validcustomer = false;
                sb.Append(Environment.NewLine + "Username Required");
            }
            if (String.IsNullOrEmpty(objcustomer.MobileNumber) || objcustomer.MobileNumber.Length != 10)
            {
                validcustomer = false;
                sb.Append(Environment.NewLine + "Enter 10 digit mobile number!");
                //return false;
            }
            if (objcustomer.Password == string.Empty)
            {
                validcustomer = false;
                sb.Append(Environment.NewLine + "Password Required");
            }
            if (String.IsNullOrEmpty(objcustomer.NewPassword))
            {
                validcustomer = false;
                sb.Append(Environment.NewLine + "New Password Required");
                //return false;
            }
            if (validcustomer == false)
                throw new RecipeIngredientSystemExceptions(sb.ToString());
            return validcustomer;
        }
        public static bool ValidateCustomer(Customer objcustomer)
        {
            StringBuilder sb = new StringBuilder();
            bool validcustomer = true;
            if (objcustomer.UserName == string.Empty)
            {
                validcustomer = false;
                sb.Append(Environment.NewLine + "Username Required");
            }
            if (objcustomer.Password == string.Empty)
            {
                validcustomer = false;
                sb.Append(Environment.NewLine + "Password Required");
            }
            if (validcustomer == false)
                throw new RecipeIngredientSystemExceptions(sb.ToString());
            return validcustomer;
        }
        public bool AddCustomerBL(Customer objAddCustomer)
        {
            bool CustomerAdded = false;
            try
            {
                if (ValidateAddCustomer(objAddCustomer))
                {
                    CustomerDAL customerDAL = new CustomerDAL();
                    CustomerAdded = customerDAL.RegistrationCustomerDAL(objAddCustomer);
                }
                else
                {
                    throw new RecipeIngredientSystemExceptions("All fields mandatory!");
                }
            }
            //catch (IngredientsRecipeShoppingExceptions)
            //{
            //    throw;
            //}
            catch (RecipeIngredientSystemExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CustomerAdded;
        }
        public bool CustomerLoginBL(Customer objLoginCustomer)
        {
            bool Login = false;
            try
            {
                if (ValidateCustomer(objLoginCustomer))
                {
                    CustomerDAL customerDAL = new CustomerDAL();
                    Login = customerDAL.CustomerLoginDAL(objLoginCustomer);
                }
                else
                {
                    throw new RecipeIngredientSystemExceptions("Incorrect Username or Password");
                }
            }
            catch (RecipeIngredientSystemExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Login;
        }
        public bool CustomerChangePaasBL(Customer objchangepassCustomer)
        {
            bool pass = false;
            try
            {
                if (ValidateChangePassCustomer(objchangepassCustomer))
                {
                    CustomerDAL adminDAL = new CustomerDAL();
                    pass = adminDAL.CustomerChangPassDAL(objchangepassCustomer);
                }
                else
                {
                    throw new RecipeIngredientSystemExceptions("Please fill all details Correctly");
                }
            }
            catch (RecipeIngredientSystemExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pass;
        }

        public bool CustomerForget(string objForgetCustomer)
        {
            bool searchcustomer = false;
            try
            {
                Customer customersearch = new Customer();
                CustomerDAL customerDAL = new CustomerDAL();
                searchcustomer = customerDAL.CustomerForgetDAL(objForgetCustomer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchcustomer;
        }
    }
}
