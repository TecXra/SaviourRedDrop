using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SaviourRedDrop.Models;
using Newtonsoft.Json;
using Microsoft.AspNet.Identity;

namespace SaviourRedDrop.Controllers
{
    public class SaviourRDUsersController : Controller
    {
        private UserDbContext db = new UserDbContext();

        // GET: SaviourRDUsers
        public ActionResult Index(int mobile = 0)
        {
            var dbUser = db.dbUser.Include(s => s.BloodGroup).Include(s => s.City);
          

            if (mobile == 0)
            {
                return View(dbUser.ToList());
            }
            else
            {
                var list = JsonConvert.SerializeObject(dbUser.ToList(),
                        Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize
                        });

                return Content(list, "application/json");


              //  return Json(dbUser.ToList(), JsonRequestBehavior.AllowGet);
            }

        }

        // GET: SaviourRDUsers/Details/5
        public ActionResult Details(int? id , int mobile = 0)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaviourRDUser saviourRDUser = db.dbUser.Find(id);
            if (saviourRDUser == null)
            {
                return HttpNotFound();
            }
        

            if (mobile == 0)
            {
                return View(saviourRDUser);
            }
            else
            {

                return Json(saviourRDUser, JsonRequestBehavior.AllowGet);
            }
        }
        [Authorize]
        // GET: SaviourRDUsers/Create
        public ActionResult Create()
        {
            ViewBag.BGId = new SelectList(db.dbBloodGroup, "Id", "BloodGroupName");
            ViewBag.Area = new SelectList(db.dbCity, "Id", "CityName");
            return View();
        }

        // POST: SaviourRDUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Name,Password,ReviewStatus,BGId,Area,PhoneNumber")] SaviourRDUser saviourRDUser)
        {
            string uId = User.Identity.GetUserId();
            saviourRDUser.appUserId = uId;
            if (ModelState.IsValid)
            {
                db.dbUser.Add(saviourRDUser);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            ViewBag.BGId = new SelectList(db.dbBloodGroup, "Id", "BloodGroupName", saviourRDUser.BGId);
            ViewBag.Area = new SelectList(db.dbCity, "Id", "CityName", saviourRDUser.Area);
            return View(saviourRDUser);
        }

        // GET: SaviourRDUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaviourRDUser saviourRDUser = db.dbUser.Find(id);
            if (saviourRDUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.BGId = new SelectList(db.dbBloodGroup, "Id", "BloodGroupName", saviourRDUser.BGId);
            ViewBag.Area = new SelectList(db.dbCity, "Id", "CityName", saviourRDUser.Area);
            return View(saviourRDUser);
        }

        // POST: SaviourRDUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Name,Password,ReviewStatus,BGId,Area,PhoneNumber")] SaviourRDUser saviourRDUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saviourRDUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BGId = new SelectList(db.dbBloodGroup, "Id", "BloodGroupName", saviourRDUser.BGId);
            ViewBag.Area = new SelectList(db.dbCity, "Id", "CityName", saviourRDUser.Area);
            return View(saviourRDUser);
        }

        // GET: SaviourRDUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaviourRDUser saviourRDUser = db.dbUser.Find(id);
            if (saviourRDUser == null)
            {
                return HttpNotFound();
            }
            return View(saviourRDUser);
        }

        // POST: SaviourRDUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaviourRDUser saviourRDUser = db.dbUser.Find(id);
            db.dbUser.Remove(saviourRDUser);
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
