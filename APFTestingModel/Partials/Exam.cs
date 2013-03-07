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

    internal abstract partial class Exam : IExam
    {
        //Exmpty constructor added for temporary work with the Facade/UI - ADAM/ALAN
        public Exam() { }

        public Exam(Guid examinerId, Guid candidateId)
        {
            CandidateId = candidateId;
            ExamStatusId = 1;
        }

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

        // Commented out to allow compilation
        
        //public TheoryQuestion FetchNextQuestion(ref bool isLastQuestion)
        //{
        //    return TheoryComponent.FetchNextQuestion(ref isLastQuestion);
        //}

        //public TheoryQuestion FetchPreviousQuestion(ref bool isFirstQuestion)
        //{
        //    return TheoryComponent.FetchPreviousQuestion(ref isFirstQuestion);
        //}

        //public TheoryQuestion FetchQuestion(int index, ref bool isFirstQuestion, ref bool isLastQuestion)
        //{
        //    return TheoryComponent.FetchQuestion(index, ref isFirstQuestion, ref isLastQuestion);
        //}

        //public void AddTheoryQuestion(TheoryQuestion question)
        //{
        //    TheoryComponent.TheoryQuestions.Add(question);
        //}

        //public TheoryComponentFormat TheoryComponentFormat
        //{
        //    get 
        //    {
        //        return TheoryComponent.TheoryComponentFormat;
        //    }
        //}

        //public PracticalComponentTemplate PracticalComponentTemplate
        //{
        //    get
        //    {
        //        return PracticalComponent.PracticalComponentTemplate;
        //    }
        //}
    }
}
