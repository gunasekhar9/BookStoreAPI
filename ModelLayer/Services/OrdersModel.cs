using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Services
{
   public class OrdersModel
    {
        public int OrdersId { get; set; }
        public int id { get; set; }
        public int AddressId { get; set; }
        public int BookId { get; set; }
        public int TotalPrice { get; set; }
        public int BookQuantity { get; set; }
        public string OrderDate { get; set; }
        public string OrderPlaced { get; set; }
    }
}