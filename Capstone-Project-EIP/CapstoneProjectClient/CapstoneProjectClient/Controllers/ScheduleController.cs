using HmsService.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProjectClient.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Index()
        {
            EventApi eventApi = new EventApi();
            var currEvent = eventApi.BaseService.GetEventById(1);
            return View(currEvent);

        }
    }
}