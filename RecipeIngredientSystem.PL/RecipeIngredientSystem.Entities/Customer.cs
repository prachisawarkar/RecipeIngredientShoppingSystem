using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeIngredientSystem.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string Address { get; set; }
    }
}
