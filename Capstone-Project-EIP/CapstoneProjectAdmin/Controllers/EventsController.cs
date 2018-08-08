using HmsService.Models.Entities;
using HmsService.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProjectAdmin.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Index()
        {
            EventApi eventApi = new EventApi();
            var listAllEvent = eventApi.GetAllEvent();
            return View(listAllEvent);
        }

        public ActionResult Add()
        {
            return View();
        }

        public JsonResult AddNewEvent(Event eventAdd)
        {
            EventApi eventApi = new EventApi();
            eventAdd.IsActive = true;
            eventApi.BaseService.Create(eventAdd);
            return Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}