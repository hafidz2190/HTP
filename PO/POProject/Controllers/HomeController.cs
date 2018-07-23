using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POWebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (string.Compare(Session["Nama_Role"].ToString(),"BANK") == 0)
            {
                return RedirectToAction("Index", "Bank");
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

        public ActionResult FormOnline()
        {
            ViewBag.Message = "Form Online";

            return View();
        }
        public ActionResult FormElement()
        {
            ViewBag.Message = "FormElement";

            return View();
        }

        public ActionResult NotFoundPage()
        {
            return View();
        }
    }
}