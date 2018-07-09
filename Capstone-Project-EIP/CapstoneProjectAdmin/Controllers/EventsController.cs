using HmsService.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProjectAdmin.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Index()
        {
            EventApi eventApi = new EventApi();
            var listAllEvent = eventApi.GetAllEvent();
            return View(listAllEvent);
        }
    }
}