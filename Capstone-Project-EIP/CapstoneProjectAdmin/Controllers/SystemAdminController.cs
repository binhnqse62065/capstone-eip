using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneProjectAdmin.ViewModel;
using HmsService.Models.Entities;
using HmsService.Sdk;

namespace CapstoneProjectAdmin.Controllers
{
    public class SystemAdminController : Controller
    {
        // GET: SystemAdmin
        public ActionResult Index()
        {
            ViewBag.IsLayoutAdmin = true;
            return View();
        }

        public JsonResult GetAdmin()
        {
            try
            {
                AspNetUserApi aspNetUserApi = new AspNetUserApi();
                var listAdmin = aspNetUserApi.GetAllAdmin().Select(a => new UserViewModel
                {
                    UserName = a.UserName,
                    PasswordHash = a.PasswordHash,
                    Email = a.Email,
                    PhoneNumber = a.PhoneNumber,
                    Id = a.Id
                });
                return Json(new {
                    success = true,
                    data = listAdmin
                }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new {
                    success = false
                });
            }
        }

        public JsonResult DeleteUser(AspNetUser user)
        {
            try
            {
                AspNetUserApi aspNetUserApi = new AspNetUserApi();
                aspNetUserApi.DeleteUser(user);
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
        public JsonResult UpdateUser(AspNetUser user)
        {
            try
            {
                AspNetUserApi aspNetUserApi = new AspNetUserApi();
                aspNetUserApi.UpdateUser(user);
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