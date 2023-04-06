using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace QuanLyDoLuuNiem.Models
{
    public class Cart
    {
        public int id { get; set; }
        [DisplayName("Tên")]
        public string name { get; set; }
        [DisplayName("Giá bán")]
        public double price { get; set; }
        [DisplayName("Số lượng")]
        public int quantity { get; set; }
        [DisplayName("Thành tiền")]
        public double Total
        {
            get
            {
                return price * quantity;
            }
        }
    }
}