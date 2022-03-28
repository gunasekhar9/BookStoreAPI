using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface IWishListBL
    {
        string AddBookToWishlist(WishListModel wishListModel);
        string DeleteWishlist(int WishListId);
        List<GetWishlistModel> GetWishlistData(int id);
    }
}
