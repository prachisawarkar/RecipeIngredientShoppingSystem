using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.Exceptions;
using RecipeIngredientSystem.DAL;

namespace RecipeIngredientSystem.BL
{
    public class AdminBL
    {
        public static bool ValidateAdmin(Admin objadmin) // Validation of Admin front 
        {
            bool validadmin = true;
            if (objadmin.UserName == string.Empty)
            {
                validadmin = false;
            }
            if (objadmin.Password == string.Empty)
            {
                validadmin = false;
            }
            if (objadmin.SecurityQuestion == string.Empty)
            {
                validadmin = false;
            }
            if (objadmin.SecurityAnswer == string.Empty)
            {
                validadmin = false;
            }
            return validadmin;
        }
        public bool AddAdminBL(Admin objAddAdmin)  // Validation of Registration of Admin
        {
            bool AdminAdded = false;
            try
            {
                if (ValidateAdmin(objAddAdmin))
                {
                    AdminDAL adminDAL = new AdminDAL();
                    AdminAdded = adminDAL.RegistrationAdminDAL(objAddAdmin);
                }
                else
                {
                    throw new RecipeIngredientSystemExceptions(" * FILL ALL THE DEATILS * ");
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
            return AdminAdded;
        }
        public bool AdminLoginBL(Admin objLoginAdmin)   // Validation of Login of Admin
        {
            bool Login = false;
            try
            {
                if (ValidateAdmin(objLoginAdmin))
                {
                    AdminDAL adminDAL = new AdminDAL();
                    Login = adminDAL.AdminLoginDAL(objLoginAdmin);
                }
                else
                {
                    throw new RecipeIngredientSystemExceptions("Invalid Username or Password");
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
        public bool AdminChangePaasBL(Admin objchangepassAdmin) // Validation of Registration of Admin
        {
            bool pass = false;
            try
            {
                if (ValidateAdmin(objchangepassAdmin))
                {
                    AdminDAL adminDAL = new AdminDAL();
                    pass = adminDAL.AdminChangPassDAL(objchangepassAdmin);
                }
                else
                {
                    throw new RecipeIngredientSystemExceptions("Please check details once again");
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
        public  bool AdminForget(string objForgetAdmin) // Validation of Forgot Login   Admin
        {
            bool searchadmin = false;
            try
            {
                Admin adminsearch = new Admin();
                AdminDAL adminDAL = new AdminDAL();
                searchadmin = adminDAL.AdminForgetDAL(objForgetAdmin);

                //catch (IngredientsRecipeShoppingExceptions)
                //{
                //    throw;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchadmin;
        }
    }
}
