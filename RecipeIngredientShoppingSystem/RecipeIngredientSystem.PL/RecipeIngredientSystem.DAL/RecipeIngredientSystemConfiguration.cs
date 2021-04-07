using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace RecipeIngredientSystem.DAL
{
    public class RecipeIngredientSystemConfiguration
    {
        private static string providerName;
        public static string ProviderName
        {
            get { return RecipeIngredientSystemConfiguration.providerName; }
            set { RecipeIngredientSystemConfiguration.providerName = value; }
        }
        private static string connectionString;

        public static string ConnectionString
        {
            get { return RecipeIngredientSystemConfiguration.connectionString; }
            set { RecipeIngredientSystemConfiguration.connectionString = value; }
        }
        static RecipeIngredientSystemConfiguration()
        {
            providerName = ConfigurationManager.ConnectionStrings["Sprint1"].ProviderName;
            connectionString = ConfigurationManager.ConnectionStrings["Sprint1"].ConnectionString;
        }
    }
}
