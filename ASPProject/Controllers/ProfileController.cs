using ASPProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPProject.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        ProjectDBContext db = new ProjectDBContext();
        public ActionResult Index(int id)
        {
            {
                var user = db.users.Single(model => model.user_ID == id);
                var address = db.addresses.Single(model => model.user_ID == id);
                ViewBag.user = user;
                ViewBag.address = address;
                var items = from item in db.items where item.user_ID == id select item;
                return View(items);
            }
        }

        public ActionResult Edit_Address(int add_ID,int user_ID)
        {
            if (SignInController.id == user_ID)
            {
                var address = db.addresses.Single(model => model.add_ID == add_ID);
                return View(address);
            }
            else
            {
                return RedirectToAction("Index", "Profile", new { @id = user_ID });
            }
        }

        [HttpPost]
        public ActionResult Edit_Address(int add_ID,Address address)
        {
            var old = db.addresses.Find(add_ID);
            db.Entry(old).CurrentValues.SetValues(address);
            db.SaveChanges();
            return RedirectToAction("Index", "Profile", new { @id = address.user_ID });
        }

        public ActionResult Edit_User(int user_ID)
        {
            if (SignInController.id == user_ID)
            {
                var user = db.users.Single(m => m.user_ID==user_ID);
                return View(user);
            }
            else
            {
                return RedirectToAction("Index", "Profile", new { @id = user_ID });
            }
        }
        [HttpPost]
        public ActionResult Edit_User(int user_ID,User user)
        {
            var old = db.users.Find(user_ID);
            db.Entry(old).CurrentValues.SetValues(user);
            db.SaveChanges();
            return RedirectToAction("Index","Profile",new { @id = user_ID });
        }
        [HttpPost]
        public ActionResult DeleteItem(int item_ID,int user_ID)
        {
            if(user_ID== SignInController.id)
            {
                var item = db.items.Single(m => m.item_ID==item_ID);
                db.items.Remove(item);
                db.SaveChanges();
            }
            return RedirectToAction("Index","Profile",new { @id = user_ID});
        }

        public ActionResult Logout()
        {
            if (SignInController.id > 0)
            {
                SignInController.id = -1;
            }
            return RedirectToAction("Index", "Home");
        }
    }
}