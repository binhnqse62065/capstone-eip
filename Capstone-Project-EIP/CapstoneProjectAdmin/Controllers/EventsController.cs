using HmsService.Models;
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
            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            eventAdd.IsActive = true;
            eventAdd.IsLandingPage = false;
            eventAdd.BriefName = eventAdd.BriefName;
            bool isExistBriefName = eventApi.CheckBriedName(eventAdd.BriefName);
            if(!isExistBriefName)
            {
                int eventId = eventApi.AddNewEvent(eventAdd);
                EventCollection speakerCollection = new EventCollection
                {
                    EventId = eventId,
                    Name = "Danh sách diễn giả",
                    Description = "Chứa danh sách diễn giả của sự kiện",
                    TypeId = (int)MyEnums.CollectionType.Speaker,
                    IsActive = true,
                    IsImage = true
                };
                eventCollectionApi.AddNewEventCollection(speakerCollection);
                EventCollection sponsorCollection = new EventCollection
                {
                    EventId = eventId,
                    Name = "Danh sách nhà tài trợ",
                    Description = "Chứa danh sách nhà tài trợ của sự kiện",
                    TypeId = (int)MyEnums.CollectionType.Sponsor,
                    IsActive = true,
                    IsImage = true
                };
                eventCollectionApi.AddNewEventCollection(sponsorCollection);
                return Json(new
                {
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}