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
    public partial class SessionApi
    {
       public IEnumerable<SessionViewModel> GetSessionsByEventId(int eventId)
        {
            return this.BaseService.GetAllSessionsByEventId(eventId);
        }

        public SessionViewModel GetSessionById(int sessionId)
        {
            return this.BaseService.GetSessionById(sessionId);
        }

        public string GetSessionNameById(int sessionId)
        {
            return this.BaseService.FirstOrDefault(s => s.SessionID == sessionId).Name;
        }
    }
}
