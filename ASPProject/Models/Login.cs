using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class Login
    {
        [Key]
        [Required(ErrorMessage = "Username cannot be empty")]
        [Index(IsUnique = true)]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public enum role { ADMIN,USER }
        [Required]
        public int user_ID { get; set; } 
        [ForeignKey("user_ID")]
        public virtual User user { get; set; }
    }
}