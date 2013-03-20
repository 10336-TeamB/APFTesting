using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Exam
{
	public class TheoryComponentInstructions
	{
		public TheoryComponentInstructions(Guid examId, int numberOfQuestions, int passMark, int timeLimit)
		{
			ExamId = examId;
			NumberOfQuestions = numberOfQuestions;
			PassMark = passMark;
			TimeLimit = timeLimit;
		}

		public Guid ExamId { get; set; }
		public int NumberOfQuestions { get; set; }
		public int PassMark { get; set; }
		public int TimeLimit { get; set; }
	}
}