using HmsService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HmsService.Models;

namespace HmsService.Models.Entities.Services
{
    public partial interface IEventCollectionService
    {
        EventCollection GetSpeakerCollectionByEventId(int eventId);
        EventCollection GetSponsorCollectionByEventId(int eventId);
    }
    public partial class EventCollectionService
    {
        public EventCollection GetSpeakerCollectionByEventId(int eventId)
        {
            try
            {
                
                return this.FirstOrDefault(s => s.EventId == eventId && s.TypeId == (int)MyEnums.CollectionType.Speaker);
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public EventCollection GetSponsorCollectionByEventId(int eventId)
        {
            try
            {

                return this.FirstOrDefault(s => s.EventId == eventId && s.TypeId == (int)MyEnums.CollectionType.Sponsor);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
