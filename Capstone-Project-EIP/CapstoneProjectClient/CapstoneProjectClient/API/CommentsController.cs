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
using CapstoneProjectClient.Models;
using HmsService.Models.Entities;

namespace CapstoneProjectClient.API
{
    [RoutePrefix("api/comment")]
    public class CommentsController : ApiController
    {
        private HmsEntities db = new HmsEntities();


        // GET: api/Comments
        [Route("GetAllComment")]
        public IEnumerable<Comment> GetComments()
        {
            return db.Comments.ToList();
        }

        // GET: api/Comments/5
        [ResponseType(typeof(Comment))]
        public IHttpActionResult GetComment(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        // PUT: api/Comments/5
        [Route("PutComment")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComment(int id, Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comment.CommentId)
            {
                return BadRequest();
            }

            db.Entry(comment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/Comments
        [ResponseType(typeof(Comment))]
        public HttpResponseMessage PostComment(Comment comment)
        {
            comment.CreateTime = DateTime.Now;
            db.Comments.Add(comment);
            db.SaveChanges();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    commentId = comment.CommentId
                })
            };
        }

        // DELETE: api/Comments/5
        [ResponseType(typeof(Comment))]
        public IHttpActionResult DeleteComment(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }

            db.Comments.Remove(comment);
            db.SaveChanges();

            return Ok(comment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommentExists(int id)
        {
            return db.Comments.Count(e => e.CommentId == id) > 0;
        }

        [Route("LikeComment")]
        [HttpPost]
        public HttpResponseMessage LikeComment(Comment comment)
        {
            var currComment = db.Comments.Find(comment.CommentId);
            //if(isLike)
            //{
            //    currComment.NumberOfLike += 1;
            //}
            //else
            //{
            //    currComment.NumberOfLike -= 1;
            //}
            currComment.NumberOfLike += 1;
            db.SaveChanges();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    newNumberOfLike = currComment.NumberOfLike
                })
            };
        }

        [Route("DisLikeComment")]
        [HttpPost]
        public HttpResponseMessage DisLikeComment(Comment comment)
        {
            var currComment = db.Comments.Find(comment.CommentId);
            currComment.NumberOfLike -= 1;
            db.SaveChanges();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    newNumberOfLike = currComment.NumberOfLike
                })
            };
        }
    }
}