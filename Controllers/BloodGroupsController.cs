using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SaviourRedDrop.Models;

namespace SaviourRedDrop.Controllers
{
    public class BloodGroupsController : Controller
    {
        private UserDbContext db = new UserDbContext();

        // GET: BloodGroups
        public ActionResult Index(int mobile = 0)
        {
         

            if (mobile == 0)
            {
                return View(db.dbBloodGroup.ToList());
            }
            else
            {

                return Json(db.dbBloodGroup.ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        // GET: BloodGroups/Details/5
        public ActionResult Details(int? id, int mobile = 0)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodGroup bloodGroup = db.dbBloodGroup.Find(id);
            if (bloodGroup == null)
            {
                return HttpNotFound();
            }

            if (mobile == 0)
            {
                return View(bloodGroup);
            }
            else {

                return Json(bloodGroup, JsonRequestBehavior.AllowGet);
            }
               
        }

        // GET: BloodGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BloodGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BloodGroupName")] BloodGroup bloodGroup)
        {
            if (ModelState.IsValid)
            {
                db.dbBloodGroup.Add(bloodGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloodGroup);
        }

        // GET: BloodGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodGroup bloodGroup = db.dbBloodGroup.Find(id);
            if (bloodGroup == null)
            {
                return HttpNotFound();
            }
            return View(bloodGroup);
        }

        // POST: BloodGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BloodGroupName")] BloodGroup bloodGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bloodGroup);
        }

        // GET: BloodGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodGroup bloodGroup = db.dbBloodGroup.Find(id);
            if (bloodGroup == null)
            {
                return HttpNotFound();
            }
            return View(bloodGroup);
        }

        // POST: BloodGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BloodGroup bloodGroup = db.dbBloodGroup.Find(id);
            db.dbBloodGroup.Remove(bloodGroup);
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
