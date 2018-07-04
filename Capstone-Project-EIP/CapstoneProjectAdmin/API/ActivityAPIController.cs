using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HmsService.Models.Entities;
using CapstoneProjectAdmin.Models;
using CapstoneProjectAdmin.ViewModel;


namespace CapstoneProjectAdmin.API
{
    [RoutePrefix("api/activity")]
    public class ActivityAPIController : ApiController
    {
        private HmsEntities db = new HmsEntities();

        [Route("getAllActivity")]
        [HttpGet]
        public IEnumerable<ActivityViewModel> GetActivities()
        {
            var listActivity = db.Activities.Where(a => a.SessionId == 1).ToList().Select(a => new ActivityViewModel {
                ActivityID = a.ActivityID,
                Name = a.Name,
<<<<<<< HEAD
                StartTime = a.StartTime != null ? a.StartTime.Value.ToString("dd/MM/yyyy") : "",
                EndTime = a.EndTime != null ? a.EndTime.Value.ToString("dd/MM/yyyy"): "",
                Description = a.Description
=======
                StartTime = a.StartTime != null ? a.StartTime.Value.ToString("dd/mm/yyyy") : "",
                EndTime = a.EndTime != null ? a.EndTime.Value.ToString("dd/mm/yyyy"): "",
                Description = a.Description,
                SessionName = a.Session.Name
>>>>>>> fdb0cc0115ab822d8bdb9aa09ffae354fabcae50
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
