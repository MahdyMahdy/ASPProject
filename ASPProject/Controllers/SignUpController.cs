using ASPProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ASPProject.Controllers
{
    public class SignUpController : Controller
    {
        ProjectDBContext db = new ProjectDBContext();
        String exist="";
        // GET: SignUp
        public ActionResult Index()
        {
            ViewBag.exist = exist;
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection col)
        {
            string username = col["username"];
            var userName = from n in db.logins
                           where n.username == username
                           select n;

            if(userName.Count()>0)
            {
                // exist = "This username is already exist!";

                ViewBag.ErrorMessage = "Username already Exist!";
                return View();
            }
            User user = new Models.User();
            user.first_Name = col["user.first_Name"];
            user.last_Name = col["user.last_Name"];
            user.email = col["user.email"];
            user.phone_Number = col["user.phone_Number"];
            db.users.Add(user);
            db.SaveChanges();
            int id = user.user_ID;
            Login login = new Login();
            login.username = username;
            login.password = col["pass"];
            login.user_ID = id;
            db.logins.Add(login);
            db.SaveChanges();
            Address adress = new Address();
            adress.governorat = col["gov"];
            adress.city = col["city"];
            adress.route = col["street"];
            adress.user_ID = id;
            db.addresses.Add(adress);
            db.SaveChanges();
            SignInController.id = id;
            return RedirectToAction("Index", "Profile",new { @id=user.user_ID});
        }
    }
}