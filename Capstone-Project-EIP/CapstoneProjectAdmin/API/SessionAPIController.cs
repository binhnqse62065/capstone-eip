using AutoMapper;
using CapstoneProjectAdmin.Models;
using CapstoneProjectAdmin.ViewModel;
using HmsService.Models.Entities;
using HmsService.Sdk;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CapstoneProjectAdmin.API
{
    [RoutePrefix("api/session")]
    public class SessionAPIController : ApiController
    {
        private HmsEntities db = new HmsEntities();

        [Route("getSessionsByEventId/{id}")]
        [HttpGet]
        public IEnumerable<SessionViewModel> GetSession(int id)
        {
            var session = db.Sessions.Where(s => s.EventId == id && s.IsActive == true).ToList().Select(s => new SessionViewModel {
                SessionID = s.SessionID,
                Name = s.Name,
                StartTime = s.StartTime.Value.ToString("dd/MM/yyyy HH:mm"),
                EndTime = s.EndTime.Value.ToString("dd/MM/yyyy HH:mm"),
                Description = s.Description,
                LivestreamUrl = s.LivestreamUrl,
                Address = s.Address
                
            });
            return session.ToList();
        }

        [Route("GetSessionById/{sessionId}")]
        [HttpGet]
        public SessionViewModel GetSessionById(int sessionId)
        {
            try
            {
                SessionApi sessionApi = new SessionApi();
                var session = sessionApi.BaseService.FirstOrDefault(s => s.SessionID == sessionId);
                var result = new SessionViewModel
                {
                    SessionID = session.SessionID,
                    StartTime = session.StartTime.Value.ToString("dd/MM/yyyy"),
                    EndTime = session.EndTime.Value.ToString("dd/MM/yyyy")

                };
                return result;
            }
            catch
            {
                return null;
            }
        }

        [Route("UpdateSession")]
        [HttpPost]
        public HttpResponseMessage UpdateSession(EditorSessionModel request)
        {
            try
            {

                var session = request.Session;
                var startTimeStr = request.StartTimeStr.Trim();
                var endTimeStr = request.EndTimeStr.Trim();
                DateTime startTime = DateTime.ParseExact(startTimeStr, "dd/MM/yyyy HH:mm", null);
                DateTime endTime = DateTime.ParseExact(endTimeStr, "dd/MM/yyyy HH:mm", null);
                session.StartTime = startTime;
                session.EndTime = endTime;

                var curSession = db.Sessions.Find(session.SessionID);
                curSession.Name = session.Name;
                curSession.Address = session.Address;
                curSession.Description = session.Description;
                curSession.StartTime = session.StartTime;
                curSession.EndTime = session.EndTime;
                curSession.LivestreamUrl = session.LivestreamUrl != null ? session.LivestreamUrl : "";
                db.SaveChanges();
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new JsonContent(new
                    {
                        success = true
                    })
                };

            }
            catch(Exception e)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new JsonContent(new
                    {
                        success = false
                    })
                };
            }

        }

        

        [Route("DeleteSession")]
        [HttpPost]
        public HttpResponseMessage DeleteSession(Session session)
        {
            try
            {
                var curSession = db.Sessions.Find(session.SessionID);
                curSession.IsActive = false;
                
                db.SaveChanges();
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new JsonContent(new
                    {
                        success = true
                    })
                };

            }
            catch (Exception e)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new JsonContent(new
                    {
                        success = false,
                        data = e.Message
                    })
                };
            }

        }

        public class EditorSessionModel
        {
            public Session Session { get; set; }
            public string StartTimeStr { get; set; }
            public string EndTimeStr { get; set; }
        }

        [Route("AddSession")]
        [HttpPost]
        public HttpResponseMessage AddSession(EditorSessionModel request)
        {
            try
            {
                var session = request.Session;
                var startTimeStr = request.StartTimeStr.Trim();
                var endTimeStr = request.EndTimeStr.Trim();

                DateTime startTime = DateTime.ParseExact(startTimeStr, "dd/MM/yyyy HH:mm", null);
                DateTime endTime = DateTime.ParseExact(endTimeStr, "dd/MM/yyyy HH:mm", null);
                session.StartTime = startTime;
                session.EndTime = endTime;


                if (session.LivestreamUrl == null)
                {
                    session.LivestreamUrl = "";
                }
                session.IsActive = true;
                db.Sessions.Add(session);
                db.SaveChanges();
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new JsonContent(new
                    {
                        success = true
                    })
                };

            }
            catch (Exception e)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new JsonContent(new
                    {
                        success = false,
                        data = e.Message
                    })
                };
            }

        }
    }


}
