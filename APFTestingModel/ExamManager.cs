using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public class ExamManager : Manager
    {
        //Get results and generate report

        public Exam FetchExam(Guid examId)
        {
            return context.Exams.FirstOrDefault(e => e.Id == examId);
        }
    }
}
