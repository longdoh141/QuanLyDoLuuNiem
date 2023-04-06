using QuanLyDoLuuNiem.DAL;
using QuanLyDoLuuNiem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDoLuuNiem.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            List<Cart> cart = Session["cart"] as List<Cart>;
            return View(cart);
        }

        public RedirectToRouteResult AddToCart(int id)
        {
            if (Session["cart"] == null)
            {
                Session["cart"] = new List<Cart>();
            }
            List<Cart> cart = Session["cart"] as List<Cart>;

            if (cart.FirstOrDefault(m => m.id == id) == null)
            {
                ProductModel sm = new ProductModel();
                Cart product = sm.FindProduct(id);
                Cart newItem = new Cart()
                {
                    id = product.id,
                    name = product.name,
                    quantity = 1,
                    //Anhbia = product.Anhbia,
                    price = product.price,
                };
                cart.Add(newItem);
            }
            else
            {
                Cart cartItem = cart.FirstOrDefault(m => m.id == id);
                cartItem.quantity++;
            }

            return RedirectToAction("Index");
        }

        // GET: Cart/Details/5
        public ActionResult CheckOut()
        {
            //Lay du lieu tu gio hang 
            var cart = (List<Cart>)Session["cart"];
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Order ob = new Order();
            ob.name = "Don hang_" + now;
            //ob.UserID = 1;
            //ob. = 0;
            ob.dateCreated = Convert.ToDateTime(now);
            new Order_DAL().Insert(ob);
            int Order_Id = new Order_DAL().GetID(ob);

            foreach (var item in cart)
            {
                Detail ob1 = new Detail();
                ob1.order_id = Order_Id;
                ob1.product_id = item.id;
                ob1.quantity = item.quantity;
                ob1.price = (float)item.price;
                new Detail_DAL().Insert(ob1);
            }
            return View("CheckOutResult");
        }

        public ActionResult Update(int id, FormCollection f)
        {
            List<Cart> cart = Session["cart"] as List<Cart>;
            Cart EditAmount = cart.FirstOrDefault(m => m.id == id);
            if (EditAmount != null)
            {
                EditAmount.quantity = int.Parse(f["quantity"].ToString());
            }
            return RedirectToAction("Index");
        }

        public ActionResult RemoveItem(int id)
        {
            List<Cart> cart = Session["cart"] as List<Cart>;
            Cart DeleteItem = cart.FirstOrDefault(m => m.id == id);
            if (DeleteItem != null)
            {
                cart.Remove(DeleteItem);
            }
            return RedirectToAction("Index");
        }
    }
}
