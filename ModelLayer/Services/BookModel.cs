using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer.Services
{
    public class BookModel
    {


        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public int DiscountPrice { get; set; }
        [Required]
        public int OriginalPrice { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Double Rating { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int ReviewCount { get; set; }
        [Required]
        public int BookCount { get; set; }
    }
}
