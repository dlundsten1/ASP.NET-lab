using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Laboration1.Models;

namespace Laboration1.Controllers
{
    public class SkisController : Controller
    {
      
               
        private SkisEntities2 db = new SkisEntities2();

      
        // GET: Skis
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, string filterString)
        {
            ViewBag.SkiNameSortParm = String.IsNullOrEmpty(sortOrder) ? "SkiName_desc" : "";

            var dbSkis = db.Skis.AsEnumerable().OrderBy(s => s.Sk_Name);
            var skis = from s in dbSkis select s;

          

            // var skis = from s in db.Skis select s;
            

            
                if (searchString == null)
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                skis = skis.Where(s => s.Sk_Name.ToUpper().Contains(searchString.ToUpper())); 

            }
            switch (sortOrder)
            {
                case "SkiName_desc":
                    skis = skis.OrderByDescending(s => s.Sk_Name);
                    break;

           

                default:
                    skis = skis.OrderBy(s => s.Sk_Name);
                  
                    break;
                                      
            }

            
            return View(skis.ToList());
        }


        // GET: Skis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skis skis = db.Skis.Find(id);
            if (skis == null)
            {
                return HttpNotFound();
            }
            return View(skis);
        }

        // GET: Skis/Create
        public ActionResult Create()
        {
            ViewBag.Sk_Origin = new SelectList(db.Brand, "Id", "BrandName");
            return View();
        }

        // POST: Skis/Create
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Sk_Name,Sk_Length,Sk_Width,Sk_Origin,Sk_Information")] Skis skis)
        {
            if (ModelState.IsValid)
            {
                db.Skis.Add(skis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sk_Origin = new SelectList(db.Brand, "Id", "BrandName", skis.Sk_Origin);
            return View(skis);
        }

        // GET: Skis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skis skis = db.Skis.Find(id);
            if (skis == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sk_Origin = new SelectList(db.Brand, "Id", "BrandName", skis.Sk_Origin);
            return View(skis);
        }

        // POST: Skis/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Sk_Name,Sk_Length,Sk_Width,Sk_Origin,Sk_Information")] Skis skis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sk_Origin = new SelectList(db.Brand, "Id", "BrandName", skis.Sk_Origin);
            return View(skis);
        }

        // GET: Skis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skis skis = db.Skis.Find(id);
            if (skis == null)
            {
                return HttpNotFound();
            }
            return View(skis);
        }

        // POST: Skis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skis skis = db.Skis.Find(id);
            db.Skis.Remove(skis);
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
