using HmsService.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProjectAdmin.Controllers
{
    public class TimelineController : Controller
    {
        // GET: Timeline
        public ActionResult Index(int id)
        {
            ViewBag.EventId = id;
            SessionApi sessionApi = new SessionApi();
            var listSession = sessionApi.GetSessionsByEventId(id);
            return View(listSession);
        }
    }
}