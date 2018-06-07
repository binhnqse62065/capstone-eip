using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Sdk;
using HmsService.Models.Entities.Services;

namespace CapstoneProjectAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EventApi eventApi = new EventApi();
            var cur = eventApi.BaseService.GetEventById(1);
            return View(cur);
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

        public ActionResult AdminView()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}