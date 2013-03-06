using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel 
{
    public enum ExamStatus
    {
        ExamCreated = 1,
        TheoryComponentInProgress = 2,
        TheoryComponentFailed = 3,
        TheoryComponentCompleted = 4,
        PracticalComponentFailed = 5,
        PracticalComponentCompleted = 6,
        ExamCompleted = 7
    }

    internal abstract partial class Exam
    {
        public ExamStatus ExamStatus
        {
            get
            {
                switch (ExamStatusId)
                {
                    case 1:
                        return ExamStatus.ExamCreated;
                    case 2:
                        return ExamStatus.TheoryComponentInProgress;
                    case 3:
                        return ExamStatus.TheoryComponentFailed;
                    case 4:
                        return ExamStatus.TheoryComponentCompleted;
                    case 5:
                        return ExamStatus.PracticalComponentFailed;
                    case 6:
                        return ExamStatus.PracticalComponentCompleted;
                    case 7:
                        return ExamStatus.ExamCompleted;
                    default:
                        throw new BusinessRuleExcpetion("Exam Status invalid");
                }
            }
        }
    }
}
