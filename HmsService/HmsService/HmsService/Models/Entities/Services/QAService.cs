using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models.Entities.Services
{
    public partial interface IQAService
    {
        QA GetQABySessionId(int sessionID);

    }
    public partial class QAService
    {
        HmsEntities db = new HmsEntities();

        public QA GetQABySessionId(int sessionId)
        {
            //chỉ để test thử phần load cần sửa lại
            return this.Get(q => q.QAId == 1).FirstOrDefault();
        }
    }
}
