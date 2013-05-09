using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public struct CandidatePilotDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public string Suburb { get; set; }

        public string State { get; set; }
        public string Postcode { get; set; }
        public string ARN { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public PilotLicenceType PilotLicenceType { get; set; }
        public bool InstrumentRating { get; set; }
        public PilotMedicalType PilotMedical { get; set; }
        public DateTime PilotMedicalExpiry { get; set; }
        public bool ValidBFR { get; set; }
    }

    public struct CandidatePackerDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string APFNumber { get; set; }
    }

    public struct PilotPracticalResult
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int Score { get; set; }

    }

    public struct PackerPracticalResult
    {
        public DateTime Date { get; set; }
        public string CanopyType { get; set; }
        public string CanopyTypeSerialNumber { get; set; }
        public string SupervisorId { get; set; }
        public string HarnessContainerType { get; set; }
        public string HarnessContainerSerialNumber { get; set; }
        public string Note { get; set; }

    }

	//public struct PackerPracticalResult
	//{
	//	public DateTime Date { get; set; }
	//	public string CanopyType { get; set; }
	//	public string CanopyTypeSerialNumber { get; set; }
	//	public string SupervisorId { get; set; }
	//	public string HarnessContainerType { get; set; }
	//	public string HarnessContainerSerialNumber { get; set; }
	//	public string Note { get; set; }
	//}

    public struct ExaminerDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
        public string APFNumber { get; set; }
        public List<ExamType> Authorities { get; set; }

        public ExaminerDetails(string firstName, string lastName, string password, string apfNumber, List<ExamType> authorities) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            APFNumber = apfNumber;
            Authorities = authorities;
        }
    }
	
	public struct TheoryQuestionDetails
	{
		public TheoryQuestionDetails(string description, string imagePath, TheoryQuestionCategory category, List<AnswerDetails> answers) : this()
		{
            Description = description;
			ImagePath = imagePath;
			Category = category;
			Answers = answers;
		}

		public string Description { get; set; }
		public string ImagePath { get; set; }
		public TheoryQuestionCategory Category { get; set; }
		public List<AnswerDetails> Answers { get; set; }
	}

	public struct AnswerDetails
	{
        public AnswerDetails(string description, bool isCorrect) : this()
        {
            Description = description;
            IsCorrect = isCorrect;
        }
        
        public AnswerDetails(string description, bool isCorrect, Guid id) : this()
		{
            if (id != null) Id = id;
            Description = description;
			IsCorrect = isCorrect;
		}

        public Guid Id { get; private set; }
		public string Description { get; private set; }
		public bool IsCorrect { get; private set; }
	}

    public struct AssessmentTaskPilotDetails
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public int MaxScore { get; set; }
    }


}

