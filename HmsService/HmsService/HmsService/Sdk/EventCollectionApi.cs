using AutoMapper.QueryableExtensions;
using HmsService.Models;
using HmsService.Models.Entities;
using HmsService.ViewModels;
using SkyWeb.DatVM.Mvc;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using HmsService.Sdk;

namespace HmsService.Sdk
{
    public partial class EventCollectionApi
    {
        public EventCollection GetSpeakerByEventId(int eventId)
        {
            return this.BaseService.GetSpeakerCollectionByEventId(eventId);
        }

        public EventCollection GetSponsorByEventId(int eventId)
        {
            return this.BaseService.GetSponsorCollectionByEventId(eventId);
        }
        public EventCollection GetFileByEventId(int eventId)
        {
            return this.BaseService.GetFileCollectionByEventId(eventId);
        }

        public EventCollection GetEventCollectionByType(int eventId, int typeId)
        {
            return this.BaseService.FirstOrDefault(c => c.EventId == eventId && c.TypeId == typeId);
        }

       

        public EventCollection GetEventCollectionById(int eventCollectionId)
        {
            return this.BaseService.FirstOrDefault(c => c.EventCollectionID == eventCollectionId);
        }

        public IEnumerable<EventCollection> GetCollectionByEventId(int eventId)
        {
            return this.BaseService.Get(c => c.EventId == eventId && c.IsActive == true).ToList();
        }

        public int AddNewEventCollection(EventCollection eventCollection)
        {
            this.BaseService.Create(eventCollection);
            this.BaseService.Save();
            return eventCollection.EventCollectionID;
        }

        public void UpdateEventCollection(EventCollection eventCollection)
        {
            var curCollection = this.BaseService.FirstOrDefault(c => c.EventId == eventCollection.EventId && c.TypeId == eventCollection.TypeId);
            curCollection.Name = eventCollection.Name;
            curCollection.Description = eventCollection.Description;
            curCollection.IsActive = eventCollection.IsActive;
            this.BaseService.Save();
        }

        public void DeleteEventCollection(EventCollection eventCollection)
        {
            var curCollection = this.BaseService.FirstOrDefault(c => c.EventId == eventCollection.EventId && c.TypeId == eventCollection.TypeId);
            this.BaseService.Delete(curCollection);
            this.BaseService.Save();
        }
    }
}
