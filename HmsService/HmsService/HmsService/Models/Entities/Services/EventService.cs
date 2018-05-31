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
    }
    public partial class EventService
    {
        public IQueryable<Event> GetAllEvent()
        {
            return this.Get(q => q.EventID == 1);
        }
    }
}
