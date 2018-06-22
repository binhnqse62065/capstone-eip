using CapstoneProjectAdmin.Models;
using HmsService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CapstoneProjectAdmin.API
{
    [RoutePrefix("api/session")]
    public class SessionController : ApiController
    {
        private HmsEntities db = new HmsEntities();

        [Route("getAllSession")]
        [HttpGet]
        public HttpResponseMessage GetQuestions()
        {
            var session = db.Sessions.FirstOrDefault();
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    message = "Add successful!",
                    data = session
                })
            };
        }
    }
}
