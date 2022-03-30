using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface IOrdersBL
    {
        string AddOrders(OrdersModel ordersModel);
        string DeleteOrders(int OrdersId);
        List<GetOrdersModel> GetAllOrders(int id);
    }
}