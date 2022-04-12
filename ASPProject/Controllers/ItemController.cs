using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPProject.Models;
using System.Data.Entity;

namespace ASPProject.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        ProjectDBContext db = new ProjectDBContext();
        public ActionResult Index()
        {
            var items = from item in db.items where item.isConfirmed == true where item.expiration_Date > DateTime.Now  select item;
            items = items.OrderBy(item=>item.name).ThenBy(item => item.price).ThenByDescending(item => item.nb_Of_Cap);
            return View(items);
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string search = collection["search"];
            var items = from item in db.items where item.name.Contains(search) where item.expiration_Date > DateTime.Now   select item ;
            items = items.OrderBy(item => item.name).ThenBy(item => item.price).ThenByDescending(item => item.nb_Of_Cap);

            return View(items);
        }
       
    }
}