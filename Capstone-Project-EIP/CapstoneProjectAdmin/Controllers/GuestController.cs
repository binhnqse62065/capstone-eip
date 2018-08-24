using CapstoneProjectAdmin.Models;
using CapstoneProjectAdmin.ViewModel;
using HmsService.Models.Entities;
using HmsService.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProjectAdmin.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class GuestController : Controller
    {
        // GET: Guest
        [Route("ManageGuest/{briefName}")]
        public ActionResult Index(string briefName)
        {
            EventApi eventApi = new EventApi();
            var eventTmp = eventApi.GetEventByBriefName(briefName);
            int id = eventTmp.EventID;
            ViewBag.EventId = id;
            ViewBag.BriefName = eventTmp.BriefName;
            return View();
        }

        public JsonResult GetGuest(int eventId)
        {
            try
            {
                GuestApi guestApi = new GuestApi();
                var listGuest = guestApi.GetAllGuestByEvent(eventId).Select(g => new GuestViewModel
                {
                    GuestName = g.GuestName,
                    GuestPhone = g.GuestPhone,
                    GuestEmail = g.GuestEmail,
                    EventId = g.EventId,
                    GuestId = g.GuestId,
                    IsCheckIn = g.IsCheckIn
                    
                }).ToList();
                return Json(new {
                    success = true,
                    data = listGuest
                }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new {
                    success = false
                });
            }
        }

        public JsonResult CheckInGuest(Guest guest)
        {
            try
            {
                GuestApi guestApi = new GuestApi();
                bool isCheckIn =  guestApi.CheckInGuest(guest);
                return Json(new {
                    success = false,
                    isCheckIn = isCheckIn
                });
            }
            catch
            {
                return Json(new {
                    success = false
                });
            }
        }

        [HttpPost]
        public JsonResult AddGuest(Guest guest)
        {
            try
            {
                GuestApi guestApi = new GuestApi();
                guestApi.AddGuest(guest);
                return Json(new {
                    success = true
                });
            }
            catch
            {
                return Json(new {
                    success = false
                });
            }
        }


        [HttpPost]
        public JsonResult UpdateGuest(Guest guest)
        {
            try
            {
                GuestApi guestApi = new GuestApi();
                guestApi.UpdateGuest(guest);
                return Json(new
                {
                    success = true
                });
            }
            catch
            {
                return Json(new
                {
                    success = false
                });
            }
        }

        [HttpPost]
        public JsonResult DeleteGuest(Guest guest)
        {
            try
            {
                GuestApi guestApi = new GuestApi();
                guestApi.DeleteGuest(guest);
                return Json(new
                {
                    success = true
                });
            }
            catch
            {
                return Json(new
                {
                    success = false
                });
            }
        }
    }
}