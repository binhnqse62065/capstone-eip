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
using HmsService.ViewModels;

namespace CapstoneProjectAdmin.API
{
    [RoutePrefix("api/QA")]
    public class QAAPIController : ApiController
    {
        private HmsEntities db = new HmsEntities();

        [Route("getAllQA/{eventId}")]
        [HttpGet]
        public IEnumerable<QA> GetQAs(int eventId)
        {
            var listQA = db.QAs.Where(a => a.EventId == eventId).ToList();
            return listQA;
        }

        [Route("getAllQuestionComment")]
        [HttpPost]
        public HttpResponseMessage getAllQuestionComment(Question qa)
        {
            QuestionApi questionApi = new QuestionApi();
            //var listQa = questionApi.GetQuestionsByQaId((int)qa.QAId);
            var listQA = questionApi.GetQuestionsByQaId((int)qa.QAId).OrderByDescending(s => s.CreateTime).Select(v => new ViewModel.QuestionViewModel
            {
                QuestionId = v.QuestionId,
                QAId = v.QAId,
                QuestionContent = v.QuestionContent,
                Username = v.Username,
                CreateTime = v.CreateTime.Value.ToString("hh:mm tt"),
                NumberOfLike = v.NumberOfLike,
                IsAnswered = (bool)v.IsAnswer,
                Comments = v.Comments.OrderByDescending(s => s.CreateTime).Select(s => new CommentsViewModel
                {
                    Username = s.Username,
                    CommentId = s.CommentId,
                    CommentContent = s.CommentContent,
                    QuestionId = s.QuestionId,
                    CreateTime = s.CreateTime.Value.ToString("hh:mm tt"),
                    NumberOfLike = s.NumberOfLike
                }),
            });
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    data = listQA
                })
            };
        }

        [Route("DeleteQuestion")]
        [HttpPost]
        public HttpResponseMessage DeleteQuestion(Question question)
        {
            var questionDelete = db.Questions.Find(question.QuestionId);
            var commentDeleteList = db.Comments.Where(e => e.QuestionId == question.QuestionId);
            foreach (var item in commentDeleteList)
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

        [Route("AddQA")]
        [HttpPost]
        public HttpResponseMessage AddQA(QA qa)
        {
            db.QAs.Add(qa);
            db.SaveChanges();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    message = "Add successful!",
                })
            };
        }

        [Route("DeleteQA")]
        [HttpPost]
        public HttpResponseMessage DeleteQA(QA qa)
        {
            var interactionDelete = db.Interactions.Where(e => e.QAId == qa.QAId);
            foreach (var item in interactionDelete)
            {
                db.Interactions.Remove(item);
            }
            var qaDelete = db.QAs.Find(qa.QAId);
            db.QAs.Remove(qaDelete);
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


        [Route("CheckAnsweredQuestion")]
        [HttpPost]
        public HttpResponseMessage CheckAnsweredQuestion(Question question)
        {
            try
            {
                QuestionApi questionApi = new QuestionApi();
                questionApi.CheckAnswered(question);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new JsonContent(new
                    {
                        success = true

                    })
                };
            }
            catch
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new JsonContent(new
                    {
                        success = false

                    })
                };
            }
        }
    }
}
