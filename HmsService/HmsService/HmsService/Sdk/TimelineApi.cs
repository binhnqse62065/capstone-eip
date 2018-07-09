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
    public partial class TimelineApi
    {
        public IEnumerable<Timeline> GetAllTimesBySessionId(int sessionId)
        {
            return this.BaseService.GetTimelinesBySessionId(sessionId);
        }
    }
}
