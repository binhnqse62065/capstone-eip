﻿using HmsService.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProjectAdmin.Controllers
{
    public class QAController : Controller
    {
        // GET: QA
        public ActionResult Index()
        {

            QAApi qAApi = new QAApi();
            var QAItem = qAApi.BaseService.GetQABySessionId(1);
            return View(QAItem);
        }
    }
}