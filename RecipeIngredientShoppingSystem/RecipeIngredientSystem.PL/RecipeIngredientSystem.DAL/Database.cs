using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace RecipeIngredientSystem.DAL
{
    public class Database
    {
        static string connectionString;
        public const string ADDCUSTOMER = "AddCustomer";/// YOU HAVE TO CHANGE PROCEDURE NAME 
        public const string CUSTOMERLOGIN = "LoginCustomer";/// YOU HAVE TO CHANGE PROCEDURE NAME 
        public const string CUSTOMERCHANGEPASS = "ChangePasswordCustomer";/// YOU HAVE TO CHANGE PROCEDURE NAME 
        public const string CUSTOMERFORGET = "ForgotPasswordCustomer";/// YOU HAVE TO CHANGE PROCEDURE NAME 

        //public const string LOGINCUSTOMER = "LoginCustomer";
        public const string GETALLRECIPES = "GetAllRecipes";
        public const string VIEWALLRECIPES = "ViewAllRecipes";
        public const string VIEWALLINGREDIENTS = "ViewAllIngredients";
        public const string ADDTOCART = "AddToCart";
        public const string VIEWMYCARTS = "ViewMyCarts";
        public const string CUSTOMERCARTS = "CustomerCarts1";
        public const string UPDATECART = "UpdateCart";
        public const string DELETECART = "DeleteCart";
        public const string PLACEORDER = "PlaceOrder";
        public const string VIEWSHIPPINGDETAILS = "ViewShippingDetails";

        //Admin
        public const string UPADTEADMINSHIP = "AdminShippingDetailsUpdate";     // CHANGE THE SP
        public const string GETSHIP = "AdminViewShippingDetails";                // CHANGE The SP

        public const string ADMINORDERMANAGER = "AdminOrderManager";

        public const string ADDADMIN = "AddAdmin";
        public const string ADMINLOGIN = "LoginAdmin";
        public const string ADMINCHANGEPASS = "ChangePasswordAdminusing";
        public const string ADMINFORGET = "ForgotPasswordAdmin";
        
        public const string ADDRECIPE = "AddRecipe";
        public const string UPDATERECIPE = "UpdateRecipe";
        public const string DELETERECIPE = "DeleteRecipe";
        public const string SEARCHRECIPE = "SearchRecipe";
        public const string GETRECIPE = "GetRecipe";
        static Database()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Sprint1"].ConnectionString;
        }
        public static string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }
    }
}
