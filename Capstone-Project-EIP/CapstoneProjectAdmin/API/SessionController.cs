using AutoMapper;
using CapstoneProjectAdmin.Models;
using CapstoneProjectAdmin.ViewModel;
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
        public IEnumerable<SessionViewModel> GetQuestions()
        {
            var session = db.Sessions.Where(s => s.EventId == 1).ToList().Select(s => new SessionViewModel {
                SessionID = s.SessionID,
                Name = s.Name,
                StartTime = s.StartTime,
                EndTime = s.EndTime
                
            });
            return session.ToList();
            //return new HttpResponseMessage()
            //{
            //    StatusCode = HttpStatusCode.OK,
            //    Content = new JsonContent(new
            //    {
            //        success = true,
            //        message = "Add successful!",
            //        data = session
            //    })
            //};

        }
    }
}
