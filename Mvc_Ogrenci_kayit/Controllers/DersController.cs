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
    public class DersController : Controller
    {
        private OgrenciEntities db = new OgrenciEntities();

        // GET: Ders
        public ActionResult Index()
        {
            return View(db.TBL_Dersler.ToList());
        }

        // GET: Ders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Dersler tBL_Dersler = db.TBL_Dersler.Find(id);
            if (tBL_Dersler == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Dersler);
        }

        // GET: Ders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DersId,DersAdi")] TBL_Dersler tBL_Dersler)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Dersler.Add(tBL_Dersler);
                db.SaveChanges();
                var ogrenci = db.TBL_Ogrenci.ToList();
                TBL_Not not = new TBL_Not();
                foreach (var item in ogrenci)
                {
                    not.OgrenciID = item.OgrId;
                    not.DersID = tBL_Dersler.DersId;
                    not.not1 = 0;
                    not.not2 = 0;
                    db.TBL_Not.Add(not);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(tBL_Dersler);
        }

        // GET: Ders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Dersler tBL_Dersler = db.TBL_Dersler.Find(id);
            if (tBL_Dersler == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Dersler);
        }

        // POST: Ders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DersId,DersAdi")] TBL_Dersler tBL_Dersler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Dersler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_Dersler);
        }

        // GET: Ders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Dersler tBL_Dersler = db.TBL_Dersler.Find(id);
            if (tBL_Dersler == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Dersler);
        }

        // POST: Ders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Dersler tBL_Dersler = db.TBL_Dersler.Find(id);
            var not = db.TBL_Not.Where(i => i.DersID == id).ToList();

            foreach (var item in not)
            {
                //Console.WriteLine(item.OgrenciID);
                db.TBL_Not.Remove(db.TBL_Not.Find(item.NotId));
                db.SaveChanges();
            }
            db.TBL_Dersler.Remove(tBL_Dersler);
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
