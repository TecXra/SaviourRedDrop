using SaviourRedDrop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Newtonsoft.Json;
using Microsoft.AspNet.Identity;

namespace SaviourRedDrop.Controllers
{
    public class HomeController : Controller
    {

        private UserDbContext db = new UserDbContext();
        public ActionResult Index(int mobile = 0)
        {
            ViewBag.myName = "Raza";
            //return View();
            if (mobile == 0)
                return View();
            else
                return View();
        }

        [Authorize]
        public ActionResult Details(int id)
        {

            string uId = User.Identity.GetUserId();
            var authUser = db.dbUser.FirstOrDefault(c => c.appUserId == uId);

            //   var user = User.Identity.Name;

            //   var test = db.dbCity.FirstOrDefault(c => c.CityName == s);

            /*
            
            get current user and set ReviewStatus == id of current user to id
            
            */
            if (authUser.ReviewStatus == 0)
            {

                var user = db.dbUser.Include(p => p.Reviews).Where(u => u.Id == id).Single();

                authUser.ReviewStatus = user.Id;
                db.Entry(authUser).State = EntityState.Modified;
                db.SaveChanges();
                return View(user);


            }
            else { // redirect with

                TempData["FlashMessage"] = "Please give the user review first";

                var user = db.dbUser.Include(p => p.Reviews).Where(u => u.Id == authUser.ReviewStatus).Single();



                return View(user);

            }
            //       else Redirect it to from where is has come with RevieweeID =  currentuser.ReviewStatus to give feedback of this use

            /*
                      var list = JsonConvert.SerializeObject(user,
                    Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize
                    });

                      return Content(list, "application/json");
         */


        }

        //   [HttpPost]
        public ActionResult SearchUser(int Area, int BGId, int mobile = 0)
        {


            var users = db.dbUser.Where(x => x.Area == Area && x.BGId == BGId).ToList();
            // var user = db.dbUser.Where(x => x.BGId == BGId).ToList();

            //  dd(users);
            if (mobile == 0)
                return View(users);
            else
            {

                var list = JsonConvert.SerializeObject(users.ToList(),
               Formatting.None,
               new JsonSerializerSettings()
               {
                   ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize
               });

                return Content(list, "application/json");
            }

            //    return Json(users, JsonRequestBehavior.AllowGet);

        }

