using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HmsService.Sdk;
using HmsService.Models.Entities;
using CapstoneProjectAdmin.ViewModel;

namespace CapstoneProjectAdmin.API
{
    [RoutePrefix("api/QA")]
    public class QAAPIController : ApiController
    {
        private HmsEntities db = new HmsEntities();
        [Route("getAllQA")]
        [HttpGet]
        public IEnumerable<QAViewModel> GetQAs()
        {
            var listQA = db.QAs.Where(a => a.QAId==1).ToList().Select(a => new QAViewModel
            {
                QAId = a.QAId,
                Name = a.QAName
                
            });
            return listQA;
        }
    }
}
