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

        Event GetEventById(int id);
    }
    public partial class EventService
    {
        public IQueryable<Event> GetAllEvent()
        {
            return this.Get(q => q.EventID == 1);
        }

        public Event GetEventById(int id)
        {
            return this.FirstOrDefault(e => e.EventID == id);
        }
    }
}
