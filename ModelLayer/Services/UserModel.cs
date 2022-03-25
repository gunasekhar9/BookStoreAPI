using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer.Services
{
    public class UserModel
    {
        public int UserId {get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string MobileNumber { get; set; } 
    }
}
