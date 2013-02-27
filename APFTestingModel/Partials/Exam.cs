using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel 
{
    public partial class Exam : IExam 
    {
        // TODO: Commented out as EmaxType does not exist preventing compilation - ADAM
        //public Exam(Guid examinerId, Guid candidateId, Guid theoryFormatId, Guid practicalTemplateId, ExamType examType)
        //{
        //    TheoryComponent = new TheoryComponent(examinerId, theoryFormatId);
        //    PracticalComponent = new PracticalComponent(examinerId, practicalTemplateId);
        //    CandidateId = candidateId;
        //    ExamTypeId = (int)examType;
        //    ExamStatusId = 1;
        //}

        public Question FetchNextQuestion(ref bool isLastQuestion)
        {
            return TheoryComponent.FetchNextQuestion(ref isLastQuestion);
        }

        public Question FetchPreviousQuestion(ref bool isFirstQuestion)
        {
            return TheoryComponent.FetchPreviousQuestion(ref isFirstQuestion);
        }

        public Question FetchQuestion(int index, ref bool isFirstQuestion, ref bool isLastQuestion) {
            return TheoryComponent.FetchQuestion(index, ref isFirstQuestion, ref isLastQuestion);
        }

        public void AddTheoryQuestion(Question question) {
            TheoryComponent.Questions.Add(question);
        }

        public TheoryComponentFormat TheoryComponentFormat
        {
            get 
            {
                return TheoryComponent.TheoryComponentFormat;
            }
        }

        public PracticalComponentTemplate PracticalComponentTemplate
        {
            get
            {
                return PracticalComponent.PracticalComponentTemplate;
            }
        }
    }
}
