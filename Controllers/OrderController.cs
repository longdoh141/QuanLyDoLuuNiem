using QuanLyDoLuuNiem.DAL;
using QuanLyDoLuuNiem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDoLuuNiem.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View(new Order_DAL().Gets());
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View(new Order_DAL().getByID(id).FirstOrDefault());
        }

        // GET: Order/Details/5
        public ActionResult CheckOut(int id)
        {
            return View(new Order_DAL().getByID(id).FirstOrDefault());
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(Order o)
        {
            try
            {
                // TODO: Add insert logic here
                new Order_DAL().Insert(o);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Order_DAL().getByID(id).FirstOrDefault());
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(Order o)
        {
            try
            {
                // TODO: Add update logic here
                new Order_DAL().Update(o);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Order_DAL().getByID(id).FirstOrDefault());
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteByID(int id)
        {
            try
            {
                // TODO: Add delete logic here
                new Order_DAL().delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
