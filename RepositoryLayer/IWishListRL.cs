using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer
{
    public interface IWishListRL
    {
        string AddBookToWishlist(WishListModel wishListModel);
        string DeleteWishlist(int WishListId);
        List<GetWishlistModel> GetWishListData(int id);
    }
}