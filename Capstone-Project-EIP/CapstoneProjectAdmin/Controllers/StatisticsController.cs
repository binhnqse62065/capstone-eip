using CapstoneProjectAdmin.Models;
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
    [Authorize(Roles = Roles.Admin)]
    public class StatisticsController : Controller
    {
        // GET: Statistics
        [Route("ManageStatistics/{briefName}")]
        public ActionResult Index(string briefName)
        {
            EventApi eventApi = new EventApi();
            var eventTmp = eventApi.GetEventByBriefName(briefName);
            int id = eventTmp.EventID;
            ViewBag.EventId = id;
            ViewBag.BriefName = eventTmp.BriefName;
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

                //var listQaId = qAApi.GetListQaIdByEventId(id);
                var listQa = qAApi.GetQAByEventId(id);
                int totalQuestion = 0;
                int totalQuestionLike = 0;
                foreach(var qa in listQa)
                {
                    totalQuestion += questionApi.GetNumberQuestionByQaId(qa.QAId);
                    totalQuestionLike += questionApi.GetTotalLikeQuestionByQaId(qa.QAId);
                }
                ViewBag.TotalQuestionLike = totalQuestionLike;
                ViewBag.TotalQuestion = totalQuestion;
                /* List QA để hiện ở phần select box câu hỏi được quan tâm*/
                ViewBag.ListQA = listQa;
                /*Lấy số câu hỏi có comment*/
                int totalQuestionHaveComment = qAApi.GetTotalQuestionHaveComment(id);
                ViewBag.TotalQuestionHaveComment = totalQuestionHaveComment;

                /*Lấy tổng số bình luận*/
                
                int totalComment = 0;
                int totalCommentLike = 0;
                List<CountCommentViewModel> listQuestionComment = new List<CountCommentViewModel>();

                foreach (var qa in listQa)
                {
                    var listQuestionIdTmp = questionApi.GetListQuestionIdByQaId(qa.QAId);
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
                /*List 3 câu hỏi có số comment nhiều nhất*/
                //var listSortCountQuestionComment = listQuestionComment.OrderByDescending(c => c.NumberOfComment).Take(3);
                //List<QuestionViewModel> listTop3InterestedQuestion = new List<QuestionViewModel>();
                //foreach (var item in listSortCountQuestionComment)
                //{
                //    var questionTmp = questionApi.GetQuestionById(item.QuestionId);
                //    listTop3InterestedQuestion.Add(new QuestionViewModel
                //    {
                //        QuestionId = questionTmp.QuestionId,
                //        Username = questionTmp.Username,
                //        QuestionContent = questionTmp.QuestionContent,
                //        CreateTime = questionTmp.CreateTime.Value.ToString("hh:mm")
                //    });
                //}
                //ViewBag.Top3InterestedQuestion = listTop3InterestedQuestion;
                int firstQaId = listQa.FirstOrDefault().QAId;
                IEnumerable<QuestionViewModel> listTop3InterestedQuestion = questionApi.GetTop3HotQuestionByQaId(firstQaId).Select(q => new QuestionViewModel
                {
                    QuestionId = q.QuestionId,
                    Username = q.Username,
                    QuestionContent = q.QuestionContent,
                    CreateTime = q.CreateTime.Value.ToString("hh:mm")
                });
                ViewBag.TotalLikeComment = totalCommentLike;
                ViewBag.TotalComment = totalComment;
                ViewBag.Top3InterestedQuestion = listTop3InterestedQuestion;
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
                IEnumerable<VotingResultViewModel> listPercentResult = votingApi.GetVotingResult(voting.VotingId).Select(v => new VotingResultViewModel
                {
                    VotingName = v.VotingOptionContent,
                    PercentVote = (int)v.NumberOfVoting 
                });
              
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

        [HttpPost]
        public JsonResult GetTop3QuestionByQaId(QA qa)
        {
            try
            {
                QuestionApi questionApi = new QuestionApi();
                IEnumerable<QuestionViewModel> listTop3Question = questionApi.GetTop3HotQuestionByQaId(qa.QAId).Select(q => new QuestionViewModel {
                    QuestionId = q.QuestionId,
                    Username = q.Username,
                    QuestionContent = q.QuestionContent,
                    CreateTime = q.CreateTime.Value.ToString("hh:mm")
                });

                return Json(new
                {
                    success = true,
                    data = listTop3Question
                });
            }
            catch
            {
                return Json(new
                {
                    success = false
                });
            }
        }

    }
}