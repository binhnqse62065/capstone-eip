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

        SessionViewModel GetSessionById(int sessionId);
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
                    EventId = s.EventId,
                    EventName = s.Event.Name,
                    Address = s.Address
                });
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public SessionViewModel GetSessionById(int sessionId)
        {
            try
            {
                var curSession = this.FirstOrDefault(s => s.SessionID == sessionId);
                return new SessionViewModel
                {
                    SessionID = curSession.SessionID,
                    EventId = curSession.EventId,
                    LivestreamUrl = curSession.LivestreamUrl
                };
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
