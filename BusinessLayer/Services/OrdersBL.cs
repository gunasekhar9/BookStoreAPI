using ModelLayer.Services;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class OrdersBL : IOrdersBL
    {
        IOrdersRL ordersRL;
        public OrdersBL(IOrdersRL ordersRL)
        {
            this.ordersRL = ordersRL;
        }

        public string AddOrders(OrdersModel ordersModel)
        {

            try
            {
                return this.ordersRL.AddOrders(ordersModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string DeleteOrders(int OrdersId)
        {
            try
            {
                return this.ordersRL.DeleteOrders(OrdersId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<GetOrdersModel> GetAllOrders(int id)
        {

            try
            {
                return this.ordersRL.GetAllOrders(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}