using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HmsService.Models.Entities;
using HmsService.Sdk;
using CapstoneProjectAdmin.Models;
using CapstoneProjectAdmin.ViewModel;

namespace CapstoneProjectAdmin.API
{
    [RoutePrefix("api/timeline")]
    public class TimelineAPIController : ApiController
    {
        private HmsEntities db = new HmsEntities();
        [Route("getAllTimeline")]
        [HttpGet]
        public IEnumerable<TimelineViewModel> GetTimelines()
        {
            var listTimeline = db.Timelines.Where(a => a.SessionId == 1).ToList().Select(a => new TimelineViewModel
            {
                TimelineId = a.TimelineId,
                TimelineTitle = a.TimelineTitle,
                StartTime = a.StartTime != null ? a.StartTime.ToString() : "",
                TimelineDetail = a.TimelineDetail
            });
            return listTimeline;
        }

        [Route("addTimeline")]
        [HttpPost]
        public HttpResponseMessage AddTimeline(Timeline timeline)
        {
            try
            {
                db.Timelines.Add(timeline);
                db.SaveChanges();
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new JsonContent(new
                    {
                        success = true,
                        data = new
                        {
                            
                            
                        }
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

        [Route("UpdateTimeline")]
        [HttpPost]
        public HttpResponseMessage UpdateTimeline(Timeline timeline)
        {
            try
            {
                var curTimeline = db.Timelines.FirstOrDefault(a => a.TimelineId == timeline.TimelineId);
                curTimeline.TimelineTitle = timeline.TimelineTitle;
                curTimeline.TimelineDetail = timeline.TimelineDetail != null ? timeline.TimelineDetail : "";
                db.SaveChanges();
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new JsonContent(new
                    {
                        success = true,
                        data = new
                        {
                            TimelineTitle = timeline.TimelineTitle,
                            TimelineDetail = timeline.TimelineDetail,
                            StartTime = timeline.StartTime
                        }
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
                        success = false
                    })
                };
            }
        }

        [Route("DeleteTimeline")]
        [HttpPost]
        public HttpResponseMessage DeleteTimeline(Timeline timeline)
        {
            try
            {
                var curTimeline = db.Timelines.Find(timeline.TimelineId);
                db.Timelines.Remove(curTimeline);
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
