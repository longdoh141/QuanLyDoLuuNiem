using QuanLyDoLuuNiem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDoLuuNiem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new Product_DAL().getProducts());
        }


        public ActionResult Product()
        {
            return View(new Product_DAL().getProducts());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}