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

    }
}
