using Microsoft.Extensions.Configuration;
using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class OrdersRL : IOrdersRL
    {
        private SqlConnection con;
        private readonly IConfiguration configuration;
        public OrdersRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string AddOrders(OrdersModel ordersModel)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("AddOrders", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", ordersModel.id);
                    cmd.Parameters.AddWithValue("@AddressId", ordersModel.AddressId);
                    cmd.Parameters.AddWithValue("@BookId", ordersModel.BookId);
                    cmd.Parameters.AddWithValue("@BookQuantity", ordersModel.BookId);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 1)
                    {
                        return "Success:- Ordered successfully";
                    }
                    else
                    {
                        return "Pleace Try once again...";
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

        public string DeleteOrders(int OrdersId)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("DeleteOrders", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrdersId", OrdersId);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 1)
                    {
                        return "Order deleted successfully";
                    }
                    else
                    {
                        return "Order is not deleted check once...";
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

        public List<GetOrdersModel> GetAllOrders(int id)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    List<GetOrdersModel> orders = new List<GetOrdersModel>();
                    SqlCommand cmd = new SqlCommand("GetAllOrders", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            GetOrdersModel ordersModel = new GetOrdersModel();
                            GetOrderBook getOrderBook = new GetOrderBook();
                            ordersModel.OrdersId = Convert.ToInt32(dr["OrdersId"]);
                            ordersModel.OrderPlaced = dr["OrderPlaced"].ToString();
                            getOrderBook.BookId = Convert.ToInt32(dr["BookId"]);
                            getOrderBook.BookName = dr["BookName"].ToString();
                            getOrderBook.AuthorName = dr["AuthorName"].ToString();
                            getOrderBook.DiscountPrice = Convert.ToInt32(dr["DiscountPrice"]);
                            getOrderBook.OriginalPrice = Convert.ToInt32(dr["OriginalPrice"]);
                            getOrderBook.Image = dr["Image"].ToString();
                            ordersModel.getOrderBook = getOrderBook;
                            orders.Add(ordersModel);
                        }
                        return orders;
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
