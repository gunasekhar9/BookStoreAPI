using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrdersBL ordersBL;
        public OrdersController(IOrdersBL ordersBL)
        {
            this.ordersBL = ordersBL;
        }
        [HttpPost]
        public ActionResult AddOrders(OrdersModel ordersModel)
        {
            try
            {
                string result = this.ordersBL.AddOrders(ordersModel);
                if (result.Equals("Success:- Ordered successfully"))
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
        public ActionResult DeleteOrders(int OrdersId)
        {
            try
            {
                string result = this.ordersBL.DeleteOrders(OrdersId);
                if (result.Equals("Order deleted successfully"))
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
        public ActionResult GetAllOrders(int id)
        {
            try
            {
                var result = this.ordersBL.GetAllOrders(id);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "These are the all Orders : ", response = result });
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
