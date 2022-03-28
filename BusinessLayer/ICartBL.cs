using ModelLayer.Services;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface ICartBL
    {
        string AddBookToCart(CartModel cartModel);
        string UpdateCart(int CartId, int OrderQuantity);
        string DeleteCart(int CartId);
        List<GetCartModel> GetCartData(int Id);
    }
}
