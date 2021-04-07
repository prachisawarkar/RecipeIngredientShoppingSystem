using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeIngredientSystem.Entities
{
    public class AdminOrder
    {
		public int OrderIngredientId { get; set; }
		public int CustomerId { get; set; }
		public DateTime DateOfOrder { get; set; }
		public string MobileNumber { get; set; }
		public string DeliveryAddress { get; set; }
		public decimal TotalBillAmount { get; set; }
		public decimal GrandTotal { get; set; }
		public int NumberOfIngredients { get; set; }
	}
}
