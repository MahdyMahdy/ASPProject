using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int add_ID { get; set; }
        public string governorat { get; set; }
        
        public string city { get; set; }
        public string route { get; set; }
        [Index(IsUnique = true)]
        public int user_ID { get; set; }
        [ForeignKey("user_ID")]
        public virtual User user { get; set; }
    }
}