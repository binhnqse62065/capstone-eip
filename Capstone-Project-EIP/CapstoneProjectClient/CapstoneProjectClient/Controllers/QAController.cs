﻿using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Models.Entities.Services;
using HmsService.Sdk;
using HmsService.Models.Entities;

namespace CapstoneProjectClient.Controllers
{
    public class QAController : Controller
    {
        

        // GET: QA
        public ActionResult Index()
        {

            QAApi qAApi = new QAApi();
            var QAItem = qAApi.BaseService.GetQABySessionId(1);

            /*
             * jObject là message lấy từ người dùng( gọi API)
             * notify là hàm để thông báo message đến toàn bộ người dùng khác
             */
            //IEnumerable<Customer> customers = null;
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            if (context != null)
            {
                context.Clients.All.addNewMessageToPage("Binh", "Hello");
            }



            return View(QAItem);
        }


        public ActionResult PostNewQuestion(Question question)
        {
            QuestionApi questionApi = new QuestionApi();
            questionApi.BaseService.Create(question);
            return View("Index");
        }
    }
}