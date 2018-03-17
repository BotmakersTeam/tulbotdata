using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TULbotpage.Models;

namespace TULbotpage.Controllers
{
    public class PeopleController : Controller
    {
        private tulbotdevEntities db = new tulbotdevEntities();

        // GET: People
        public ActionResult Index()
        {
            return View(db.peoples.ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            peoples peoples = db.peoples.Find(id);
            if (peoples == null)
            {
                return HttpNotFound();
            }
            return View(peoples);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Name,Surname,Department,Consultation,Tel")] peoples peoples)
        {
            if (ModelState.IsValid)
            {
                db.peoples.Add(peoples);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peoples);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            peoples peoples = db.peoples.Find(id);
            if (peoples == null)
            {
                return HttpNotFound();
            }
            return View(peoples);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Name,Surname,Department,Consultation,Tel")] peoples peoples)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peoples).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peoples);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            peoples peoples = db.peoples.Find(id);
            if (peoples == null)
            {
                return HttpNotFound();
            }
            return View(peoples);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            peoples peoples = db.peoples.Find(id);
            db.peoples.Remove(peoples);
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
