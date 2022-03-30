using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Services
{
   public  class GetOrdersModel
    {
        public int OrdersId { get; set; }
        public string OrderPlaced { get; set; }
        public GetOrderBook getOrderBook { get; set; }
    }
}