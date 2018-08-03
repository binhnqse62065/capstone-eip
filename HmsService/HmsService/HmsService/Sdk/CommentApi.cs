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
    public partial class CommentApi
    {
        public int GetTotalCommentByQuestionId(int questionId)
        {
            return this.BaseService.Get(c => c.QuestionId == questionId).Count();
        }

        public int GetTotalLikeByQuestionId(int questionId)
        {
            var listComment = this.BaseService.Get(c => c.QuestionId == questionId);
            int totalLike = 0;
            foreach(var comment in listComment)
            {
                totalLike += (int)comment.NumberOfLike;
            }
            return totalLike;
        }

        //public IEnumerable<CommentViewModel> GetAllComment
    }
}
