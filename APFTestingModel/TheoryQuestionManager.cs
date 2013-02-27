using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class TheoryQuestionManager : Manager
    {
        public List<Question> PackerQuestions
        {
            get
            {
                return context.Questions.Where(q => q.ExamTypeId == 1).ToList();
            }
        }

        public List<Question> PilotQuestions
        {
            get
            {
                return context.Questions.Where(q => q.ExamTypeId == 2).ToList();
            }
        }
    }
}
