﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCCodeFirstPrac1.Models;

namespace MVCCodeFirstPrac1.Controllers
{
    public class MagazinesController : Controller
    {
        private MagazineDBContext db = new MagazineDBContext();

        // GET: Magazines
        public ActionResult Index()
        {
            return View(db.Mags.ToList());
        }

        // GET: Magazines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Magazine magazine = db.Mags.Find(id);
            if (magazine == null)
            {
                return HttpNotFound();
            }
            return View(magazine);
        }

        // GET: Magazines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Magazines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ISBN,Genre,Price")] Magazine magazine)
        {
            if (ModelState.IsValid)
            {
                db.Mags.Add(magazine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(magazine);
        }

        // GET: Magazines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Magazine magazine = db.Mags.Find(id);
            if (magazine == null)
            {
                return HttpNotFound();
            }
            return View(magazine);
        }

        // POST: Magazines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ISBN,Genre,Price")] Magazine magazine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(magazine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(magazine);
        }

        // GET: Magazines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Magazine magazine = db.Mags.Find(id);
            if (magazine == null)
            {
                return HttpNotFound();
            }
            return View(magazine);
        }

        // POST: Magazines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Magazine magazine = db.Mags.Find(id);
            db.Mags.Remove(magazine);
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


        public ActionResult Fast()
        {
            return View();
        }

        public ActionResult Smile()
        {
            int x = 10;
            if(x == 10)
            {
                return RedirectToAction("Index");
            }


            return View();
        }

    }
}
