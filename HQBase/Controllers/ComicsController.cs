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
    public class ComicsController : Controller
    {
        private HQBaseContext db = new HQBaseContext();

        // GET: /Comics/
        public ActionResult Index()
        {
            var comics = db.Comics.Include(c => c.Collection).Include(c => c.Drawer).Include(c => c.Publisher).Include(c => c.Writer);
            return View(comics.ToList());
        }

        // GET: /Comics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comic comic = db.Comics.Find(id);
            if (comic == null)
            {
                return HttpNotFound();
            }
            return View(comic);
        }

        // GET: /Comics/Create
        public ActionResult Create()
        {
            ViewBag.CollectionId = new SelectList(db.Collections, "CollectionId", "Title");
            var linkzao = (IEnumerable<SelectListItem>)
                (from d in db.Drawers
                 select new SelectListItem
                 {
                     Value = d.DrawerId.ToString(),
                     Text = d.Name + " " + d.LastName
                 });

            ViewBag.DrawerId = new SelectList(linkzao,"","","");
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Title");
            ViewBag.WriterId = new SelectList(db.Writers, "WriterId", "Name");
            return View();
        }

        // POST: /Comics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ComicId,Title,PublisherId,DrawerId,WriterId,CollectionId,EditionNum")] Comic comic)
        {
            if (ModelState.IsValid)
            {
                db.Comics.Add(comic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CollectionId = new SelectList(db.Collections, "CollectionId", "Title", comic.CollectionId);
            ViewBag.DrawerId = new SelectList(db.Drawers, "DrawerId", "Name", comic.DrawerId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Title", comic.PublisherId);
            ViewBag.WriterId = new SelectList(db.Writers, "WriterId", "Name", comic.WriterId);
            return View(comic);
        }

        // GET: /Comics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comic comic = db.Comics.Find(id);
            if (comic == null)
            {
                return HttpNotFound();
            }
            ViewBag.CollectionId = new SelectList(db.Collections, "CollectionId", "Title", comic.CollectionId);
            ViewBag.DrawerId = new SelectList(db.Drawers, "DrawerId", "Name", comic.DrawerId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Title", comic.PublisherId);
            ViewBag.WriterId = new SelectList(db.Writers, "WriterId", "Name", comic.WriterId);
            return View(comic);
        }

        // POST: /Comics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ComicId,Title,PublisherId,DrawerId,WriterId,CollectionId,EditionNum")] Comic comic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CollectionId = new SelectList(db.Collections, "CollectionId", "Title", comic.CollectionId);
            ViewBag.DrawerId = new SelectList(db.Drawers, "DrawerId", "Name", comic.DrawerId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Title", comic.PublisherId);
            ViewBag.WriterId = new SelectList(db.Writers, "WriterId", "Name", comic.WriterId);
            return View(comic);
        }

        // GET: /Comics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comic comic = db.Comics.Find(id);
            if (comic == null)
            {
                return HttpNotFound();
            }
            return View(comic);
        }

        // POST: /Comics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comic comic = db.Comics.Find(id);
            db.Comics.Remove(comic);
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
