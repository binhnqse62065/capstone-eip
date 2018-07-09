using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Models.Entities;
using HmsService.Sdk;

namespace CapstoneProjectAdmin.Controllers
{
    public class ActivityController : Controller
    {
        // GET: Activity
        private HmsEntities db = new HmsEntities();
        
        public ActionResult Index(int id)
        {
            ViewBag.EventId = id;
            SessionApi sessionApi = new SessionApi();
            var listSession = sessionApi.GetSessionsByEventId(id);
            return View(listSession);
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}