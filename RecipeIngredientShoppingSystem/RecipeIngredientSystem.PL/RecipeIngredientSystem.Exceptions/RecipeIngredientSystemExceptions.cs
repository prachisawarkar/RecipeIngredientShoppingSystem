using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeIngredientSystem.Exceptions
{
    public class RecipeIngredientSystemExceptions : ApplicationException
    {
        public RecipeIngredientSystemExceptions()
            : base()
        {

        }
        public RecipeIngredientSystemExceptions(string message)
            : base(message)
        {

        }
        public RecipeIngredientSystemExceptions(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
