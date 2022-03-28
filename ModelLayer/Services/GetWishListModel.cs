using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Services
{
    public class GetWishlistModel
    {
        public int WishListId { get; set; }
        public int id { get; set; }
        public int BookId { get; set; }
        public BookModel bookModel { get; set; }
    }
}
