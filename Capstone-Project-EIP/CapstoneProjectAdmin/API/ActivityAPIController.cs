using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HmsService.Models.Entities;
using CapstoneProjectAdmin.Models;
using CapstoneProjectAdmin.ViewModel;
using HmsService.Sdk;

namespace CapstoneProjectAdmin.API
{
    [RoutePrefix("api/activity")]
    public class ActivityAPIController : ApiController
    {
        private HmsEntities db = new HmsEntities();

        [Route("GetAllActivityBySessionId/{id}")]
        [HttpGet]
        public IEnumerable<ActivityViewModel> GetActivitiesBySessionId(int id)
        {
            ActivityApi activityApi = new ActivityApi();
            var listActivitys = activityApi.GetActivitiesBySessionId(id);
            var listActivity = listActivitys.Select(a => new ActivityViewModel {
                ActivityID = a.ActivityID,
                Name = a.Name,
                StartTime = a.StartTime != null ? a.StartTime.Value.ToString("dd/MM/yyyy hh:mm tt") : "",
                EndTime = a.EndTime != null ? a.EndTime.Value.ToString("dd/MM/yyyy hh:mm tt") : "",
                Description = a.Description,
                SessionName = a.Session.Name,
                //SpeakerName = a.ActivityItems.FirstOrDefault(e => e.ActivityId == a.ActivityID).CollectionItem.Name
            });
            return listActivity; 
        }

        [Route("AddActivity")]
        [HttpPost]
        public HttpResponseMessage AddActivity(Activity activity)
        {
            try
            {
                db.Activities.Add(activity);
                db.SaveChanges();
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new JsonContent(new
                    {
                        success = true,
                        data = new
                        {
                            Name = activity.Name,
                            Description = activity.Description,
                            StartTime = activity.StartTime,
                            EndTime = activity.EndTime
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

        [Route("UpdateActivity")]
        [HttpPost]
        public HttpResponseMessage UpdateActivity(Activity activity)
        {
            try
            {
                var curActivity = db.Activities.FirstOrDefault(a => a.ActivityID == activity.ActivityID);
                curActivity.Name = activity.Name;
                curActivity.Description = activity.Description!= null ? activity.Description : "";
                db.SaveChanges();
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new JsonContent(new
                    {
                        success = true,
                        data = new
                        {
                            Name = activity.Name,
                            StartTime = activity.StartTime,
                            EndTime = activity.EndTime,
                            Description = activity.Description
                        }
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

        [Route("DeleteActivity")]
        [HttpPost]
        public HttpResponseMessage DeleteActivity(Activity activity)
        {
            try
            {
                var curActivity = db.Activities.Find(activity.ActivityID);
                db.Activities.Remove(curActivity);
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
