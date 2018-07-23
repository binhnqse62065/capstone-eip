using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Sdk;
using HmsService.Models.Entities.Services;
using HmsService.Models.Entities;

namespace CapstoneProjectAdmin.Controllers
{
    public class HomeController : Controller
    {
        private HmsEntities db = new HmsEntities();
        public ActionResult Index(int id)
        {
            EventApi eventApi = new EventApi();
            var cur = eventApi.BaseService.GetEventById(id);
            ViewBag.EventId = id;
            return View(cur);
        }

        public ActionResult Edit(int id)
        {
            EventApi eventApi = new EventApi();
            var currentEvent = eventApi.BaseService.GetEventById(id);
            ViewBag.EventId = id;
            return View(currentEvent);
        }

        [HttpPost]
        public ActionResult Update(Event eventUpdate)
        {
            var eventUp = db.Events.Find(1);
            eventUp.Name = eventUp.Name;
            try
            {
                db.SaveChanges();
            }
            catch(Exception e)
            {
                var err = e.Message;
            }
            
            return View("Index");
        }


        [HttpPost]
        public ActionResult DeleteEvent(Event eventDel)
        {
            var eventDelete = db.Events.Find(eventDel.EventID);
            eventDelete.IsActive = false;
            try
            {
                db.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception e)
            {
                var err = e.Message;
                return Json(new { success = false });
            }

            
        }

    }
}