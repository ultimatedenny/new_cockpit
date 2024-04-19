using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace new_cockpit.Controllers
{
    public class SplashController : Controller
    {
        // GET: Splash
        public ActionResult Index()
        {
            return View();
        }

        // GET: Splash/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Splash/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Splash/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Splash/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Splash/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Splash/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Splash/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
