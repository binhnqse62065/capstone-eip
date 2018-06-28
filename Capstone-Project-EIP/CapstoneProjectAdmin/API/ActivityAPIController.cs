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
                StartTime = a.StartTime != null ? a.StartTime.Value.ToString("dd/mm/yyyy") : "",
                EndTime = a.EndTime != null ? a.EndTime.Value.ToString("dd/mm/yyyy"): "",
                Description = a.Description
            });
            return listActivity; 
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
    }
}
