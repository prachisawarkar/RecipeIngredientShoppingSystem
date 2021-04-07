using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RecipeIngredientSystem.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public int CustomerID { get; set; }
        public int IngredientID { get; set; }
        public decimal IngredientQuantity { get; set; }
        public decimal Amount { get; set; }
        public Cart()
        {
            CartId = 0;
            CustomerID = 0;
            IngredientID = 0;
            IngredientQuantity = 0;
            Amount = 0;
        }
        public Cart(int cartid, int custid, int ingid, decimal quantity, decimal amount)
        {
            CartId = cartid;
            CustomerID = custid;
            IngredientID = ingid;
            IngredientQuantity = quantity;
            Amount = amount;
        }

    }
}
