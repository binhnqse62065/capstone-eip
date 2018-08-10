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
            var listActivity = listActivitys.Select(a => new ActivityViewModel
            {
                ActivityID = a.ActivityID,
                Name = a.Name,
                StartTime = a.StartTime != null ? a.StartTime.Value.ToString("dd/MM/yyyy hh:mm tt") : "",
                EndTime = a.EndTime != null ? a.EndTime.Value.ToString("dd/MM/yyyy hh:mm tt") : "",
                Description = a.Description,
                SpeakerName = a.ActivityItems.Where(e => e.ActivityId == a.ActivityID).Select(z => z.CollectionItem.Name)
            });
            return listActivity;
        }

        [Route("AddActivityItem")]
        [HttpPost]
        public HttpResponseMessage AddActivityItem(ActivityItem activityItem)
        {
            db.ActivityItems.Add(activityItem);
            db.SaveChanges();
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    message = "Add successful!",
                })
            };
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
                            ActivityID = activity.ActivityID,
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
                curActivity.Description = activity.Description != null ? activity.Description : "";
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


        [Route("DeleteActivityItem")]
        [HttpPost]
        public HttpResponseMessage DeleteActivityItem(ActivityItem activityItem)
        {
            var ListActivityItem = db.ActivityItems.Where(e => e.ActivityId == activityItem.ActivityId).Select(a => a.ActivityItemId).ToList();
            for (int i = 0; i < ListActivityItem.Count(); i++)
            {
                db.ActivityItems.Remove(db.ActivityItems.Find(ListActivityItem.ElementAt(i)));
            }
            db.SaveChanges();
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    message = "Remove successful!",
                })
            };
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
