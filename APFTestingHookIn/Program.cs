using System;
using System.Collections.Generic;
using APFTestingModel;
using APFTestingServices;

namespace APFTestingHookIn {
    
	class Program 
	{
        public static void Main(string[] args)
        {
            Facade _facade = new Facade();

			//List<AnswerDetails> testAnswers = new List<AnswerDetails>();

			//AnswerDetails testAnswer01 = new AnswerDetails();
			//testAnswer01.Description = "Test Answer 1";
			//testAnswer01.IsCorrect = true;
			//testAnswer01.DisplayOrderIndex = 1;
			//testAnswers.Add(testAnswer01);

			//AnswerDetails testAnswer02 = new AnswerDetails();
			//testAnswer02.Description = "Test Answer 2";
			//testAnswer02.IsCorrect = true;
			//testAnswer02.DisplayOrderIndex = 2;
			//testAnswers.Add(testAnswer02);

			//AnswerDetails testAnswer03 = new AnswerDetails();
			//testAnswer03.Description = "Test Answer 3";
			//testAnswer03.IsCorrect = false;
			//testAnswer03.DisplayOrderIndex = 3;
			//testAnswers.Add(testAnswer03);

			//TheoryQuestionDetails testQuestion = new TheoryQuestionDetails();
			//testQuestion.Description = "Test Question 02";
			//testQuestion.Answers = testAnswers;
			//testQuestion.Category = TheoryQuestionCategory.General;
			//testQuestion.ImagePath = "path/path";
			//testQuestion.IsActive = true;

			//_facade.CreateTheoryQuestion(testQuestion, ExamType.PilotExam);

            List<KeyValuePair<string, string>> DemoDetails = new List<KeyValuePair<string, string>>();
            DemoDetails.Add(new KeyValuePair<string,string>("Name", "SpongeBob"));
            DemoDetails.Add(new KeyValuePair<string,string>("Mobile", "0452-Underwater"));
            DemoDetails.Add(new KeyValuePair<string,string>("APF Number", "789456"));
            DemoDetails.Add(new KeyValuePair<string, string>("Score", "18/20 (90%) -- Pass"));

            GeneratePdf pdfVendingMachine = new GeneratePdf();
            pdfVendingMachine.CreatePDF(DemoDetails, 2);

        }
    }
}

