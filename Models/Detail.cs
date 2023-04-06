using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyDoLuuNiem.Models
{
    public class Detail
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int order_id { get; set; }
        [Required]
        public int product_id { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public float price { get; set; }
    }
}