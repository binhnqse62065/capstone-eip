using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models.Entities.Services
{
    public partial interface IQuestionService
    {
        IEnumerable<Question> GetQuestionsByQaId(int eventId);
    }
    public partial class QuestionService
    {
        public IEnumerable<Question> GetQuestionsByQaId(int qaId)
        {
            try
            {
                return this.Get(q => q.QAId == qaId);
            }
            catch(Exception e)
            {
                return null;
            }
        }


    }
}
