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
    public partial class EventApi
    {
        public IEnumerable<Event> GetAllEvent()
        {
            return this.BaseService.Get(e => e.IsActive == true);
        }

        public Event CheckLoginCode(int code)
        {
            return this.BaseService.CheckLoginCode(code);
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

    }
}
