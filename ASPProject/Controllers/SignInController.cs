using ASPProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPProject.Controllers
{
    public class SignInController : Controller
    {
        public static int id = -1;
        ProjectDBContext db = new ProjectDBContext();
        // GET: SignIn
        public ActionResult Index()
        {   
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection col)
        {
            string username = col["username"];
            var logins = from login in db.logins where login.username == username select login;
            if(logins.Count()==0)
            {
                return View();
            }
            string pass = col["pass"];
            if(logins.First().password==pass)
            {
                id = logins.First().user_ID;
                return RedirectToAction("Index", "Profile",new { @id=id});
            }
            return View();
        }
    }
}