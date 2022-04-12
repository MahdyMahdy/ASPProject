using ASPProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ASPProject.Controllers
{
    public class AddItemsController : Controller
    {
        // GET: AddItems
        ProjectDBContext db = new ProjectDBContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection col)
        {
            if(ModelState.IsValid)
            {
                Item item = new Item();
                item.item_ID = 0;
                item.name = col["name"];
                item.nb_Of_Cap = int.Parse(col["nb_Of_Cap"]);
                item.price = double.Parse(col["price"]);
                item.isConfirmed = false;
                WebImage image = WebImage.GetImageFromRequest();
                item.image = image.GetBytes();
                item.insertion_Date = DateTime.Now.Date;
                item.expiration_Date = DateTime.Parse(col["expiration_Date"]);
                item.user_ID = SignInController.id;
                db.items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index", "Profile",new { @id=item.user_ID});
            }
            else
            {
                return View();
            }
        }
    }
}