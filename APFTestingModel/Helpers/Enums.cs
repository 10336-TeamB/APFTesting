using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    /// <summary>
    /// Types of exams
    /// </summary>
	public enum ExamType : short
	{
        /// <summary>
        /// Pilot Exam Type
        /// </summary>
		PilotExam = 1,
        /// <summary>
        /// Packer Exam Type
        /// </summary>
		PackerExam = 2
	}
	
    /// <summary>
    /// Status of an exam
    /// </summary>
	public enum ExamStatus : short
	{
        /// <summary>
        /// No exam has been created
        /// </summary>
		NoExam = 1,
        /// <summary>
        /// New exam that was created but not started
        /// </summary>
		NewExam = 2,
        /// <summary>
        /// Theory component of the exam is in progress
        /// </summary>
		TheoryInProgress = 3,
        /// <summary>
        /// Theory component of the exam was taken by the candidate but wasn't successfully completed
        /// </summary>
		TheoryFailed = 4,
        /// <summary>
        /// Theory component of the exam was taken by the candidate and was successfully completed
        /// </summary>
		TheoryPassed = 5,
        /// <summary>
        /// Practical component was successfully completed by the candidate
        /// </summary>
        PracticalComponentCompleted = 6,
        /// <summary>
        /// System is sending the result of the exam as an email to the APF headquarters
        /// </summary>
        EmailInProgress = 7,
        /// <summary>
        /// System couldn't send the result of the exam to the APF headquarters
        /// </summary>
        SendingEmailFailed = 8,
        /// <summary>
        /// Exam was successfully completerd and finalised
        /// </summary>
        ExamCompleted = 9,
        /// <summary>
        /// Exam was voided by the examiner
        /// </summary>
		ExamVoided = 10
	}

    /// <summary>
    /// Licence type of pilot candidate
    /// </summary>
    public enum PilotLicenceType : short
    {
        /// <summary>
        /// Private Pilot License 
        /// </summary>
        PPL = 1,
        /// <summary>
        /// Commercial Pilot Licence
        /// </summary>
        CPL = 2,
        /// <summary>
        /// Air Transport Pilot License
        /// </summary>
        ATPL = 3
    }

    /// <summary>
    /// Medical type of pilot candidate
    /// </summary>
    public enum PilotMedicalType : short
    {
        /// <summary>
        /// Class 1
        /// </summary>
        ClassOne = 1,
        /// <summary>
        /// Class 2
        /// </summary>
        ClassTwo = 2
    }

    /// <summary>
    /// Categories of theory question
    /// </summary>
    public enum TheoryQuestionCategory : short
    {
        /// <summary>
        /// General type
        /// </summary>
        General = 1
    }

    /// <summary>
    /// Canopy type of parachute
    /// </summary>
    public enum CanopyType
    {
        /// <summary>
        /// Ram Air Type
        /// </summary>
        RamAir,
        /// <summary>
        /// Round Type
        /// </summary>
        Round,
        /// <summary>
        /// Other Types
        /// </summary>
        Other
    }

    /// <summary>
    /// Harness container type of the parachute
    /// </summary>
    public enum HarnessContainerType
    {
        /// <summary>
        /// Tandem Type
        /// </summary>
        Tandem,
        /// <summary>
        /// Student Type
        /// </summary>
        Student,
        /// <summary>
        /// Sport Type
        /// </summary>
        Sport,
        /// <summary>
        /// Other Types
        /// </summary>
        Other
    }
}
