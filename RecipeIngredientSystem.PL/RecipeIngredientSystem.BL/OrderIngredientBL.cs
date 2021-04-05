using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeIngredientSystem.Entities;
using RecipeIngredientSystem.Exceptions;
using RecipeIngredientSystem.DAL;

namespace RecipeIngredientSystem.BL
{
    public class OrderIngredientBL
    {
        //validate cartdetails
        public static bool ValidateCart(Cart cart)
        {
            StringBuilder sb = new StringBuilder();
            bool validCart = true;

            if (cart.IngredientQuantity <= 0)
            {
                validCart = false;
                sb.Append(Environment.NewLine + "Invalid Ingredient Quantity!");
            }
            if (cart.Amount <= 0)
            {
                validCart = false;
                sb.Append(Environment.NewLine + "Invalid Ingredient Amount!");
            }

            if (validCart == false)
                throw new RecipeIngredientSystemExceptions(sb.ToString());
            return validCart;
        }
        //validate orderdetails
        public static bool ValidateOrderDetails(OrderCartIngredient order)
        {
            StringBuilder sb = new StringBuilder();
            bool validOrder = true;
            
            if (order.MobileNumber.Length < 10)
            {
                validOrder = false;
                sb.Append(Environment.NewLine + "Required 10 Digit Mobile Number");
            }
            if (order.DeliveryAddress == string.Empty)
            {
                validOrder = false;
                sb.Append(Environment.NewLine + "Delivery Address Required");
            }
            if (order.TotalBillAmount <= 0)
            {
                validOrder = false;
                sb.Append(Environment.NewLine + "Invalid Bill Amount");
            }
            if (order.GrandTotal <= 0)
            {
                validOrder = false;
                sb.Append(Environment.NewLine + "Invalid Grand Total");
            }

            if (validOrder == false)
                throw new RecipeIngredientSystemExceptions(sb.ToString());
            return validOrder;
        }
        //view Carts list
        public List<MyCart> GetCartBL(string username)
        {
            OrderIngredientDAL orderIngredientDAL = new OrderIngredientDAL();
            List<MyCart> myCartList = orderIngredientDAL.GetMyCartDAL(username);
            return myCartList;
        }
        //update cart details
        public bool UpdateCartBL(Cart cart)
        {
            try
            {
                if (cart != null)
                {
                    //validate details before updating
                    if(ValidateCart(cart))
                    {
                        OrderIngredientDAL orderIngredientDAL = new OrderIngredientDAL();
                        if (orderIngredientDAL.UpdateCartDAL(cart))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        /*public bool UpdateCartBL(Cart cart)
        {
            bool cartUpdated = false;
            try
            {
                if (ValidateCart(cart))
                {
                    OrderIngredientDAL orderIngredientDAL = new OrderIngredientDAL();
                    cartUpdated = orderIngredientDAL.UpdateCartDAL(cart);
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
            return cartUpdated;
        }*/
        //delete cart details
        public bool DeleteCartBL(Cart cart)
        {
            try
            {
                //check cart is null or not
                if (cart != null)
                {
                    OrderIngredientDAL orderIngredientDAL = new OrderIngredientDAL();
                    
                    if (orderIngredientDAL.DeleteCartDAL(cart))
                    {
                        return true;
                    }
                    else
                    {
                        throw new RecipeIngredientSystemExceptions("Select Ingredient from List To Delete");
                    }
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
            return false;
        }
        /*public bool DeleteCartBL(Cart cart)
        {
            bool cartDeleted = false;
            try
            {
                if (ValidateCart(cart))
                {
                    OrderIngredientDAL orderIngredientDAL = new OrderIngredientDAL();
                    cartDeleted = orderIngredientDAL.DeleteCartDAL(cart);
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
            return cartDeleted;
        }*/

        //add order details
        public bool AddOrderBL(OrderCartIngredient orderadd, string username)
        {
            try
            {
                if (orderadd != null)
                {
                    //validate order details before adding
                    if(ValidateOrderDetails(orderadd))
                    {
                        OrderIngredientDAL orderIngredientDAL = new OrderIngredientDAL();
                        if (orderIngredientDAL.AddOrderDAL(orderadd, username))
                        {
                            return true;
                        }
                        else
                        {
                            throw new RecipeIngredientSystemExceptions("Empty Fields");
                        }
                    }
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
            return false;
        }
        /*public bool AddOrderBL(OrderCartIngredient orderadd, string username)
        {
            bool orderAdded = false;
            try
            {
                if (ValidateOrderDetails(orderadd))
                {
                    OrderIngredientDAL orderIngredientDAL = new OrderIngredientDAL();
                    orderAdded = orderIngredientDAL.AddOrderDAL(orderadd, username);
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
            return orderAdded;
        }*/
        //calculate total amount
        public decimal Totalamount(string username)
        {
            List<Cart> cartList = new List<Cart>();
            decimal totalamount = 0;
            try
            {
                OrderIngredientDAL orderIngredientDAL = new OrderIngredientDAL();
                cartList = orderIngredientDAL.TotalAmountDAL(username);
                //total amount calculation
                for (int i = 0; i < cartList.Count; i++)
                {
                    totalamount += cartList[i].Amount;
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
            return totalamount;
        }
    }
}
