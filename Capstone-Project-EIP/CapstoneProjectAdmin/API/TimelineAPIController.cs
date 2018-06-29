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
        public IEnumerable<ActivityViewModel> GetActivities()
        {
            var listActivity = db.Activities.Where(a => a.SessionId == 1).ToList().Select(a => new ActivityViewModel
            {
                ActivityID = a.ActivityID,
                Name = a.Name,
                StartTime = a.StartTime != null ? a.StartTime.Value.ToString("dd/MM/yyyy") : "",
                EndTime = a.EndTime != null ? a.EndTime.Value.ToString("dd/MM/yyyy") : "",
                Description = a.Description
            });
            return listActivity;
        }
    }
}
