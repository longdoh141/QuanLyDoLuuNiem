using QuanLyDoLuuNiem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDoLuuNiem.Models
{
    public class ProductModel
    {
        private List<Cart> products;
        Product_DAL ob = new Product_DAL();
        public ProductModel() { }
        public List<Cart> FindAll()
        {
            return products;
        }
        public Cart FindProduct(int id)
        {
            var list = ob.getProductByID(id).FirstOrDefault();
            this.products = new List<Cart>() {
                new Cart{
                    id = list.id ,
                    name = list.name,
                    price = list.price,
                }
            };
            return this.products.FirstOrDefault();
        }
    }
}