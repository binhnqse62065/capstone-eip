using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Sdk;
using HmsService.Models.Entities.Services;
using HmsService.Models.Entities;
using CapstoneProjectAdmin.ViewModel;
using CapstoneProjectAdmin.Models;

namespace CapstoneProjectAdmin.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class HomeController : Controller
    {
        private HmsEntities db = new HmsEntities();

        [Route("ManageHome/{briefName}")]
        public ActionResult Index(string briefName)
        {
            EventApi eventApi = new EventApi();
            var currentEvent = eventApi.GetEventByBriefName(briefName);
            ViewBag.BriefName = currentEvent.BriefName;
            ViewBag.EventId = currentEvent.EventID;
            HmsService.ViewModels.EventViewModel eventTmp = new HmsService.ViewModels.EventViewModel
            {
                EventID = currentEvent.EventID,
                Name = currentEvent.Name,
                EventDescription = currentEvent.EventDescription,
                Address = currentEvent.Address,
                StartTime = currentEvent.StartTime,
                CodeLogin = currentEvent.CodeLogin,
                EndTime = currentEvent.EndTime,
                ImageURL = currentEvent.ImageURL,
                BriefName = currentEvent.BriefName,
                Longitude = currentEvent.Longitude,
                Latitude = currentEvent.Latitude,
                IsLandingPage = currentEvent.IsLandingPage
                
            };
            return View(eventTmp);
        }

        [Route("Edit/{briefName}")]
        public ActionResult Edit(string briefName)
        {
            EventApi eventApi = new EventApi();
            var currentEvent = eventApi.GetEventByBriefName(briefName);
            ViewBag.EventId = currentEvent.EventID;
            ViewBag.BriefName = currentEvent.BriefName;
            HmsService.ViewModels.EventViewModel eventTmp = new HmsService.ViewModels.EventViewModel
            {
                EventID = currentEvent.EventID,
                Name = currentEvent.Name,
                EventDescription = currentEvent.EventDescription,
                Address = currentEvent.Address,
                StartTime = currentEvent.StartTime,
                CodeLogin = currentEvent.CodeLogin,
                EndTime = currentEvent.EndTime,
                ImageURL = currentEvent.ImageURL,
                BriefName = currentEvent.BriefName,
                Longitude = currentEvent.Longitude,
                Latitude = currentEvent.Latitude,
                IsLandingPage = currentEvent.IsLandingPage

            };
            return View(eventTmp);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Event eventUpdate)
        {
            try
            {
                EventApi eventApi = new EventApi();
                bool isBriefNameExist = eventApi.CheckBriefNameExistUpdate(eventUpdate.EventID, eventUpdate.BriefName);
                bool isCodeLoginExist = eventApi.CheckCodeLoginExistUpdate(eventUpdate.EventID, (int)eventUpdate.CodeLogin);
                if(isBriefNameExist && isBriefNameExist)
                {

                    return Json(new
                    {
                        success = false,
                        isBriefNameExist = true,
                        isCodeLoginExist = true
                    });
                }
                else if(isBriefNameExist)
                {
                    return Json(new
                    {
                        success = false,
                        isBriefNameExist = true
                    });
                }
                else if (isCodeLoginExist)
                {
                    return Json(new
                    {
                        success = false,
                        isCodeLoginExist = true
                    });
                }
                else
                {
                    string eventBriefName = eventApi.UpdateEvent(eventUpdate);
                    return Json(new { success = true, briefName = eventBriefName });
                }
                
                
            }
            catch(Exception e)
            {
                return Json(new { success = false });
            }
            
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


        
        public ActionResult SetEventToLandingPage(int id)
        {
            EventApi eventApi = new EventApi();
            eventApi.SetEventToLandingPage(id);
            var eventTmp = eventApi.BaseService.GetEventById(id);
            ViewBag.EventId = id;
            ViewBag.BriefName = eventTmp.BriefName;
            return View("Index", eventTmp);


        }

    }
}