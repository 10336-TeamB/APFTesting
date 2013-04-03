using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
	public enum ExamTypeEnum : short
	{
		PilotExam = 1,
		PackerExam = 2
	}
	
	public enum ExamStatusEnum : short
	{
		NoExam = 1,
		NewExam = 2,
		TheoryInProgress = 3,
		TheoryFailed = 4,
		TheoryPassed = 5,
		PracticalEntered = 6,
		ExamCompleted = 7,
		ExamVoided = 8
	}
}
