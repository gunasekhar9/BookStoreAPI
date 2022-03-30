using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer
{
    public interface IOrdersRL
    {
        string AddOrders(OrdersModel ordersModel);
        string DeleteOrders(int OrdersId);
        List<GetOrdersModel> GetAllOrders(int id);
    }
}