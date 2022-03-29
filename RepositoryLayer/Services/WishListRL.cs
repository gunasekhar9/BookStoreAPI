using Microsoft.Extensions.Configuration;
using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class WishListRL : IWishListRL
    {
        private SqlConnection con;
        private readonly IConfiguration configuration;
        public WishListRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string AddBookToWishlist(WishListModel wishListModel)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("AddBookToWishlist", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", wishListModel.id);
                    cmd.Parameters.AddWithValue("@BookId", wishListModel.BookId);
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return "Book added to WishList successfully";
                    }
                    else
                    {
                        return "Book is not added to WishList";
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        public string DeleteWishlist(int WishListId)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("DeleteWishlist", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WishListId", WishListId);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 1)
                    {
                        return "Book deleted in WishList successfully";
                    }
                    else
                    {
                        return "Book is not deleted in WishList";
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        public List<GetWishlistModel> GetWishListData(int id)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    List<GetWishlistModel> wishlist = new List<GetWishlistModel>();
                    SqlCommand cmd = new SqlCommand("GetWishlist", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            GetWishlistModel wishlistmodel = new GetWishlistModel();
                            BookModel bookModel = new BookModel();
                            bookModel.BookName = dr["BookName"].ToString();
                            bookModel.AuthorName = dr["AuthorName"].ToString();
                            bookModel.DiscountPrice = Convert.ToInt32(dr["DiscountPrice"]);
                            bookModel.OriginalPrice = Convert.ToInt32(dr["OriginalPrice"]);
                            bookModel.Description = dr["Description"].ToString();
                            bookModel.Rating = Convert.ToDouble(dr["Rating"]);
                            bookModel.Image = dr["Image"].ToString();
                            bookModel.ReviewCount = Convert.ToInt32(dr["ReviewCount"]);
                            bookModel.BookCount = Convert.ToInt32(dr["BookCount"]);
                            wishlistmodel.WishListId = Convert.ToInt32(dr["WishListId"]);
                            wishlistmodel.id = Convert.ToInt32(dr["id"]);
                            wishlistmodel.BookId = Convert.ToInt32(dr["BookId"]);
                            wishlistmodel.bookModel = bookModel;
                            wishlist.Add(wishlistmodel);
                        }
                        return wishlist;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }
    }
}