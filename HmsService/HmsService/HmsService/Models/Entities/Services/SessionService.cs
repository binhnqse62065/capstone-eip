using HmsService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models.Entities.Services
{
    public partial interface ISessionService
    {
        IEnumerable<SessionViewModel> GetAllSessionsByEventId(int eventId);
    }
    public partial class SessionService
    {
        public IEnumerable<SessionViewModel> GetAllSessionsByEventId(int eventId)
        {
            try
            {
                return this.Get(s => s.EventId == eventId).Select(s => new SessionViewModel
                {
                    SessionID = s.SessionID,
                    Name = s.Name,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    Description = s.Description,
                    EventId = s.EventId
                });
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
