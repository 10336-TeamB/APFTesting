using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public class Facade : IDisposable
    {
		//private ExamManager examMananger = new ExamManager();
		//private TheoryComponentManager theoryComponentManager = new TheoryComponentManager();
		//private TheoryQuestionManager theoryQuestionManager = new TheoryQuestionManager();
		//private PracticalComponentManager practicalComponentManager = new PracticalComponentManager();


		//public Question FetchNextQuestion(Guid examId, ref bool isLastQuestion)
		//{
		//	return null;
		//}

		//public Exam FetchExam(Guid id)
		//{
		//	return examMananger.FetchExam(id);
		//}

        public void Dispose()
        {
            // TODO: Implement Dispose method
        }
    }
}
