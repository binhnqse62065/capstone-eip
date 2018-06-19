using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Sdk;

namespace CapstoneProjectClient.Controllers
{
    public class LivestreamController : Controller
    {
        // GET: Livestream
        public ActionResult Index()
        {
            EventApi eventApi = new EventApi();
            var eventCurr = eventApi.BaseService.GetEventById(1);
            return View(eventCurr);
        }
    }
}