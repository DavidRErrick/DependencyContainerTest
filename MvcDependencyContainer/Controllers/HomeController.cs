using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDependencyContainer.Models;

namespace MvcDependencyContainer.Controllers
{
    public class HomeController : Controller
    {
        readonly IAboutHelper myAboutHelper;

        public HomeController( IAboutHelper aboutHelper)
        {
            myAboutHelper = aboutHelper;
        }
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {

            ViewBag.Message = myAboutHelper.getMessage();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
