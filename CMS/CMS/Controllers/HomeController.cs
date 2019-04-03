using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // code used to start the generation of the db 
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                dbContext.Rooms.Add(new Room(1,"Mountain",2,200));
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}