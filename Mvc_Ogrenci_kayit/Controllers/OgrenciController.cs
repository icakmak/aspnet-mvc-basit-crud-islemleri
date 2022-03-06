using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc_Ogrenci_kayit.Models;

namespace Mvc_Ogrenci_kayit.Controllers
{
    public class OgrenciController : Controller
    {
        private OgrenciEntities db = new OgrenciEntities();

        // GET: Ogrenci
        public ActionResult Index()
        {
            return View(db.TBL_Ogrenci.ToList());
        }

        // GET: Ogrenci/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Ogrenci tBL_Ogrenci = db.TBL_Ogrenci.Find(id);
            if (tBL_Ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Ogrenci);
        }

        // GET: Ogrenci/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ogrenci/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OgrId,OgrAd,OgrSoyad,OgrMail,OgrAdres,OgrFotograf")] TBL_Ogrenci tBL_Ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Ogrenci.Add(tBL_Ogrenci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_Ogrenci);
        }

        // GET: Ogrenci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Ogrenci tBL_Ogrenci = db.TBL_Ogrenci.Find(id);
            if (tBL_Ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Ogrenci);
        }

        // POST: Ogrenci/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgrId,OgrAd,OgrSoyad,OgrMail,OgrAdres,OgrFotograf")] TBL_Ogrenci tBL_Ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Ogrenci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_Ogrenci);
        }

        // GET: Ogrenci/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Ogrenci tBL_Ogrenci = db.TBL_Ogrenci.Find(id);
            if (tBL_Ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Ogrenci);
        }

        // POST: Ogrenci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Ogrenci tBL_Ogrenci = db.TBL_Ogrenci.Find(id);
            db.TBL_Ogrenci.Remove(tBL_Ogrenci);
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
