using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeIngredientSystem.Entities
{
    class CartRepository
    {
        public int CartId { get; set; }
        public int CustomerID { get; set; }
        public int IngredientID { get; set; }
        public decimal IngredientQuantity { get; set; }
        public decimal Amount { get; set; }
        public CartRepository()
        {
            CartId = 0;
            CustomerID = 0;
            IngredientID = 0;
            IngredientQuantity = 0;
            Amount = 0;
        }
        public CartRepository(int cartid, int custid, int ingid, decimal quantity, decimal amount)
        {
            CartId = cartid;
            CustomerID = custid;
            IngredientID = ingid;
            IngredientQuantity = quantity;
            Amount = amount;
        }
    }
}
