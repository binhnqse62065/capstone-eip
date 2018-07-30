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
    }
}
