﻿using AutoMapper.QueryableExtensions;
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
    public partial class GuestApi
    {
        public IEnumerable<Guest> GetAllGuestByEvent(int eventId)
        {
            return this.BaseService.Get(g => g.EventId == eventId);
        }

        public void CheckInGuest(Guest guest)
        {
            var curGuest = this.BaseService.FirstOrDefault(g => g.GuestId == guest.GuestId);
            curGuest.IsCheckIn = true;
            this.BaseService.Save();
        }

        public void AddGuest(Guest guest)
        {
            guest.IsCheckIn = false;
            this.BaseService.Create(guest);
            this.BaseService.Save();
        }

        public void UpdateGuest(Guest guest)
        {
            var curGuest = this.BaseService.FirstOrDefault(g => g.GuestId == guest.GuestId);
            curGuest.GuestName = guest.GuestName;
            curGuest.GuestPhone = guest.GuestPhone;
            curGuest.GuestEmail = guest.GuestEmail;
            this.BaseService.Save();
        }

        public void DeleteGuest(Guest guest)
        {
            var curGuest = this.BaseService.FirstOrDefault(g => g.GuestId == guest.GuestId);
            this.BaseService.Delete(curGuest);
            this.BaseService.Save();
        }
    }
}
