using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Sdk;

namespace CapstoneProject_EIP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EventApi eventApi = new EventApi();
            var currEvent = eventApi.BaseService.GetEventById(1);
            if(currEvent.TemplateId == 1)
            {
                return View("Index", currEvent);
            }
            else
            {
                return View("Index_2", currEvent);
            }
            
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