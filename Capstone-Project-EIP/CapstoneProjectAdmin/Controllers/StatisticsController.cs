using CapstoneProjectAdmin.ViewModel;
using HmsService.Models.Entities;
using HmsService.Sdk;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProjectAdmin.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        public ActionResult Index(int id)
        {
            ViewBag.EventId = id;
            try
            {
                /*Lấy tổng số người tham gia của event này*/
                GuestApi guestApi = new GuestApi();
                QuestionApi questionApi = new QuestionApi();
                QAApi qAApi = new QAApi();
                CommentApi commentApi = new CommentApi();
                VotingApi votingApi = new VotingApi();
                VotingOptionApi votingOptionApi = new VotingOptionApi();


                var totalGuestArrived = guestApi.GetAllGuestArrivedOfEvent(id).Count();
                ViewBag.TotalGuestArrived = totalGuestArrived;
                var totalGuestRegister = guestApi.GetAllGuestByEvent(id).Count();
                ViewBag.TotalGuest = totalGuestRegister;

                /*Lấy tổng số câu hỏi*/
                
                var listQaId = qAApi.GetListQaIdByEventId(id);
                int totalQuestion = 0;
                int totalQuestionLike = 0;
                foreach(var qaId in listQaId)
                {
                    totalQuestion += questionApi.GetNumberQuestionByQaId(qaId);
                    totalQuestionLike += questionApi.GetTotalLikeQuestionByQaId(qaId);
                }
                ViewBag.TotalQuestionLike = totalQuestionLike;
                ViewBag.TotalQuestion = totalQuestion;
                /*Lấy số câu hỏi có comment*/
                int totalQuestionHaveComment = qAApi.GetTotalQuestionHaveComment(id);
                ViewBag.TotalQuestionHaveComment = totalQuestionHaveComment;

                /*Lấy tổng số bình luận*/
                
                int totalComment = 0;
                int totalCommentLike = 0;
                List<CountCommentViewModel> listQuestionComment = new List<CountCommentViewModel>();
                
                foreach(var qaId in listQaId)
                {
                    var listQuestionIdTmp = questionApi.GetListQuestionIdByQaId(qaId);
                    foreach(var questionId in listQuestionIdTmp)
                    {
                        int totalCommentTmp = commentApi.GetTotalCommentByQuestionId(questionId);
                        CountCommentViewModel numberOfComment = new CountCommentViewModel
                        {
                            QuestionId = questionId,
                            NumberOfComment = totalCommentTmp
                        };
                        listQuestionComment.Add(numberOfComment);
                        totalComment += totalCommentTmp;
                        totalCommentLike += commentApi.GetTotalLikeByQuestionId(questionId);
                    }
                }
                var listSortCountQuestionComment = listQuestionComment.OrderByDescending(c => c.NumberOfComment).Take(3);
                List<QuestionViewModel> listTop3InterestedQuestion = new List<QuestionViewModel>();
                foreach(var item in listSortCountQuestionComment)
                {
                    var questionTmp = questionApi.GetQuestionById(item.QuestionId);
                    listTop3InterestedQuestion.Add(new QuestionViewModel {
                        QuestionId = questionTmp.QuestionId,
                        Username = questionTmp.Username,
                        QuestionContent = questionTmp.QuestionContent,
                        CreateTime = questionTmp.CreateTime.Value.ToString("hh:mm")
                    });
                }
                ViewBag.Top3InterestedQuestion = listTop3InterestedQuestion;
                ViewBag.TotalLikeComment = totalCommentLike;
                ViewBag.TotalComment = totalComment;

                /*Lấy tổng số lượt bình chọn*/
                
                var listVotingId = votingApi.GetListVotingIdByEventId(id);
                int totalVoting = 0;
                foreach(var votingId in listVotingId)
                {
                    totalVoting += votingOptionApi.GetTotalVotingByVotingId(votingId);
                }
                ViewBag.TotalVoting = totalVoting;
                /*Lấy số voting được chạy*/
                int totalVotingRunned = 0;
                totalVotingRunned = votingApi.GetNumberVotingRunned(id);
                ViewBag.TotalVotingRunned = totalVotingRunned;

                /*Lấy list votting được chạy để bỏ vào combo box*/
                IEnumerable<HmsService.ViewModels.VotingViewModel> listVotingRunned = votingApi.GetListVotingRunnedOfEvent(id);
                ViewBag.ListVotingRunned = listVotingRunned;

                /*Lấy số lượng người đk trước event và số người tham gia*/
                int numberGuestRegisterBeforeEvent = guestApi.GetNumberGuestRegisterBeforeEvent(id);
                int numberGuestCheckIn = guestApi.GetNumberGuestCheckInByEventId(id);
                ViewBag.NumberGuestRegisterBeforeEvent = numberGuestRegisterBeforeEvent;
                ViewBag.NumberGuestCheckIn = numberGuestCheckIn;
            }
            catch
            {

            }
            
            return View();
        }

        [Route("GetGuestArrivedOfEvent/{eventId}")]
        public JsonResult GetGuestArrivedOfEvent(int eventId)
        {
            try
            {
                GuestApi guestApi = new GuestApi();
                var numberGuestArrived = guestApi.GetAllGuestArrivedOfEvent(eventId).Count();
                return Json(new {
                    success = true,
                    totalGuestArrived = numberGuestArrived
                });
            }
            catch
            {
                return Json(new {
                    success = false
                });
            }
        }

        [HttpPost]
        public JsonResult GetVotingResult(Voting voting)
        {
            try
            {
                VotingApi votingApi = new VotingApi();
                List<double> listPercentResult = votingApi.GetVotingResult(voting.VotingId);
                return Json(new {
                    success = true,
                    data = listPercentResult
                });
            }
            catch
            {
                return Json(new {
                    success = false
                });
            }
        }
    }
}