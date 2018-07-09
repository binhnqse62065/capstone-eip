using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models.Entities.Services
{
    public partial interface ITimelineService
    {
        IEnumerable<Timeline> GetTimelinesBySessionId(int sessionId);
    }
    public partial class TimelineService
    {
        public IEnumerable<Timeline> GetTimelinesBySessionId(int sessionId)
        {
            try
            {
                return this.Get(t => t.SessionId == sessionId);
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
