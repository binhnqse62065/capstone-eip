using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Sdk;

namespace CapstoneProjectAdmin.Controllers
{
    public class SponsorController : Controller
    {
        // GET: Sponsor
        public ActionResult Index(int id)
        {
            ViewBag.EventId = id;
            return View();
        }
    }
}