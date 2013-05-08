using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Exam
{
	public class Instructions
	{
		public Instructions(Guid examId, ITheoryComponentFormat format)
		{
			ExamId = examId;
			NumberOfQuestions = format.NumberOfQuestions;
			PassMark = format.PassMark;
			TimeLimit = format.TimeLimit;
		}

		public Guid ExamId { get; set; }
		public int NumberOfQuestions { get; set; }
		public int PassMark { get; set; }
		public int TimeLimit { get; set; }
	}
}