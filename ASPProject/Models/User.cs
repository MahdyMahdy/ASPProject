using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int user_ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name cannot be empty")]
        public string first_Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name cannot be empty")]
        public string last_Name { get; set; }

        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,3}$", ErrorMessage = "Email incorrect syntax")]
        public string email { get; set; }

        [RegularExpression(@"^(([0][0]|[+])([9][6][1])([0-9]{1}|[0][3]|[7][0]|[7][1]|[7][6]|[7][8]|[7][9])([0-9]{6}))$", ErrorMessage = "phone incorrect syntax")]
        public string phone_Number { get; set; }
    }
}