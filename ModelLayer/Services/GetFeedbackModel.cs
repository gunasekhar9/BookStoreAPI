﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Services
{
    public class GetFeedbackModel
    {
        public int FeedbackId { get; set; }
        public int id { get; set; }
        public int BookId { get; set; }
        public string Comments { get; set; }
        public int OverallRating { get; set; }
        public FeedbackDetails details { get; set; }
    }
}
