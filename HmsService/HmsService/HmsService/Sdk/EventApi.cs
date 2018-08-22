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
using System;

namespace HmsService.Sdk
{
    public partial class EventApi
    {
        public IEnumerable<Event> GetAllEvent()
        {
            return this.BaseService.Get(e => e.IsActive == true);
        }

        public Event CheckEventCode(int code)
        {
            return this.BaseService.CheckLoginCode(code);
        }

        public bool CheckBriedName(string briefName)
        {
            return this.BaseService.FirstOrDefault(e => e.BriefName == briefName) != null ? true : false;
        }

        public Event GetEventByBriefName(string briefName)
        {
            return this.BaseService.FirstOrDefault(e => e.BriefName == briefName);
        }

        public bool UpdateEvent(Event eventUpdate)
        {
            try
            {
                var eventTmp = this.BaseService.FirstOrDefault(e => e.EventID == eventUpdate.EventID);
                eventTmp.Name = eventUpdate.Name != null ? eventUpdate.Name : eventTmp.Name;
                eventTmp.EventDescription = eventUpdate.EventDescription != null ? eventUpdate.EventDescription : eventTmp.EventDescription;
                eventTmp.Address = eventUpdate.Address != null ? eventUpdate.Address : eventTmp.Address;
                eventTmp.CodeLogin = eventUpdate.CodeLogin != null ? eventUpdate.CodeLogin : eventTmp.CodeLogin;
                eventTmp.StartTime = eventUpdate.StartTime != null ? eventUpdate.StartTime : eventTmp.StartTime;
                eventTmp.EndTime = eventUpdate.EndTime != null ? eventUpdate.EndTime : eventTmp.EndTime;
                eventTmp.ImageURL = eventUpdate.ImageURL != null ? eventUpdate.ImageURL : eventTmp.ImageURL;
                eventTmp.Longitude = eventUpdate.Longitude != null ? eventUpdate.Longitude : eventTmp.Longitude;
                eventTmp.Latitude = eventUpdate.Latitude != null ? eventUpdate.Latitude : eventTmp.Latitude;
                this.BaseService.Save();
                return true;
            }
            catch(System.Exception e)
            {
                return false;
            }
        }

        public string GetEventNameById(int eventId)
        {
            return this.BaseService.FirstOrDefault(e => e.EventID == eventId).Name;
        }

        public Event GetEventById(int eventId)
        {
            return this.BaseService.FirstOrDefault(e => e.EventID == eventId);
        }

        public void SetEventToLandingPage(int eventId)
        {
            var eventTmp = this.BaseService.FirstOrDefault(e => e.EventID == eventId);
            var listAllEvent = this.BaseService.Get();
            foreach(var tmp in listAllEvent)
            {
                tmp.IsLandingPage = false;
            }
            eventTmp.IsLandingPage = true;
            this.BaseService.Save();
        }

        public IEnumerable<EventViewModel> GetRunningAndUpCommingEvent()
        {
            var today = DateTime.Today;
            return this.BaseService.Get(e => e.IsActive == true && (e.StartTime > today || (e.EndTime >= today && e.StartTime <= today) )).ProjectTo<EventViewModel>(this.AutoMapperConfig);
        }

        public int AddNewEvent(Event eventAdd)
        {
            this.BaseService.Create(eventAdd);
            return eventAdd.EventID;
        }
    }
}
