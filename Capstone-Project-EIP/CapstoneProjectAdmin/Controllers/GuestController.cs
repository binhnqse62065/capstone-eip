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
    public class GuestController : Controller
    {
        // GET: Guest

        public ActionResult Index(int id)
        {
            ViewBag.EventId = id;
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
                guestApi.CheckInGuest(guest);
                return Json(new {
                    success = false
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