using HmsService.Models.Entities;
using HmsService.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProjectAdmin.Controllers
{
    public class InteractionController : Controller
    {
        // GET: Interaction
        private HmsEntities db = new HmsEntities();
        public ActionResult Index()
        {
            EventApi eventApi = new EventApi();
            var cur = eventApi.BaseService.GetEventById(1);
            return View(cur);
        }
    }
}