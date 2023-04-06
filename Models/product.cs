using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyDoLuuNiem.Models
{
    public class product
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string detail { get; set; }
        public string image { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public int category_id { get; set; }
    }
}