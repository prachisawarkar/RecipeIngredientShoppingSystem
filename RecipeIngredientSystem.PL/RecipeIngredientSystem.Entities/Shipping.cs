using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeIngredientSystem.Entities
{
    public class Shipping
    {
        public int ShippingNumber { get; set; }
        public int OrderId { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
    }
}
