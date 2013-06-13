using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    /// <summary>
    /// Holds details of pilot candidates
    /// </summary>
    public struct CandidatePilotDetails
    {
        /// <summary>
        /// First name of the pilot candidate
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the pilot candidate
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Date of birth of the pilot candidate
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Street number, street name, or name of the pilot candidate
        /// </summary>
        public string Address1 { get; set; }
        /// <summary>
        /// Unit or Suite number of the pilot candidate
        /// </summary>
        public string Address2 { get; set; }
        /// <summary>
        /// Suburb and city of the pilot candidate 
        /// </summary>
        public string Suburb { get; set; }
        /// <summary>
        /// State of the pilot candidate
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Post code of the pilot candidate
        /// </summary>
        public string Postcode { get; set; }
        /// <summary>
        /// ARN number of the pilot candidate
        /// </summary>
        public string ARN { get; set; }
        /// <summary>
        /// Phone number of the pilot candidate
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Mobile number of the pilot candidate
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// Email of the pilot candidate
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Licence type of the pilot candidate
        /// </summary>
        public PilotLicenceType PilotLicenceType { get; set; }
        /// <summary>
        /// Instrument rating of the pilot candidate
        /// </summary>
        public bool InstrumentRating { get; set; }
        /// <summary>
        /// Medical type of the pilot candidate
        /// </summary>
        public PilotMedicalType PilotMedical { get; set; }
        /// <summary>
        /// Medical Expiry date of the pilot candidate
        /// </summary>
        public DateTime PilotMedicalExpiry { get; set; }
        /// <summary>
        /// Valid BFR of the pilot candidate
        /// </summary>
        public bool ValidBFR { get; set; }
    }

    /// <summary>
    /// Holds details of the packer candidate
    /// </summary>
    public struct CandidatePackerDetails
    {
        /// <summary>
        /// First name of the packer candidate
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the packer candidate
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Mobile number of the packer candidate 
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// APF number of the packer candidate
        /// </summary>
        public string APFNumber { get; set; }
    }

    /// <summary>
    /// Holds result of pilot practical exam
    /// </summary>
    public struct PilotPracticalResult
    {
        /// <summary>
        /// Id of the pilot candidate
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Comment about the practical exam
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Score of the practical exam
        /// </summary>
        public int Score { get; set; }

    }

    /// <summary>
    /// Holds result of packer practical exam
    /// </summary>
    public struct PackerPracticalResult
    {
        /// <summary>
        /// Date when the exam was taken
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Canopy type of the parachute
        /// </summary>
        public string CanopyType { get; set; }
        //public string CanopyTypeSerialNumber { get; set; }
        /// <summary>
        /// Id of the supervisor who took the practical exam
        /// </summary>
        public string SupervisorId { get; set; }
        /// <summary>
        /// Harness container type of the parachute
        /// </summary>
        public string HarnessContainerType { get; set; }
        //public string HarnessContainerSerialNumber { get; set; }
        /// <summary>
        /// Any notes related to the practical exam
        /// </summary>
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

    /// <summary>
    /// Holds details of examiner
    /// </summary>
    public struct ExaminerDetails
    {
        /// <summary>
        /// First name of the examiner
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the examiner
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Username of the examiner
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Password of the examiner
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Old password of the examiner
        /// </summary>
        public string OldPassword { get; set; }
        /// <summary>
        /// APF Number of the examiner
        /// </summary>
        public string APFNumber { get; set; }
        /// <summary>
        /// List of authority of the examiner
        /// </summary>
        public IEnumerable<ExamType> Authorities { get; set; }

        /// <summary>
        /// Constructor of ExaminerDetails
        /// </summary>
        /// <param name="firstName">First name of the examiner</param>
        /// <param name="lastName">Last name of the examiner</param>
        /// <param name="password">Password of the examiner</param>
        /// <param name="apfNumber">APF Number of the examiner</param>
        /// <param name="authorities">List of authority of the examiner</param>
        /// 
        public ExaminerDetails(string firstName, string lastName, string password, string apfNumber, IEnumerable<ExamType> authorities)
            : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            APFNumber = apfNumber;
            Authorities = authorities;
        }
    }
	
    /// <summary>
    /// Holds details of Theory Questions
    /// </summary>
	public struct TheoryQuestionDetails
	{
        /// <summary>
        /// Constructor of TheoryQuestionDetails
        /// </summary>
        /// <param name="description">Description of theory question</param>
        /// <param name="imagePath">Path of an image for theory question if it has one</param>
        /// <param name="category">Category of theory question</param>
        /// <param name="answers">List of options of the question</param>
		public TheoryQuestionDetails(string description, string imagePath, TheoryQuestionCategory category, IEnumerable<AnswerDetails> answers) : this()
		{
            Description = description;
			ImagePath = imagePath;
			Category = category;
			Answers = answers;
		}

        /// <summary>
        /// Description of theory question
        /// </summary>
		public string Description { get; set; }
        /// <summary>
        /// Path of an image for theory question if it has one
        /// </summary>
		public string ImagePath { get; set; }
        /// <summary>
        /// Category of theory question
        /// </summary>
		public TheoryQuestionCategory Category { get; set; }
        /// <summary>
        /// List of options of the question
        /// </summary>
		public IEnumerable<AnswerDetails> Answers { get; set; }
	}

    /// <summary>
    /// Holds details of the theory question options
    /// </summary>
	public struct AnswerDetails
	{
        /// <summary>
        /// Constructor of AnswerDetails
        /// </summary>
        /// <param name="description">Description of the options</param>
        /// <param name="isCorrect">True if the option is correct, otherwise false</param>
        public AnswerDetails(string description, bool isCorrect) : this()
        {
            Description = description;
            IsCorrect = isCorrect;
        }
        
        /// <summary>
        /// Constructor of AnswerDetails
        /// </summary>
        /// <param name="description">Description of the options</param>
        /// <param name="isCorrect">True if the option is correct, otherwise false</param>
        /// <param name="id">Guid id of the answer details</param>
        public AnswerDetails(string description, bool isCorrect, Guid id) : this()
		{
            if (id != null) Id = id;
            Description = description;
			IsCorrect = isCorrect;
		}

        /// <summary>
        /// Guid id of the answer details
        /// </summary>
        public Guid Id { get; private set; }
        /// <summary>
        /// Description of the options
        /// </summary>
		public string Description { get; private set; }
        /// <summary>
        /// True if the option is correct, otherwise false
        /// </summary>
		public bool IsCorrect { get; private set; }
	}

    /// <summary>
    /// Holds details of pilot assessment task
    /// </summary>
    public struct AssessmentTaskPilotDetails
    {
        /// <summary>
        /// Title of the pilot assessment task
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Details of the pilot assessment task
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// Maximum score of the pilot assessment task
        /// </summary>
        public int MaxScore { get; set; }
    }
}

