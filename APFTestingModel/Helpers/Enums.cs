using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
	public enum ExamType : short
	{
		PilotExam = 1,
		PackerExam = 2
	}
	
	public enum ExamStatus : short
	{
		NoExam = 1,
		NewExam = 2,
		TheoryInProgress = 3,
		TheoryFailed = 4,
		TheoryPassed = 5,
        PracticalComponentCompleted = 6,
		ExamCompleted = 7,
		ExamVoided = 8
	}

    public enum PilotLicenceType : short
    {
        PPL = 1,
        CPL = 2,
        ATPL = 3
    }

    public enum PilotMedicalType : short
    {
        ClassOne = 1,
        ClassTwo = 2
    }

    public enum TheoryQuestionCategory : short
    {
        General = 1
    }

    //Hack: added for UI testing
    public enum CanopyTypes
    {
        Big,
        Medium,
        Small,
        Other
    }
    public enum HarnessContainerTypes
    {
        Circle,
        Square,
        Triangle,
        Other
    }
}
