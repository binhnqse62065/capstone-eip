﻿using AutoMapper;
using CapstoneProjectAdmin.Models;
using CapstoneProjectAdmin.ViewModel;
using HmsService.Models.Entities;
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
                StartTime = s.StartTime.Value.ToString("dd/MM/yyyy"),
                EndTime = s.EndTime.Value.ToString("dd/MM/yyyy"),
                Description = s.Description,
                LivestreamUrl = s.LivestreamUrl
                
            });
            return session.ToList();
        }

        [Route("UpdateSession")]
        [HttpPost]
        public HttpResponseMessage UpdateSession(Session session)
        {
            try
            {
                var curSession = db.Sessions.Find(session.SessionID);
                curSession.Name = session.Name;
                curSession.Description = session.Description;
                curSession.StartTime = session.StartTime;
                curSession.EndTime = session.EndTime;
                curSession.LivestreamUrl = session.LivestreamUrl;
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


        [Route("AddSession")]
        [HttpPost]
        public HttpResponseMessage AddSession(Session session)
        {
            try
            {
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
