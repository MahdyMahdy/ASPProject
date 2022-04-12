using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPProject.Models;

namespace ASPProject.Controllers
{ 
    public class AdminController : Controller
    {
        ProjectDBContext db = new ProjectDBContext();
        // GET: Admin
        public ActionResult Index()
        {
            var items = from item in db.items where item.isConfirmed ==false select item;
            return View(items);
        }
        [HttpPost]
        public ActionResult Confirmation(FormCollection coll)
            
        {
            int id = int.Parse(coll["id"]);
            string action = coll["submit"];
            var items = from item in db.items where item.isConfirmed == false select item;
            foreach ( var item in items)
            {
                if(item.item_ID==id)
                {
                    var old = db.items.Find(id);
                    if (action.Equals("confirm"))
                    { 
                        item.isConfirmed = true;
                        db.Entry(old).CurrentValues.SetValues(item);
                    }
                    else
                    {
                        db.items.Remove(old);
                    }
                   
                   

                }
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}