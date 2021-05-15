using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myshop.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        Models.db db = new Models.db(); 
        public ActionResult MyProfile(int id)
        {
            var user = db.myusers.FirstOrDefault(t => t.UserId == id);
            return View(user);
        }
        public ActionResult EditProfile(Models.MyUser u1)
        {
            var user = db.myusers.FirstOrDefault(t => t.UserId == u1.UserId);
            user.Email = u1.Email;
            user.NameFamily = u1.NameFamily;
            db.SaveChanges();
            return View(user);
        }
    }
}