using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HmsService.Sdk;
using HmsService.Models.Entities;
using CapstoneProjectAdmin.ViewModel;
using CapstoneProjectAdmin.Models;

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

        [Route("DeleteQuestion")]
        [HttpPost]
        public HttpResponseMessage DeleteQuestion(Question question)
        {
            var questionDelete = db.Questions.Find(question.QuestionId);
            var commentDeleteList = db.Comments.Where(e => e.QuestionId == question.QuestionId);
            foreach(var item in commentDeleteList)
            {
                db.Comments.Remove(item);
            }
            db.Questions.Remove(questionDelete);
            db.SaveChanges();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    message = "Remove successful!",
                })
            };
        }

        [Route("DeleteComment")]
        [HttpPost]
        public HttpResponseMessage DeleteComment(Comment comment)
        {
            var questionComment = db.Comments.Find(comment.CommentId);
            db.Comments.Remove(questionComment);
            db.SaveChanges();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    message = "Remove successful!",
                })
            };
        }

    }


}
