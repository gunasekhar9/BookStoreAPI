using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Services
{
   public  class FeedbackModel
   {
        public int FeedbackId { get; set; }
        public int id { get; set; }
        public int BookId { get; set; }
        public string Comments { get; set; }
        public int OverallRating { get; set; }
   }
}
