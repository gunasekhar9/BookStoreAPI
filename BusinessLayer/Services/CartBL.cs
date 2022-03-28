using ModelLayer.Services;
using RepositoryLayer;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class CartBL : ICartBL
    {
        ICartRL cartRL;
        public CartBL(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }

        public string AddBookToCart(CartModel cartModel)
        {
            try
            {
                return this.cartRL.AddBookToCart(cartModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string DeleteCart(int CartId)
        {
            try
            {
                return this.cartRL.DeleteCart(CartId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<GetCartModel> GetCartData(int Id)
        {
            try
            {
                return this.cartRL.GetCartData(Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string UpdateCart(int CartId, int OrderQuantity)
        {
            try
            {
                return this.cartRL.UpdateCart(CartId, OrderQuantity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
