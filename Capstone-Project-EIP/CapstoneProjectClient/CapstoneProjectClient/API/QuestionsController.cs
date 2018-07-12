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
using CapstoneProjectClient.Models;
using HmsService.Models.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CapstoneProjectClient.API
{
    [RoutePrefix("api/question")]
    public class QuestionsController : ApiController
    {
        private HmsEntities db = new HmsEntities();

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
        public HttpResponseMessage PostQuestion(Question question)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            question.CreateTime = DateTime.Now;
            db.Questions.Add(question);
            db.SaveChanges();

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

        [Route("DisLikeQuestion")]
        [HttpPost]
        public HttpResponseMessage DisLikeQuestion(Question question)
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
    }
}