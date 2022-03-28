using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        IWishListBL wishListBL;
        public WishListController(IWishListBL wishListBL)
        {
            this.wishListBL = wishListBL;
        }
        [HttpPost]
        public ActionResult AddBookToWishlist(WishListModel wishListModel)
        {
            try
            {
                string result = this.wishListBL.AddBookToWishlist(wishListModel);
                if (result.Equals("Book added to WishList successfully"))
                {
                    return this.Ok(new { success = true, message = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpDelete]
        public ActionResult DeleteWishlist(int WishListId)
        {
            try
            {
                string result = this.wishListBL.DeleteWishlist(WishListId);
                if (result.Equals("Book deleted in WishList successfully"))
                {
                    return this.Ok(new { success = true, message = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet]
        public ActionResult GetWishlistData(int id)
        {
            try
            {
                var result = this.wishListBL.GetWishlistData(id);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "These are the Books in wishlist are : ", response = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
