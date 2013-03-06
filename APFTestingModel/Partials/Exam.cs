using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel 
{
    internal abstract partial class Exam : IExam
    {
        // Commented out to allow compilation
        public Exam(Guid examinerId, Guid candidateId)
        {
            CandidateId = candidateId;
            ExamStatusId = 1;
        }

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
