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
        public ActionResult Index()
        {
            EventApi eventApi = new EventApi();
            var cur = eventApi.BaseService.GetEventById(1);
            var ac = cur.Sessions.FirstOrDefault().Activities.FirstOrDefault();
            return View(ac);
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}