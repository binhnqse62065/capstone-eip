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
    public partial class CommentApi
    {
        public void CreateComment(Comment comment)
        {
            this.BaseService.Create(comment);
            this.BaseService.Save();
        }

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

        public int UpdateNumberDisLike(int commentId, bool isDislike)
        {
            var commentTmp = this.BaseService.FirstOrDefault(c => c.CommentId == commentId);
            if(isDislike)
            {
                commentTmp.NumberOfDislike += 1;
            }
            else
            {
                commentTmp.NumberOfDislike -= 1;
            }
            this.BaseService.Save();
            return (int)commentTmp.NumberOfDislike;
        }

        //public IEnumerable<CommentViewModel> GetAllComment
    }
}
