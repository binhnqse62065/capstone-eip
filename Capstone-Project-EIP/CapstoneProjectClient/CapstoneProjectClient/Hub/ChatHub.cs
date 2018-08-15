using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;


namespace CapstoneProjectClient
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message, int newQuestionId)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message, newQuestionId);
        }

        public void SendReply(string name, string message, int questionId, int commentId)
        {
            Clients.All.addNewReplyToPage(name, message, questionId, commentId);
        }

        public void LikeQuestion(int questionId, int newNumberOfLike, bool isLike)
        {
            Clients.All.updateNewLikeOfQuestion(questionId, newNumberOfLike, isLike);
        }

        public void DisLikeQuestion(int questionId, int newNumberOfLike, bool isDisLike)
        {
            Clients.All.updateNewDisLikeOfQuestion(questionId, newNumberOfLike, isDisLike);
        }

        public void LikeComment(int commentId, int newNumberOfLike, bool isLike)
        {
            Clients.All.updateNewLikeOfComment(commentId, newNumberOfLike, isLike);
        }

        public void DislikeComment(int commentId, int newNumberOfDislike, bool isLike)
        {
            Clients.All.updateNewDislikeOfComment(commentId, newNumberOfDislike, isLike);
        }
        public ChatHub() : this(GlobalHost.ConnectionManager.GetHubContext<ChatHub>().Clients) { }

        public ChatHub(IHubConnectionContext<dynamic> clients)
        {
        }
    }
}