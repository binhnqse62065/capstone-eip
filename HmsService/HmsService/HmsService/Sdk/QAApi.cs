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
    public partial class QAApi
    {
        public QA GetQaById(int id)
        {
            return this.BaseService.GetQAById(id);
        }

        public IEnumerable<QAViewModel> GetQAByEventId(int eventId)
        {
            return this.BaseService.Get(q => q.EventId == eventId).Select(q => new QAViewModel {
                QAId = q.QAId,
                QAName = q.QAName,
                EventId = q.EventId
            });
        }
    }
}
