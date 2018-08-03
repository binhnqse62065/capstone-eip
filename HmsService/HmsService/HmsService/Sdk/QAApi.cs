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

        public IEnumerable<int> GetListQaIdByEventId(int eventId)
        {
            return this.BaseService.Get(q => q.EventId == eventId).Select(q => q.QAId);
        }

        public int GetTotalQuestionHaveComment(int eventId)
        {
            var listQa = this.BaseService.Get(q => q.EventId == eventId);
            int totalQuestionHaveComment = 0;
            foreach(var qa in listQa)
            {
                foreach(var question in qa.Questions)
                {
                    if(question.Comments.Count() > 0)
                    {
                        totalQuestionHaveComment += 1;
                    }
                }
            }
            return totalQuestionHaveComment;
        }
    }
}
