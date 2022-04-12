using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    [Table("Items")]
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int item_ID { get; set; }
        [Required(ErrorMessage = "Image cannot be empty")]
        [DataType(DataType.ImageUrl)]
        public byte[] image { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name cannot be empty")]
        public string name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Number of capsules must be bigger than 0")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "Number Of Capsules must be a number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Number of capsules cannot be empty")]
        public int nb_Of_Cap { get; set; }
        [Range(0.0, double.MaxValue, ErrorMessage = "Price must be bigger or equal 0")]
        [Required(ErrorMessage = "Price is required")]
        public double price { get; set; }
        [Required(ErrorMessage = "Expiration date cannot be empty")]
        [DataType(DataType.DateTime, ErrorMessage="Format dd/mm/yyyy")]
        public DateTime expiration_Date { get; set; }
        [Required]
        public DateTime insertion_Date { get; set; }
        [Required]
        public bool isConfirmed { get; set; }
        public int user_ID { get; set; }
        [ForeignKey("user_ID")]
        public virtual User user { get; set; }
    }
}