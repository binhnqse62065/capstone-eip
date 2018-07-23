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
    }
}
