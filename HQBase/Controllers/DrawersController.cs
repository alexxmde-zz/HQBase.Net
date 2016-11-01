using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HQBase.Models;

namespace HQBase.Controllers
{
    public class DrawersController : Controller
    {
        private HQBaseContext db = new HQBaseContext();

        // GET: /Drawers/
        public ActionResult Index()
        {
            return View(db.Drawers.ToList());
        }

        // GET: /Drawers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drawer drawer = db.Drawers.Find(id);
            if (drawer == null)
            {
                return HttpNotFound();
            }
            return View(drawer);
        }

        // GET: /Drawers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Drawers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DrawerId,Name,LastName,BirthDate,Country")] Drawer drawer)
        {
            if (ModelState.IsValid)
            {
                db.Drawers.Add(drawer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drawer);
        }

        // GET: /Drawers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drawer drawer = db.Drawers.Find(id);
            if (drawer == null)
            {
                return HttpNotFound();
            }
            return View(drawer);
        }

        // POST: /Drawers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DrawerId,Name,LastName,BirthDate,Country")] Drawer drawer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drawer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drawer);
        }

        // GET: /Drawers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drawer drawer = db.Drawers.Find(id);
            if (drawer == null)
            {
                return HttpNotFound();
            }
            return View(drawer);
        }

        // POST: /Drawers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drawer drawer = db.Drawers.Find(id);
            db.Drawers.Remove(drawer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
