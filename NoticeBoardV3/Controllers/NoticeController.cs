using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NoticeBoardV3.DAL;
using NoticeBoardV3.Models;

namespace NoticeBoardV3.Controllers
{
    public class NoticeController : Controller
    {
        private NoticeboardContext db = new NoticeboardContext();

        // GET: Notice
        public ActionResult Index()
        {
            var notices = db.Notices.Include(n => n.PerOrg);
            return View(notices.ToList());
        }

        // GET: Notice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice notice = db.Notices.Find(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }

        // GET: Notice/Create
        public ActionResult Create()
        {
            ViewBag.PerOrg_ID = new SelectList(db.PerOrgs, "PerOrg_ID", "OrganisationName");
            return View();
        }

        // POST: Notice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Notice_ID,NoticeName,NoticeDesc,PerOrg_ID")] Notice notice)
        {
            if (ModelState.IsValid)
            {
                db.Notices.Add(notice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PerOrg_ID = new SelectList(db.PerOrgs, "PerOrg_ID", "OrganisationName", notice.PerOrg_ID);
            return View(notice);
        }

        // GET: Notice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice notice = db.Notices.Find(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            ViewBag.PerOrg_ID = new SelectList(db.PerOrgs, "PerOrg_ID", "OrganisationName", notice.PerOrg_ID);
            return View(notice);
        }

        // POST: Notice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Notice_ID,NoticeName,NoticeDesc,PerOrg_ID")] Notice notice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PerOrg_ID = new SelectList(db.PerOrgs, "PerOrg_ID", "OrganisationName", notice.PerOrg_ID);
            return View(notice);
        }

        // GET: Notice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice notice = db.Notices.Find(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }

        // POST: Notice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notice notice = db.Notices.Find(id);
            db.Notices.Remove(notice);
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
