using QuanLyDoLuuNiem.DAL;
using QuanLyDoLuuNiem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDoLuuNiem.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View(new Product_DAL().getProducts());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(new Product_DAL().getProductByID(id).FirstOrDefault());
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(product p)
        {
            try
            {
                // TODO: Add insert logic here
                new Product_DAL().Insert(p);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Product_DAL().getProductByID(id).FirstOrDefault());
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, product p)
        {
            try
            {
                // TODO: Add update logic here
                new Product_DAL().Update(p);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Product_DAL().getProductByID(id).FirstOrDefault());
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteByID(int id)
        {
            try
            {
                // TODO: Add delete logic here
                new Product_DAL().delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
