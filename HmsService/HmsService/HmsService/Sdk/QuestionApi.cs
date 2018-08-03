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
    public partial class QuestionApi
    {
        public int DisLikeQuestion(Question question)
        {
            try
            {
                var currQuestion = this.BaseService.FirstOrDefault(q => q.QuestionId == question.QuestionId);
                currQuestion.NumberOfDislike += 1;
                this.BaseService.Save();
                return (int)currQuestion.NumberOfDislike;
            }
            catch(System.Exception e)
            {
                return 0;
            }
            
        }

        public int UnDisLikeQuestion(Question question)
        {
            try
            {
                var currQuestion = this.BaseService.FirstOrDefault(q => q.QuestionId == question.QuestionId);
                currQuestion.NumberOfDislike -= 1;
                this.BaseService.Save();
                return (int)currQuestion.NumberOfDislike;
            }
            catch (System.Exception e)
            {
                return 0;
            }

        }

        public IEnumerable<Question> GetQuestionsByQaId(int qaId)
        {
            return this.BaseService.GetQuestionsByQaId(qaId);
        }

        public void CheckAnswered(Question question)
        {
            var tmpQuestion = this.BaseService.FirstOrDefault(q => q.QuestionId == question.QuestionId);
            tmpQuestion.IsAnswer = true;
            this.BaseService.Save();
        }

        public int GetNumberQuestionByQaId(int qaId)
        {
            return this.BaseService.Get(q => q.QAId == qaId).Count();
        }

        public IEnumerable<int> GetListQuestionIdByQaId(int qaId)
        {
            return this.BaseService.Get(q => q.QAId == qaId).Select(q => q.QuestionId);
        }

        public int GetTotalLikeQuestionByQaId(int qaId)
        {
            int total = 0;
            var listQuestion = this.BaseService.Get(q => q.QAId == qaId);
            foreach(var question in listQuestion)
            {
                total += (int)question.NumberOfLike;
            }
            return total;
        }

        public Question GetQuestionById(int questionId)
        {
            return this.BaseService.FirstOrDefault(q => q.QuestionId == questionId);
          
        }
    }
}
