using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel {
<<<<<<< HEAD
    public partial class Exam 
	{
		public Exam(Candidate candidate, TheoryComponent theoryComponent)
		{

		}
=======
    internal partial class Exam : IExam {
        public Exam(Guid examinerId, Guid candidateId, Guid theoryFormatId, Guid practicalTemplateId, ExamType examType)
        {
            TheoryComponent = new TheoryComponent(examinerId, theoryFormatId);
            PracticalComponent = new PracticalComponent(examinerId, practicalTemplateId);
            CandidateId = candidateId;
            ExamTypeId = (int)examType;
            ExamStatusId = 1;
        }

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
>>>>>>> 65bee23556083283485ed31c84f99f5af5d2eed0
    }
}
