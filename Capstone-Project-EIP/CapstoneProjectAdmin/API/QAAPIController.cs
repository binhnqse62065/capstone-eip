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
using System.Data.Entity;

namespace CapstoneProjectAdmin.API
{
    [RoutePrefix("api/QA")]
    public class QAAPIController : ApiController
    {
        private HmsEntities db = new HmsEntities();

        [Route("getAllQA/{eventId}")]
        [HttpGet]
        public IEnumerable<ViewModel.QAViewModel> GetQAs(int eventId)
        {
            QAApi qAApi = new QAApi();
            var listQa = qAApi.BaseService.Get(q => q.EventId == eventId).Select(q => new ViewModel.QAViewModel
            {
                Name = q.QAName,
                QAId = q.QAId
            });

            return listQa;
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

        [Route("UpdateQA")]
        [HttpPost]
        public HttpResponseMessage UpdateQA(QA qa)
        {
            var qaTmp = db.QAs.Find(qa.QAId);
            qaTmp.QAName = qa.QAName;
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
            using (DbContextTransaction trans = db.Database.BeginTransaction())
            {
                try
                {
                    var interactionDelete = db.Interactions.Where(e => e.QAId == qa.QAId);
                    foreach (var item in interactionDelete)
                    {
                        db.Interactions.Remove(item);
                    }
                    var questions = db.Questions.Where(e => e.QAId == qa.QAId);
                    foreach(var item in questions)
                    {
                        var comments = db.Comments.Where(e => e.QuestionId == item.QuestionId);
                        foreach (var quest in comments)
                        {
                            db.Comments.Remove(quest);
                        }
                        db.Questions.Remove(item);
                    }

                    
                    var qaDelete = db.QAs.Find(qa.QAId);
                    db.QAs.Remove(qaDelete);
                    db.SaveChanges();
                } catch (Exception ex)
                {
                    trans.Rollback();
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new JsonContent(new
                        {
                            success = false,
                            message = "Xóa dữ liệu thất bại",
                        })
                    };
                }
                trans.Commit();
            }
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    message = "Xóa dữ liệu thành công.",
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
                bool isAnswered = questionApi.CheckAnswered(question);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new JsonContent(new
                    {
                        success = true,
                        isAnswered = isAnswered
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
