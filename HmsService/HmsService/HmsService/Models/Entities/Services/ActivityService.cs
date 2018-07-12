using HmsService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models.Entities.Services
{
    public partial interface IActivityService
    {
        IEnumerable<Activity> GetActivitiesBySessionId(int sessionId);
    }
    public partial class ActivityService
    {
        public IEnumerable<Activity> GetActivitiesBySessionId(int sessionId)
        {
            try
            {
                return this.Get(a => a.SessionId == sessionId).ToList();
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
