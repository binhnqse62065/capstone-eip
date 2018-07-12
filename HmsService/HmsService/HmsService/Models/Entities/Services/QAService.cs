using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models.Entities.Services
{
    public partial interface IQAService
    {
        QA GetQAById(int qaID);

    }
    public partial class QAService
    {
        public QA GetQAById(int qaId)
        {
            try
            {
                return this.FirstOrDefault(q => q.QAId == qaId);
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
