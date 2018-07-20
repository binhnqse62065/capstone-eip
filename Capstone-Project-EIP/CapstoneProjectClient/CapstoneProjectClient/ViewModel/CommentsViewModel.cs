using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneProjectAdmin.ViewModel
{
    public class CommentsViewModel
    {
        public int CommentId { get; set; }
        public Nullable<int> QuestionId { get; set; }
        public string CommentContent { get; set; }
        public string Username { get; set; }
        public String CreateTime { get; set; }
        public Nullable<int> NumberOfLike { get; set; }
    }
}