using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using CapstoneProjectAdmin.ViewModel;
using CapstoneProjectClient.Models;
using HmsService.Models.Entities;
using HmsService.Sdk;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CapstoneProjectClient.API
{
    [RoutePrefix("api/question")]
    public class QuestionsController : ApiController
    {
        private HmsEntities db = new HmsEntities();

        [Route("getAllQuestionCommentByCreateTime")]
        [HttpPost]
        public HttpResponseMessage getAllQuestionCommentByCreateTime(Question qa)
        {
            QuestionApi questionApi = new QuestionApi();
            var listQas = questionApi.BaseService.GetQuestionsByQaId(qa.QAId).OrderByDescending(q => q.CreateTime).Select(v => new QuestionViewModel
            {
                QuestionId = v.QuestionId,
                QAId = v.QAId,
                QuestionContent = v.QuestionContent,
                Username = v.Username,
                CreateTime = v.CreateTime.Value.ToString("HH:mm"),
                NumberOfLike = v.NumberOfLike,
                NumberOfDisLike = v.NumberOfDislike,
                IsAnswer = v.IsAnswer != null ? v.IsAnswer : false,
                Comments = v.Comments.OrderByDescending(s => s.CreateTime).Select(s => new CommentsViewModel
                {
                    Username = s.Username,
                    CommentId = s.CommentId,
                    CommentContent = s.CommentContent,
                    QuestionId = s.QuestionId,
                    CreateTime = s.CreateTime.Value.ToString("HH:mm"),
                    NumberOfLike = s.NumberOfLike,
                    NumberOfDisLike = s.NumberOfDislike
                }),
            });
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    data = listQas
                })
            };
        }

        [Route("getAllQuestionCommentByLike")]
        [HttpPost]
        public HttpResponseMessage getAllQuestionCommentByLike(Question qa)
        {
            QuestionApi questionApi = new QuestionApi();
            var listQA = questionApi.BaseService.GetQuestionsByQaId(qa.QAId).OrderByDescending(s => s.NumberOfLike).Select(v => new QuestionViewModel
            {
                QuestionId = v.QuestionId,
                QAId = v.QAId,
                QuestionContent = v.QuestionContent,
                Username = v.Username,
                CreateTime = v.CreateTime.Value.ToString("hh:mm tt"),
                NumberOfLike = v.NumberOfLike,
                NumberOfDisLike = v.NumberOfDislike,
                IsAnswer = v.IsAnswer != null ? v.IsAnswer : false,
                Comments = v.Comments.OrderByDescending(s => s.CreateTime).Select(s => new CommentsViewModel
                {
                    Username = s.Username,
                    CommentId = s.CommentId,
                    CommentContent = s.CommentContent,
                    QuestionId = s.QuestionId,
                    CreateTime = s.CreateTime.Value.ToString("hh:mm tt"),
                    NumberOfLike = s.NumberOfLike,
                    NumberOfDisLike = s.NumberOfDislike
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

        [Route("getAllQuestion")]
        [HttpGet]
        // GET: api/Questions
        public IEnumerable<Question> GetQuestions()
        {
            return db.Questions.ToList();
        }

        // GET: api/Questions/5
        [ResponseType(typeof(Question))]
        public IHttpActionResult GetQuestion(int id)
        {
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        // PUT: api/Questions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestion(int id, Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != question.QuestionId)
            {
                return BadRequest();
            }

            db.Entry(question).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Questions
        //[ResponseType(typeof(Question))]
        [Route("AddQuestion")]
        [HttpPost]
        public HttpResponseMessage AddQuestion(Question question)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            question.IsAnswer = false;
            question.NumberOfDislike = 0;
            question.NumberOfLike = 0;
            question.CreateTime = DateTime.Now;
            QuestionApi questionApi = new QuestionApi();
            questionApi.AddNewQuestion(question);

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new {
                    success = true,
                    message = "Add successful!",
                    questionId = question.QuestionId
                })
            };
        }

        // DELETE: api/Questions/5
        [ResponseType(typeof(Question))]
        public IHttpActionResult DeleteQuestion(int id)
        {
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return NotFound();
            }

            db.Questions.Remove(question);
            db.SaveChanges();

            return Ok(question);
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionExists(int id)
        {
            return db.Questions.Count(e => e.QuestionId == id) > 0;
        }

        [Route("LikeQuestion")]
        [HttpPost]
        public HttpResponseMessage LikeQuestion(Question question)
        {
            var currQuestion = db.Questions.Find(question.QuestionId);
            currQuestion.NumberOfLike += 1;
            db.SaveChanges();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    newNumberOfLike = currQuestion.NumberOfLike
                })
            };
        }

        [Route("UnLikeQuestion")]
        [HttpPost]
        public HttpResponseMessage UnLikeQuestion(Question question)
        {
            var currQuestion = db.Questions.Find(question.QuestionId);
            currQuestion.NumberOfLike -= 1;
            db.SaveChanges();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    newNumberOfLike = currQuestion.NumberOfLike
                })
            };
        }

        [Route("DisLikeQuestion")]
        [HttpPost]
        public HttpResponseMessage DisLikeQuestion(Question question)
        {
            QuestionApi questionApi = new QuestionApi();
            int newNumberOfDislike =  questionApi.DisLikeQuestion(question);

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    newNumberOfLike = newNumberOfDislike
                })
            };
        }

        [Route("UnDisLikeQuestion")]
        [HttpPost]
        public HttpResponseMessage UnDisLikeQuestion(Question question)
        {
            QuestionApi questionApi = new QuestionApi();
            int newNumberOfDislike = questionApi.UnDisLikeQuestion(question);

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    newNumberOfLike = newNumberOfDislike
                })
            };
        }
    }
}