        // GET: Reviews/Create
        public ActionResult AddReview()
        {
            //    ViewBag.UserId = new SelectList(db.dbUser, "Id", "UserName");
            return View();
        }


        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult AddReview([Bind(Include = "Id,UserId,FeedBack,writerId")] Review review, int mobile = 0)
        {

            string uId = User.Identity.GetUserId();
            var authUser = db.dbUser.FirstOrDefault(c => c.appUserId == uId);
            authUser.ReviewStatus = 0;
            db.Entry(authUser).State = EntityState.Modified;
          
            if (ModelState.IsValid)
            {
                review.writerId = authUser.Id;
                db.dbReview.Add(review);
                db.SaveChanges();
                return RedirectToAction("Search", "Home");
            }

            // ViewBag.UserId = new SelectList(db.dbUser, "Id", "UserName", review.UserId);
            return View(review);
        }
        public ActionResult SingleUseReviews(int id)
        {

            var review = db.dbReview.Where(c => c.UserId == id);
            /*      return Json(review.ToList(), JsonRequestBehavior.AllowGet);
            */
            var list = JsonConvert.SerializeObject(review.ToList(),
                     Formatting.None,
                     new JsonSerializerSettings()
                     {
                         ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize
                     });

                  return Content(list, "application/json"); 
        }
        public ActionResult About(int mobile = 0)
        {
            ViewBag.Message = "Your application description page.";

            //return View();
            if (mobile == 0)
                return View();
            else
                return View();
        }
        public ActionResult Search(int mobile = 0)
        {

            var bg = db.dbBloodGroup.ToList<BloodGroup>();
            var city = db.dbCity.ToList<City>();
            // SearchViewModel searchVm = new SearchViewModel();
            ViewBag.BGId = new SelectList(db.dbBloodGroup, "Id", "BloodGroupName");

            ViewBag.Area = new SelectList(db.dbCity, "Id", "CityName");
            //@model SaviourRedDrop.Models.SearchViewModel
            //return View();
            if (mobile == 0)
                return View();
            else
                return Json(new { bg = bg, city = city }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SignUp(int mobile = 0)
        {
            var bg = db.dbBloodGroup.ToList<BloodGroup>();
            var city = db.dbCity.ToList<City>();
            // SearchViewModel searchVm = new SearchViewModel();
            ViewBag.BGId = new SelectList(db.dbBloodGroup, "Id", "BloodGroupName");

            ViewBag.Area = new SelectList(db.dbCity, "Id", "CityName");

            //  ViewBag.City = city.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.CityName }).ToList();

            //ViewBag.BloodGroup = bg.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.BloodGroupName }).ToList();

            //       var allUsers = userManager.GetAll();
            //     return View();

            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult SignUp(SaviourRDUser user, int mobile = 0)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.dbUser.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("SignUp");
                }
                //return View(user);

                return View(user);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult FeedBack(int mobile = 0)
        {
            //var bg = db.dbReview.ToList<Review>();
            //ViewBag.UserId = new SelectList(db.dbReview, "Id", "FeedBack");
            ViewBag.Message = "Your application description page.";
            //return View();

            return View();
        }


        public ActionResult EditAccount(int mobile = 0)
        {
            var bg = db.dbBloodGroup.ToList<BloodGroup>();
            var city = db.dbCity.ToList<City>();
            // SearchViewModel searchVm = new SearchViewModel();
            ViewBag.BGId = new SelectList(db.dbBloodGroup, "Id", "BloodGroupName");

            ViewBag.Area = new SelectList(db.dbCity, "Id", "CityName");


            return View();
        }
        //ViewBag.Message = "Your application description page.";
        /* if (id == null)
             return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         SaviourRDUser product = db.dbUser.Find(id);
         if (product == null)
             return HttpNotFound();
         return View(product);

     }

     // POST: Admin/Edit/5
     [HttpPost]
     public ActionResult EditAccount(SaviourRDUser product)
     {
         try
         {
             if (ModelState.IsValid)
             {
                 db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             return View(product);
         }
         catch
         {
             return View();
         }

     }
     */
        //For Login
        public ActionResult login(int mobile = 0)
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(SaviourRDUser user, int mobile = 0)
        {

            SaviourRDUser usr = db.dbUser.Where(h => h.UserName == user.UserName && h.Password == user.Password).First();
            if (usr != null)
            {
                //Session["UserId"] = usr.Id.ToString();
                //Session["UserName"] = usr.UserName.ToString();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("login");
            }


            //      return View();
        }
        //public ActionResult loggedIn()
        //{
        //    if (Session["UserId"] != null)
        //    {
        //        return View();
        //    }
        //    return RedirectToAction("Login");
        //}
        //[HttpPost]
        //public ActionResult Login(string UserName, string password)
        //{
        //    //User user = new UsersHandler().GetUser(loginModel.LoginId, loginModel.Password);
        //    //User s = db.Users.Where(s => s.Email == loginModel.LoginId && s.Password == loginModel.Password).First();
        //    SaviourRDUser user = db.dbUser.Where(s => s.UserName == UserName && s.Password == password).Single();
        //    ActionResult temp = View();
        //    if (user != null)
        //    {
        //        //if(user.IsActive.Equals(false))
        //        //{
        //        //    return RedirectToAction("login", "users");
        //        //}
        //           Session.Add(WebUiHelper.CURRENT_USER, user);
        //        if (password == "asdfg")
        //        {
        //            HttpCookie setCookie = new HttpCookie("info");
        //            setCookie.Expires = DateTime.Now.AddDays(7);
        //                setCookie.Values.Add(WebUiHelper.LOGIN_ID, user.UserName);
        //                setCookie.Values.Add(WebUiHelper.PASSWORD, user.Password);
        //            Response.SetCookie(setCookie);
        //            temp = RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            temp = RedirectToAction("Index", "Home");
        //        }

        //    }
        //    else
        //    {
        //        temp = RedirectToAction("login", "users");
        //    }
        //    return temp;
        //}







        //public ActionResult Contact(int mobile = 0)
        //{
        //    ViewBag.Message = "Your contact page.";



        //        return View();
        //}


    

        public JsonResult AllList()
        {
            var bg = db.dbBloodGroup.ToList<BloodGroup>();
            var city = db.dbCity.ToList<City>();

            return Json(new { bg = bg, city = city }, JsonRequestBehavior.AllowGet);
        }

        public string test()
        {

            string uId = User.Identity.GetUserId();
            var authUser = db.dbUser.FirstOrDefault(c => c.appUserId == uId);
           

            //  var user = User.Identity.GetUserId();
            var user = User.Identity.Name;
            var test = "";
    //    var test =     db.dbCity.FirstOrDefault(c => c.CityName == s);
            return "1 : " + test.ToString();
        }
    }
}