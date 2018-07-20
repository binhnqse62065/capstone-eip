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
    [RoutePrefix("api/home")]

    public class HomeController : ApiController
    {
        private HmsEntities db = new HmsEntities();

        [Route("EditHome")]
        [HttpPost]
        public HttpResponseMessage EditHome(Event eventOject)
        {
            var eventUpdate = db.Events.Find(eventOject.EventID);
            eventUpdate.Name = eventOject.Name;
            eventUpdate.CodeLogin = eventOject.CodeLogin;
            eventUpdate.Address = eventOject.Address;
            eventUpdate.EventDescription = eventOject.EventDescription;
            eventUpdate.StartTime = eventOject.StartTime;
            eventUpdate.EndTime = eventOject.EndTime;
            eventUpdate.TemplateId = eventOject.TemplateId;
            eventUpdate.ImageURL = eventOject.ImageURL;
            db.SaveChanges();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    data = new
                    {
                        Name = eventUpdate.Name,
                        Code = eventUpdate.CodeLogin,
                        Address = eventUpdate.Address,
                        Description = eventUpdate.EventDescription,
                        Template = eventUpdate.TemplateId,
                        Image = eventUpdate.ImageURL,
                        StartTime = eventUpdate.StartTime.ToString(),
                        EndTime = eventUpdate.EndTime.ToString()
                    },
                    message = "Cập nhật thông tin thành công!"
                })
            };

        }
    }
}