using APFTestingModel.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class TheoryComponentManager : Manager
    {
        private TheoryQuestionManager theoryQuestionManager = new TheoryQuestionManager();

        // TODO: Commented out as EmaxType does not exist preventing compilation - ADAM
        //public void selectRandomQuestion(Exam exam, ExamType examType)
        //{
        //    List<Question> questions = (examType == ExamType.PACKER_EXAM) ? questions = theoryQuestionManager.PackerQuestions : questions = theoryQuestionManager.PilotQuestions;
        //    Random random = new Random();
            
        //    for (int i = 0; i < exam.TheoryComponentFormat.NumberOfQuestions; ++i)
        //    {
        //        int randIndex = random.Next() % questions.Count;
        //        exam.AddTheoryQuestion(questions.ElementAt(randIndex));
        //        questions.RemoveAt(randIndex);
        //    }
        //}
    }
}
