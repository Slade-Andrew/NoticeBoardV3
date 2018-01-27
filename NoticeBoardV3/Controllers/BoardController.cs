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
    public class BoardController : Controller
    {
        private NoticeboardContext db = new NoticeboardContext();

        // GET: Board
        public ActionResult Index()
        {
            var boards = db.Boards.Include(b => b.BoardType).Include(b => b.PerOrg);
            return View(boards.ToList());
        }

        // GET: Board/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board board = db.Boards.Find(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            return View(board);
        }

        // GET: Board/Create
        public ActionResult Create()
        {
            ViewBag.BoardType_ID = new SelectList(db.BoardTypes, "BoardType_ID", "BoardType_Name");
            ViewBag.PerOrg_ID = new SelectList(db.PerOrgs, "PerOrg_ID", "OrganisationName");
            return View();
        }

        // POST: Board/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Board_ID,BoardType_ID,PerOrg_ID,BoardName,BoardDesc")] Board board)
        {
            if (ModelState.IsValid)
            {
                db.Boards.Add(board);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BoardType_ID = new SelectList(db.BoardTypes, "BoardType_ID", "BoardType_Name", board.BoardType_ID);
            ViewBag.PerOrg_ID = new SelectList(db.PerOrgs, "PerOrg_ID", "OrganisationName", board.PerOrg_ID);
            return View(board);
        }

        // GET: Board/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board board = db.Boards.Find(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            ViewBag.BoardType_ID = new SelectList(db.BoardTypes, "BoardType_ID", "BoardType_Name", board.BoardType_ID);
            ViewBag.PerOrg_ID = new SelectList(db.PerOrgs, "PerOrg_ID", "OrganisationName", board.PerOrg_ID);
            return View(board);
        }

        // POST: Board/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Board_ID,BoardType_ID,PerOrg_ID,BoardName,BoardDesc")] Board board)
        {
            if (ModelState.IsValid)
            {
                db.Entry(board).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BoardType_ID = new SelectList(db.BoardTypes, "BoardType_ID", "BoardType_Name", board.BoardType_ID);
            ViewBag.PerOrg_ID = new SelectList(db.PerOrgs, "PerOrg_ID", "OrganisationName", board.PerOrg_ID);
            return View(board);
        }

        // GET: Board/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board board = db.Boards.Find(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            return View(board);
        }

        // POST: Board/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Board board = db.Boards.Find(id);
            db.Boards.Remove(board);
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
