using HmsService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models.Entities.Services
{
    public partial interface IEventService
    {
        IQueryable<Event> GetAllEvent();

        EventViewModel GetEventById(int id);

        Event CheckLoginCode(int code);
    }
    public partial class EventService
    {
        public IQueryable<Event> GetAllEvent()
        {
            return this.Get(q => q.EventID == 1);
        }

        public EventViewModel GetEventById(int id)
        {
            var currentEvent = this.FirstOrDefault(e => e.EventID == id);
            return new EventViewModel
            {
                EventID = currentEvent.EventID,
                Name = currentEvent.Name,
                EventDescription = currentEvent.EventDescription,
                Address = currentEvent.Address,
                StartTime = currentEvent.StartTime,
                CodeLogin = currentEvent.CodeLogin,
                EndTime = currentEvent.EndTime,
                TemplateId = currentEvent.TemplateId,
                ImageURL = currentEvent.ImageURL
            };
        }

        public Event CheckLoginCode(int code)
        {
            return this.FirstOrDefault(e => e.CodeLogin == code);
            
        }
    }
}
