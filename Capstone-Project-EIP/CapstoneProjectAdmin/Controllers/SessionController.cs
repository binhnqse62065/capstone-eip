﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Models.Entities;
using HmsService.Sdk;

namespace CapstoneProjectAdmin.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        private HmsEntities db = new HmsEntities();

        public ActionResult Index(int id)
        {
            ViewBag.EventId = id;
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

    }
}
