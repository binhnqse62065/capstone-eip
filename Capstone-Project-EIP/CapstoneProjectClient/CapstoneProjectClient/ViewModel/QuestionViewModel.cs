using HmsService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneProjectAdmin.ViewModel
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public Nullable<int> QAId { get; set; }
        public string QuestionContent { get; set; }
        public string Username { get; set; }
        public String CreateTime { get; set; }
        public Nullable<int> NumberOfLike { get; set; }
        public IEnumerable<CommentsViewModel> Comments { get; set; }
        public Nullable<bool> IsAnswer { get; set; }

    }
}