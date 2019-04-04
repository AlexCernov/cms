using CMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class PCMemberController : Controller
    {
        // GET: PCMember
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(IRegistrationViewModel rvm)
        {
            return View();
        }
    }
}