using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeIngredientSystem.Entities
{
    public class OrderCartIngredient
    {
        public int OrderId { get; set;}
        public int CustomerId { get; set; }
        public DateTime DateOfOrder { get; set; }
        public string MobileNumber { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalBillAmount { get; set; }
        public int NoOfIngredients { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
