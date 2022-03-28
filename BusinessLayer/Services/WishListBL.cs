using ModelLayer.Services;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class WishListBL : IWishListBL
    {
        IWishListRL wishListRL;
        public WishListBL(IWishListRL wishListRL)
        {
            this.wishListRL = wishListRL;
        }

        public string AddBookToWishlist(WishListModel wishListModel)
        {
            try
            {
                return this.wishListRL.AddBookToWishlist(wishListModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string DeleteWishlist(int WishListId)
        {
            try
            {
                return this.wishListRL.DeleteWishlist(WishListId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<GetWishlistModel> GetWishlistData(int id)
        {
            try
            {
                return this.wishListRL.GetWishListData(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
