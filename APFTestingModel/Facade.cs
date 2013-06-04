using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APFTestingMembership;

namespace APFTestingModel
{
    internal delegate void deleteEntityDelegate<T>(T entity);
    public class Facade : IFacade
    {
        private APFTestingDBEntities _context = new APFTestingDBEntities();
        private ExamManager examManager;



        /*=====================================*/
        /*      INITIATE THEORY COMPONENT      */
        /*=====================================*/
        
		#region Initiate Theory Component
        
        /// <summary>
        /// Checks whether or not the candidate has any incomplete exam and returns the incomplete exam. If candidate doesn't have any incomplete exam, then it creates a new exam and return it.
        /// </summary>
        /// <param name="examinerId">Guid Id of the examiner who created the exam</param>
        /// <param name="candidateId">Guid id of the candidate who is going to take the exam</param>
        /// <returns>Guid id of the exam</returns>
        public Guid StartTheoryComponent(Guid examinerId, Guid candidateId)
        {
            var candidate = fetchCandidate(candidateId);
            
            return (candidate.NewExamPossible) ? CreateExam(examinerId, candidate) : candidate.LatestExamId;
        }

        /// <summary>
        /// Resumes the Theory Component part of the incomplete exam
        /// </summary>
        /// <param name="examId">Guid id of the incomplete exam</param>
        /// <returns>The question that is pointed by the current question index counter</returns>
		public ISelectedTheoryQuestion ResumeTheoryComponent(Guid examId)
		{
            var exam = fetchExamForQuestionFetching(examId);

			return exam.FetchCurrentQuestion();
		}

        private void createExamManager(ExamType examType)
        {
            TheoryComponentFormat activeTheoryFormat;
            PracticalComponentTemplate activePracticalTemplate;
            IEnumerable<TheoryQuestion> questions;
            
            switch (examType)
            {
                case ExamType.PilotExam:
                    activeTheoryFormat = _context.TheoryComponentFormats.OfType<TheoryComponentFormatPilot>().FirstOrDefault(f => f.IsActive);
                    activePracticalTemplate = _context.PracticalComponentTemplates.Include("AssessmentTaskPilots").OfType<PracticalComponentTemplatePilot>().FirstOrDefault(t => t.IsActive);
                    questions = _context.TheoryQuestions.OfType<TheoryQuestionPilot>().Include("Answers");
                    break;
                case ExamType.PackerExam:
                    activeTheoryFormat = _context.TheoryComponentFormats.OfType<TheoryComponentFormatPacker>().FirstOrDefault(f => f.IsActive);
                    activePracticalTemplate = _context.PracticalComponentTemplates.OfType<PracticalComponentTemplatePacker>().FirstOrDefault(t => t.IsActive);
                    questions = _context.TheoryQuestions.OfType<TheoryQuestionPacker>().Include("Answers");
                    break;
                default:
                    throw new BusinessRuleException("Invalid exam type provided");
            }

            examManager = ManagerFactory.CreateExamManager(questions, activeTheoryFormat, activePracticalTemplate, examType);
        }
		
		private Guid CreateExam(Guid examinerId, Person candidate)
		{
            Exam exam;

            if (candidate is CandidatePilot)
            {
                createExamManager(ExamType.PilotExam);
            }
            else if (candidate is CandidatePacker)
            {
                createExamManager(ExamType.PackerExam);
            }
            exam = examManager.GenerateExam(examinerId, candidate.Id);
            _context.Exams.Add(exam);
            _context.SaveChanges();
            return exam.Id;
		}
		
		// HACK: Rest Theory Component
		public void ResetTheoryComponent(Guid examId)
		{
		    var exam = fetchExamForQuestionFetching(examId);
			exam.ResetTheoryComponent();
			_context.SaveChanges();
		}


        #endregion

        

        /*================================*/
        /*      SIT THEORY COMPONENT      */
        /*================================*/

        #region Sit Theory Component

        /// <summary>
        /// Fetches the next question pointed by the question index of the exam that is in progress
        /// </summary>
        /// <param name="examId">Guid id of the exam in progress</param>
        /// <returns>The next question</returns>
        public ISelectedTheoryQuestion FetchNextQuestion(Guid examId)
        {
            var exam = fetchExamForQuestionFetching(examId);
            var question = exam.FetchNextQuestion();
            _context.SaveChanges();

            return question;
        }

        /// <summary>
        /// Fetches the previous question pointed by the question index of the exam that is in progress
        /// </summary>
        /// <param name="examId">Guid id of the exam in progress</param>
        /// <returns>The previous question</returns>
        public ISelectedTheoryQuestion FetchPreviousQuestion(Guid examId)
        {
            var exam = fetchExamForQuestionFetching(examId);
            var question = exam.FetchPreviousQuestion();
            _context.SaveChanges();
            
            return question;
        }

        /// <summary>
        /// Fetches the specific question pointed by the questionIndex passed on the parameter
        /// </summary>
        /// <param name="examId">Guid id of the exam in progress</param>
        /// <param name="questionIndex">Question index of the question to be fetched</param>
        /// <returns>The fetched question</returns>
        public ISelectedTheoryQuestion FetchSpecificQuestion(Guid examId, int questionIndex)
        {
            var exam = fetchExamForQuestionFetching(examId);
            var question = exam.FetchSpecificQuestion(questionIndex);
            _context.SaveChanges();

            return question;
        }

        /// <summary>
        /// Answer the specific question pointed by the question index
        /// </summary>
        /// <param name="examId">Guid id of the exam in progress</param>
        /// <param name="questionIndex">Question index of the question to be fetched</param>
        /// <param name="selectedAnswers">Answer index</param>
        /// <param name="markForReview">True if question was marked for review else false</param>
        public void AnswerQuestion(Guid examId, int questionIndex, int[] selectedAnswers, bool markForReview)
        {
			var exam = fetchExamForQuestionFetching(examId);

            exam.AnswerQuestion(questionIndex, selectedAnswers, markForReview);
            _context.SaveChanges();
        }

        /// <summary>
        /// Fetched the summary of the theory component of the specific exam
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
        /// <returns>Readonly list of the theory questions</returns>
		public IEnumerable<ISelectedTheoryQuestion> FetchTheoryComponentSummary(Guid examId)
		{
			Exam exam = fetchExamForQuestionFetching(examId);
            MergeSort<SelectedTheoryQuestion> mergeSort = new MergeSort<SelectedTheoryQuestion>();
            List<SelectedTheoryQuestion> sortedQuestions = mergeSort.mergeSort(exam.SelectedTheoryQuestions.ToList());
			return sortedQuestions;
		}

        /// <summary>
        /// Submits the theory component of the exam by changing its status to Passed or Failed
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
		public void SubmitTheoryComponent(Guid examId)
		{
			var exam = _context.Exams
				.Include("TheoryComponent")
				.Include("TheoryComponent.SelectedTheoryQuestions")
				.Include("TheoryComponent.SelectedTheoryQuestions.PossibleAnswers")
				.Include("TheoryComponent.SelectedTheoryQuestions.PossibleAnswers.Answer")
				.Include("TheoryComponent.TheoryComponentFormat")
				.First(e => e.Id == examId);

			exam.SubmitTheoryComponent();
			_context.SaveChanges();
		}

        /// <summary>
        /// Voids an exam by changing its status to Voided
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
        /// <param name="username">Username of the examiner who is voiding the exam</param>
        /// <param name="password">Password of the examiner who is voiding the exam</param>
		public void VoidExam(Guid examId, string username, string password)
		{
            Membership membership = new Membership();
            if (membership.Login(username, password))
            {
                Exam exam = _context.Exams.FirstOrDefault(e => e.Id == examId);
                if (exam == null)
                {
                    throw new BusinessRuleException("Invalid Exam ID");
                }
                exam.VoidExam();
                _context.SaveChanges();
            }
            else
            {
                throw new BusinessRuleException("Invalid username or password");
            }
		}

        #endregion


        /*=========================*/
        /*      FINALISE EXAM      */
        /*=========================*/

        #region Finalise Exam
        
        /// <summary>
        /// Fetches a single exam from database by passing the Guid id of the exam
        /// </summary>
        /// <param name="examId">Guid id of the exam to fetch</param>
        /// <param name="examType">Exam Type of the exam to fetch</param>
        /// <returns>Exam that was fetched from the database</returns>
        public IExam FetchExam(Guid examId, ExamType examType)
        {
            return fetchExam(examId, examType);
        }

        
        internal Exam fetchExam(Guid examId, ExamType examType)
        {
            Exam exam;
            switch (examType)
            {
                case ExamType.PilotExam:
                    exam = _context.Exams.Include("TheoryComponent").Include("TheoryComponent.TheoryComponentFormat").Include("TheoryComponent.SelectedTheoryQuestions").Include("Examiner").OfType<ExamPilot>().Include("CandidatePilot").Include("CandidatePilot.Address").Include("PracticalComponentPilot").Include("PracticalComponentPilot.PracticalComponentTemplatePilot").Include("PracticalComponentPilot.SelectedAssessmentTasks").Include("PracticalComponentPilot.SelectedAssessmentTasks.AssessmentTaskPilot").FirstOrDefault(e => e.Id == examId);
                    break;
                case ExamType.PackerExam:
                    exam = _context.Exams.Include("TheoryComponent").Include("TheoryComponent.TheoryComponentFormat").Include("TheoryComponent.SelectedTheoryQuestions").Include("Examiner").OfType<ExamPacker>().Include("CandidatePacker").Include("PracticalComponentPacker").Include("PracticalComponentPacker.PracticalComponentTemplatePacker").Include("PracticalComponentPacker.AssessmentTaskPackers").FirstOrDefault(e => e.Id == examId);
                    break;
                default:
                    //This should not occur as ExamType is strongly typed
                    throw new BusinessRuleException("Invalid Exam Type");
            }

            if (exam == null)
            {
                throw new BusinessRuleException("Exam not found");
            }
            return exam;
        }

        //Do we even need this? - Pradipna
        public bool HasPassedPractical(Guid examId, ExamType examType)
        {
            return fetchExam(examId, examType).PracticalComponentIsCompetent;
        }

        /// <summary>
        /// Changes the exam status to 'EmailInProgress' and sends an asynchronous message to WCF email service for sending the exam report to APF Headquaters. WCF service will trigger a callback when it has finished sending email and if it failed to send an email, exam status is changed to 'SendingEmailFailed' otherwise the exam status is changed to 'ExamCompleted'
        /// </summary>
        /// <param name="examId">Guid id of the exam that needs to be finalised</param>
        /// <param name="examType">Exam type of the exam that needs to be finalised</param>
        public void FinaliseExam(Guid examId, ExamType examType)
        {
            Exam exam = fetchExam(examId, examType);
            exam.FinaliseExam();
            _context.SaveChanges();
        }

        #endregion 


        /*=========================*/
        /*      FETCH METHODS      */
        /*=========================*/

        #region Fetch Methods

        /// <summary>
        /// Fetches the theory component format of the particular exam
        /// </summary>
        /// <param name="examId">Guid id of the exam that the theory component format belongs to</param>
        /// <returns>Theory component format that was fetched</returns>
        public ITheoryComponentFormat FetchTheoryComponentFormatForExam(Guid examId)
        {
            var exam = _context.Exams.Include("TheoryComponent").Include("TheoryComponent.TheoryComponentFormat").First(e => e.Id == examId);

            return exam.FetchTheoryComponentFormat();
        }
		
        /// <summary>
        /// Fetches the first question of the exam. 
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
        /// <returns>First question of the exam</returns>
        public ISelectedTheoryQuestion FetchFirstQuestion(Guid examId)
        {
            var exam = fetchExamForQuestionFetching(examId);
            var question = exam.FetchFirstQuestion();
            _context.SaveChanges();

            return question;
        }
		
        /// <summary>
        /// Retrieves the list of candidates for the examiner with the id of examinerId
        /// </summary>
        /// <param name="examinerId">Guid id of the examiner</param>
        /// <returns>Readonly list of the candidates</returns>
		public IEnumerable<ICandidate> FetchCandidates(Guid examinerId)
		{
            var examiner = _context.People.Include("CandidatePackers").Include("CandidatePilots").Include("CandidatePackers.ExamPackers").Include("CandidatePilots.ExamPilots").OfType<Examiner>().First(e => e.Id == examinerId);

            List<ICandidate> candidates = new List<ICandidate>();
            candidates.AddRange(examiner.CandidatePackers);
            candidates.AddRange(examiner.CandidatePilots);
            return candidates;
		}

        /// <summary>
        /// Fetches the pilot candidate
        /// </summary>
        /// <param name="candidateId">Guid id of the candidate we want to fetch</param>
        /// <returns>Candidate that was fetched</returns>
        public ICandidatePilot FetchPilot(Guid candidateId)
        {
            return _context.People.OfType<CandidatePilot>().Include("Address").First(c => c.Id == candidateId);
        }

        /// <summary>
        /// Fetches the packer candidate
        /// </summary>
        /// <param name="candidateId">Guid id of the candidate we want to fetch</param>
        /// <returns>Candidate that was fetched</returns>
        public ICandidatePacker FetchPacker(Guid candidateId)
        {
            return _context.People.OfType<CandidatePacker>().First(c => c.Id == candidateId);
        }

        private Person fetchCandidate(Guid candidateId)
        {
            var candidate = _context.People.First(c => c.Id == candidateId);

            if (candidate is CandidatePacker) {
                _context.Entry(candidate).Collection<ExamPacker>("ExamPackers").Load();
            }
            else if (candidate is CandidatePilot)
            {
                _context.Entry(candidate).Collection<ExamPilot>("ExamPilots").Load();
            }
            else
            {
                throw new BusinessRuleException("Id doesn't belong to Pilot or Packer candidate");
            }

            return candidate ;
        }

        private Exam fetchExamForQuestionFetching(Guid examId)
        {
            return _context.Exams
					.Include("TheoryComponent")
                    .Include("TheoryComponent.SelectedTheoryQuestions")
                    .Include("TheoryComponent.SelectedTheoryQuestions.TheoryQuestion")
                    .Include("TheoryComponent.SelectedTheoryQuestions.PossibleAnswers")
                    .Include("TheoryComponent.SelectedTheoryQuestions.PossibleAnswers.Answer")
                    .First(e => e.Id == examId);
        }

        /// <summary>
        /// Fetches the result of theory component part of the exam
        /// </summary>
        /// <param name="examId">Guid id of the exam that we want theory componenet of</param>
        /// <returns>Theory component of the exam</returns>
		public ITheoryComponent FetchTheoryComponentResult(Guid examId)
		{
			var exam = _context.Exams
						.Include("TheoryComponent")
						.Include("TheoryComponent.SelectedTheoryQuestions")
                        .Include("TheoryComponent.SelectedTheoryQuestions.TheoryQuestion")
                        .Include("TheoryComponent.SelectedTheoryQuestions.PossibleAnswers")
						.Include("TheoryComponent.SelectedTheoryQuestions.PossibleAnswers.Answer")
						.Include("TheoryComponent.TheoryComponentFormat")
						.First(e => e.Id == examId);

			return exam.FetchTheoryComponentResult();
		}

        /// <summary>
        /// Fetches the practical assessment task from an exam 
        /// </summary>
        /// <param name="examId">Guid id of the exam to fetch assessment task from</param>
        /// <returns>Assessment task of the exam</returns>
        public IEnumerable<ISelectedAssessmentTask> FetchAssessmentTasksPilot(Guid examId)
        {
            var exam = _context.Exams.OfType<ExamPilot>().Include("PracticalComponentPilot")
                .Include("PracticalComponentPilot.SelectedAssessmentTasks")
                .Include("PracticalComponentPilot.SelectedAssessmentTasks.AssessmentTaskPilot")
                .FirstOrDefault(e => e.Id == examId);

            return exam.SelectedAssessmentTasks;
        }

        /// <summary>
        /// Retrives the list of all the practical component template for the pilot candidates
        /// </summary>
        /// <returns>Readonly list of all the practical component template for the pilot candidates</returns>
        public IEnumerable<IPracticalComponentTemplatePilot> FetchAllPracticalComponentTemplatePilots()
        {
            return _context.PracticalComponentTemplates.OfType<PracticalComponentTemplatePilot>().Include("PracticalComponentPilots").Include("AssessmentTaskPilots").OrderByDescending(t => t.IsActive).ToList();
        }

        /// <summary>
        /// Retrives the list of all the practical component template for the packer candidates
        /// </summary>
        /// <returns>Readonly list of all the practical component template for the packer candidates</returns>
        public IEnumerable<IPracticalComponentTemplatePacker> FetchAllPracticalComponentTemplatePackers()
        {
            return _context.PracticalComponentTemplates.OfType<PracticalComponentTemplatePacker>().Include("PracticalComponentPackers").OrderByDescending(t => t.IsActive).ToList();
        }

        

        
        #endregion

        /// <summary>
        /// Creates a theory question for a particular exam type and adds it to the database
        /// </summary>
        /// <param name="questionDetails">Data structure which contains description, options and correct answers of the question that is being created</param>
        /// <param name="examType">Exam type of the question that is being created</param>
		public void CreateTheoryQuestion(TheoryQuestionDetails questionDetails, ExamType examType)
		{
			switch (examType)
			{
				case ExamType.PilotExam:
					createExamManager(ExamType.PilotExam);
					break;
				case ExamType.PackerExam:
					createExamManager(ExamType.PackerExam);
					break;
			}

			var newQuestion = examManager.CreateTheoryQuestion(questionDetails);

			_context.TheoryQuestions.Add(newQuestion);
			_context.SaveChanges();
		}

		/// <summary>
		/// Retrieves a list of all the theory questions for pilot
		/// </summary>
		/// <returns>Readonly list of all the questions for pilot</returns>
        public IEnumerable<ITheoryQuestion> FetchAllTheoryQuestionsPilot()
        {
            return _context.TheoryQuestions.OfType<TheoryQuestionPilot>().Include("SelectedTheoryQuestions").ToList();
        }

        /// <summary>
        /// Retrieves a list of all the theory questions for packer
        /// </summary>
        /// <returns>Readonly list of all the questions for packer</returns>
		public IEnumerable<ITheoryQuestion> FetchAllTheoryQuestionsPacker()
		{
			var questions = _context.TheoryQuestions.OfType<TheoryQuestionPacker>().Include("SelectedTheoryQuestions").ToList();

            return questions;
		}

        /// <summary>
        /// Fetches theory question
        /// </summary>
        /// <param name="questionId">Guid id of the theory question to be fetched</param>
        /// <returns>Theory question that was fetched</returns>
        public ITheoryQuestion FetchTheoryQuestion(Guid questionId)
        {
            var question = _context.TheoryQuestions.Include("Answers").Include("SelectedTheoryQuestions").First(q => q.Id == questionId);
			
			question.Answers = question.Answers.OrderBy(a => a.DisplayOrderIndex).ToList();

			return question;
        }

        /// <summary>
        /// Edits theory question
        /// </summary>
        /// <param name="questionDetails">Data structure which contains updated description, options and correct answers of the question that is being edited</param>
        /// <param name="questionId">Guid id of the question to be edited</param>
        public void EditTheoryQuestion(TheoryQuestionDetails questionDetails, Guid questionId)
        {
            var question = _context.TheoryQuestions.Include("Answers").Include("SelectedTheoryQuestions").First(q => q.Id == questionId);
            var answersToDelete = question.Edit(questionDetails);

			foreach (var answer in answersToDelete)
			{
				_context.Answers.Remove(answer);
			}

			_context.SaveChanges();
        }

        /// <summary>
        /// Deletes theory question if it is not referenced by any exam otherwise throws an exception
        /// </summary>
        /// <param name="questionId">Guid id of the question to be deleted</param>
        public void DeleteTheoryQuestion(Guid questionId, ExamType examType, out string imagePath)
        {
            if (!IsQuestionDeactivationPossible(examType))
            {
                throw new BusinessRuleException("Cannot delete Theory Question. Not enough questions for current active format");
            }

            var question = _context.TheoryQuestions.Include("Answers").Include("SelectedTheoryQuestions").First(q => q.Id == questionId);
            imagePath = question.ImagePath;
            question.Delete(deleteEntity, deleteEntity);

            _context.SaveChanges();
        }

        /// <summary>
        /// Toggles the activation status of the question
        /// </summary>
        /// <param name="questionId">Guid id of the question</param>
        public void ToggleTheoryQuestionActivation(Guid questionId, ExamType examType)
        {
            var question = _context.TheoryQuestions.First(q => q.Id == questionId);

            if (!IsQuestionDeactivationPossible(examType) && question.IsActive)
            {
                throw new BusinessRuleException("Cannot deactivate Theory Question. Not enough questions for current active format");
            }

            question.toggleActivation();

            _context.SaveChanges();
        }

        /// <summary>
        /// Counts the number of questions with images as part of the question
        /// </summary>
        /// <returns>Number of questions with images as part of the question</returns>
        public int CountQuestionsWithImages()
        {
            return _context.TheoryQuestions.Count(q => q.ImagePath != null);
        }


		/*=========================*/
		/*      OTHER METHODS      */
		/*=========================*/

		#region Other Methods
		
        /// <summary>
        /// Creates a Pilot candidate
        /// </summary>
        /// <param name="details">Details such as Name, APF Number etc</param>
        /// <param name="createdBy">Guid id of the examiner who created the candidate</param>
        /// <returns>Guid id of the newly created examiner</returns>
        public Guid CreateCandidate(CandidatePilotDetails details, Guid createdBy)
        {
            CandidatePilot candidatePilot = new CandidatePilot(details, createdBy);
            _context.People.Add(candidatePilot);
            _context.SaveChanges();
            return candidatePilot.Id;
        }

        /// <summary>
        /// Creates a Packer candidate
        /// </summary>
        /// <param name="details">Details such as Name, APF Number etc</param>
        /// <param name="createdBy">Guid id of the examiner who created the candidate</param>
        /// <returns>Guid id of the newly created examiner</returns>
        public Guid CreateCandidate(CandidatePackerDetails details, Guid createdBy)
        {
            CandidatePacker candidatePacker = new CandidatePacker(details, createdBy);
            _context.People.Add(candidatePacker);
            _context.SaveChanges();
            return candidatePacker.Id;
        }

        /// <summary>
        /// Submits the practical component results of the pilot candidate and updates the exam status
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
        /// <param name="results">Readonly list of the results</param>
        public void SubmitPilotPracticalResults(Guid examId, IEnumerable<PilotPracticalResult> results)
        {
            var exam = _context.Exams.OfType<ExamPilot>().Include("PracticalComponentPilot").Include("PracticalComponentPilot.SelectedAssessmentTasks").First(e => examId == e.Id);
            exam.SubmitPilotPracticalResults(results);
            _context.SaveChanges();
        }

        /// <summary>
        /// Submits the practical component results of the packer candidate and updates the exam status
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
        /// <param name="results">Readonly list of the results</param>
        public void SubmitPackerPracticalResult(Guid examId, PackerPracticalResult result)
        {
            if (result.CanopyType == null)
            {
                throw new BusinessRuleException("You must enter Canopy Type");
            }
            if (result.HarnessContainerType == null)
            {
                throw new BusinessRuleException("You must enter Harness/Container Type");
            }
            var exam = _context.Exams.OfType<ExamPacker>().Include("PracticalComponentPacker").Include("PracticalComponentPacker.AssessmentTaskPackers").First(e => e.Id == examId);
            exam.AddPracticalComponentResult(result);
            _context.SaveChanges();
        }

        /// <summary>
        /// Edits a specific task in the practical component of the packer exam
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
        /// <param name="taskId">Guid id of the task to be updated</param>
        /// <param name="result">Result of the task</param>
        public void EditPackerPracticalResult(Guid examId, Guid taskId, PackerPracticalResult result)
        {
            var exam = _context.Exams.OfType<ExamPacker>().Include("PracticalComponentPacker").Include("PracticalComponentPacker.AssessmentTaskPackers").First(e => e.Id == examId);

            exam.EditPackerPracticalResult(taskId, result);
            _context.SaveChanges();
        }

        /// <summary>
        /// Finalises the practical component by changing its exam status
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
        public void FinalisePractical(Guid examId)
        {
            var exam = _context.Exams.First(e => e.Id == examId);
            exam.FinalisePractical();
            _context.SaveChanges();
        }

        /// <summary>
        /// Fetches the assessment tasks of the packer exam
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
        /// <param name="isCompetent">Referenced variable that returns whether or not the packer candidate has passed the practical assessment</param>
        /// <param name="requiredNumberOfTasks">Referenced variable that returns how many tasks are required to pass the practical component</param>
        /// <returns>Readonly list of the practical assessment tasks of the packer exam</returns>
        public IEnumerable<IAssessmentTaskPacker> FetchAssessmentTasksPacker(Guid examId, out bool isCompetent, out int requiredNumberOfTasks)
        {
            var exam = _context.Exams.OfType<ExamPacker>().Include("PracticalComponentPacker").Include("PracticalComponentPacker.AssessmentTaskPackers").Include("PracticalComponentPacker.PracticalComponentTemplatePacker").First(e => e.Id == examId);
            requiredNumberOfTasks = exam.PracticalComponentPacker.NumOfRequiredAssessmentTasks;
            isCompetent = exam.PracticalComponentIsCompetent;
            return exam.AssessmentTasks;
        }

        /// <summary>
        /// Retrieves a specific practical assessment task of the packer exam
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
        /// <param name="taskId">Guid id of the task</param>
        /// <returns>The fetched assessment task</returns>
        public IAssessmentTaskPacker FetchSingleAssessmentTaskPacker(Guid examId, Guid taskId)
        {
            var exam = _context.Exams.OfType<ExamPacker>().Include("PracticalComponentPacker").Include("PracticalComponentPacker.AssessmentTaskPackers").First(e => e.Id == examId);
            
            return exam.AssessmentTasks.First(at => at.Id == taskId);
        }

        /// <summary>
        /// Edits the specific packer candidate
        /// </summary>
        /// <param name="candidateId">Guid of the packer candidate</param>
        /// <param name="details">Packer candidate details such as Name, APF Number etc</param>
        public void EditPacker(Guid candidateId, CandidatePackerDetails details)
        {
            var candidate = _context.People.OfType<CandidatePacker>().First(c => c.Id == candidateId);
            candidate.Edit(details);
            _context.SaveChanges();
        }

        /// <summary>
        /// Edits the specific pilot candidate
        /// </summary>
        /// <param name="candidateId">Guid of the pilot candidate</param>
        /// <param name="details">Pilot candidate details such as Name, APF Number etc</param>
        public void EditPilot(Guid candidateId, CandidatePilotDetails details)
        {
            var candidate = _context.People.OfType<CandidatePilot>().Include("Address").First(c => c.Id == candidateId);
            candidate.Edit(details);
            _context.SaveChanges();
        }

        /// <summary>
        /// Logs in the examiner and adminstrator to the system
        /// </summary>
        /// <param name="username">Username of the person that is logging in</param>
        /// <param name="password">Password of the person that is logging in</param>
        /// <param name="rememberMe">If set to true, temporatily stores credentials</param>
        /// <returns>Success or failure while logging the user to the system</returns>
        public bool Login(string username, string password, bool rememberMe)
        {
            Membership membership = new Membership();
            return membership.Login(username, password, rememberMe);
        }

        /// <summary>
        /// Logs out the user from the system
        /// </summary>
        public void Logout()
        {
            Membership membership = new Membership();
            membership.Logout();
        }

        /// <summary>
        /// Returns whether or not the deactivation of a question is possible
        /// </summary>
        /// <param name="examType">Exam type of the question that is going to be deactivated</param>
        /// <returns>True if question deactivation is possible, otherwise false</returns>
        public bool IsQuestionDeactivationPossible(ExamType examType) {
           TheoryComponentFormat format;
           switch (examType)
           {
               case ExamType.PackerExam:
                   format = _context.TheoryComponentFormats.OfType<TheoryComponentFormatPacker>().First(f => f.IsActive);
                   if (FetchAllTheoryQuestionsPacker().Where(q => q.IsActive).Count() <= format.NumberOfQuestions)
                   {
                       return false;
                   }
                   break;
               case ExamType.PilotExam:
                   format = _context.TheoryComponentFormats.OfType<TheoryComponentFormatPilot>().First(f => f.IsActive);
                   if (FetchAllTheoryQuestionsPilot().Where(q => q.IsActive).Count() <= format.NumberOfQuestions)
                   {
                       return false;
                   }
                   break;
               default:
                   throw new BusinessRuleException("Invalid Exam Type");
           }

           return true;
        }

        /// <summary>
        /// Returns whether or not the activation of a format is possible
        /// </summary>
        /// <param name="formatId">Guid id of the format we want to activate</param>
        /// <returns>True if we can activate the format, otherwise false</returns>
        public bool IsFormatActivationPossible(Guid formatId)
        {
            TheoryComponentFormat format = _context.TheoryComponentFormats.First(f => f.Id == formatId);
            if (format is TheoryComponentFormatPacker)
            {
                if (FetchAllTheoryQuestionsPacker().Where(q => q.IsActive).Count() < format.NumberOfQuestions)
                {
                    return false;
                }
            }
            else
            {
                if (FetchAllTheoryQuestionsPilot().Where(q => q.IsActive).Count() < format.NumberOfQuestions)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region CRUD Pilot Practical Assessment tasks

        /// <summary>
        /// 
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public IAssessmentTaskPilot CreateAssessmentTaskPilot(AssessmentTaskPilotDetails details)
        {
            return (IAssessmentTaskPilot)createAssessmentTask(details);
        }

        private AssessmentTask createAssessmentTask(AssessmentTaskPilotDetails details)
        {
            examManager = ManagerFactory.CreatePracticalExamMananger(ExamType.PilotExam);
            AssessmentTask assessmentTask = (examManager as ExamManagerPilot).CreateAssessmentTask(details);
            _context.AssessmentTasks.Add(assessmentTask);
            _context.SaveChanges();
            return assessmentTask;
        }

        public IAssessmentTaskPilot FetchAssessmentTaskPilot(Guid assessmentTaskId)
        {
            return fetchAssessmentTaskPilot(assessmentTaskId);
        }

        private AssessmentTaskPilot fetchAssessmentTaskPilot(Guid assessmentTaskId)
        {
            var assessmentTask = _context.AssessmentTasks.OfType<AssessmentTaskPilot>().Include("SelectedAssessmentTasks").FirstOrDefault(a => a.Id == assessmentTaskId);
            if (assessmentTask == null)
            {
                throw new BusinessRuleException("Invalid Assessment Task Id");
            }
            return assessmentTask;
        }

        public IAssessmentTaskPilot EditAssessmentTaskPilot(Guid id, AssessmentTaskPilotDetails details)
        {
            return editAssessmentTaskPilot(id, details);
        }

        private AssessmentTaskPilot editAssessmentTaskPilot(Guid id, AssessmentTaskPilotDetails details)
        {
            var assessmentTask = fetchAssessmentTaskPilot(id);
            assessmentTask.Edit(details);
            _context.SaveChanges();
            return assessmentTask;
        }

        public void DeleteAssessmentTaskPilot(Guid id)
        {
            var assessmentTask = fetchAssessmentTaskPilot(id);
            assessmentTask.Delete(deleteEntity);
            _context.SaveChanges();
        }

        public IEnumerable<IAssessmentTaskPilot> FetchAllAssessmentTaskPilot()
        {
            return fetchAllAssessmentTaskPilot();
        }

        private List<AssessmentTaskPilot> fetchAllAssessmentTaskPilot()
        {
            return _context.AssessmentTasks.OfType<AssessmentTaskPilot>().Include("SelectedAssessmentTasks").ToList();
        }


        #endregion

        #region CRUD Theory Exam Format

        public ITheoryComponentFormat[][] FetchAllTheoryExamFormats()
        {
            ITheoryComponentFormat[][] result;

            var formats = _context.TheoryComponentFormats.Include("TheoryComponents").ToList();
            var pilotFormats = formats.OfType<TheoryComponentFormatPilot>().OrderByDescending(f => f.IsActive).ToArray();
            var packerFormats = formats.OfType<TheoryComponentFormatPacker>().OrderByDescending(f => f.IsActive).ToArray();

            result = new ITheoryComponentFormat[2][];

            result[0] = new ITheoryComponentFormat[pilotFormats.Length];
            result[0] = pilotFormats;

            result[1] = new ITheoryComponentFormat[packerFormats.Length];
            result[1] = packerFormats;

            return result;
        }

        public ITheoryComponentFormat FetchTheoryExamFormatById(Guid formatId)
        {
            return fetchTheoryExamFormatById(formatId);
        }

        private TheoryComponentFormat fetchTheoryExamFormatById(Guid formatId)
        {
            var format = _context.TheoryComponentFormats.Include("TheoryComponents").FirstOrDefault(f => f.Id == formatId);
            if (format == null)
            {
                throw new BusinessRuleException("Invalid Format ID");
            }
            return format;
        }

        public void CreateTheoryExamFormat(ExamType examType, int numberOfQuestions, int passMark, int timeLimit)
        {
            // Creates a theory exam manager with no associated data (i.e. existing formats or templates)
            examManager = ManagerFactory.CreateTheoryExamManager(examType);
            
            TheoryComponentFormat format;
            int availableQuestions;
            switch (examType)
            {
                case ExamType.PilotExam:
                    availableQuestions = _context.TheoryQuestions.OfType<TheoryQuestionPilot>().Count(q => q.IsActive);
                    format = examManager.CreateTheoryExamFormat(numberOfQuestions, passMark, timeLimit, availableQuestions);
                    break;
                case ExamType.PackerExam:
                    availableQuestions = _context.TheoryQuestions.OfType<TheoryQuestionPacker>().Count(q => q.IsActive);
                    format = examManager.CreateTheoryExamFormat(numberOfQuestions, passMark, timeLimit, availableQuestions);
                    break;
                default:
                    throw new BusinessRuleException("Invalid exam type provided");
            }
            
            _context.TheoryComponentFormats.Add(format);
            _context.SaveChanges();
        }

        public void EditTheoryExamFormat(Guid formatId, int numberOfQuestions, int passMark, int timeLimit)
        {
            var format = fetchTheoryExamFormatById(formatId);
            int availableQuestions;

            if (format is TheoryComponentFormatPilot)
            {
                availableQuestions = _context.TheoryQuestions.OfType<TheoryQuestionPilot>().Count(q => q.IsActive);
            }
            else
            {
                availableQuestions = _context.TheoryQuestions.OfType<TheoryQuestionPacker>().Count(q => q.IsActive);
            }

            format.Edit(numberOfQuestions, passMark, timeLimit, availableQuestions);
            _context.SaveChanges();
        }

        public void DeleteTheoryExamFormat(Guid formatId)
        {
            var format = fetchTheoryExamFormatById(formatId);
            format.Delete(deleteEntity);
            _context.SaveChanges();
        }

        public void SetActiveTheoryComponentFormat(Guid formatId)
        {
            if (!IsFormatActivationPossible(formatId))
            {
                throw new BusinessRuleException("Cannot activate Theory Format. Not enough questions for selected format");
            }

            var theoryComponentFormats = _context.TheoryComponentFormats.ToList();
            var newFormat = theoryComponentFormats.FirstOrDefault(f => f.Id == formatId);
            if (newFormat == null)
            {
                throw new BusinessRuleException("Invalid Format ID");
            }
            if (newFormat.GetType() == typeof(TheoryComponentFormatPilot))
            {
                var filteredFormats = theoryComponentFormats.OfType<TheoryComponentFormatPilot>().Where(f => f.IsActive).ToList();
                // Ensuring all formats are not active prior to activating only one.
                filteredFormats.ForEach(f => f.Deactivate());
            }
            else if (newFormat.GetType() == typeof(TheoryComponentFormatPacker))
            {
                var filteredFormats = theoryComponentFormats.OfType<TheoryComponentFormatPacker>().Where(f => f.IsActive).ToList();
                // Ensuring all formats are not active prior to activating only one.
                filteredFormats.ForEach(f => f.Deactivate());
            }
            else
            {
                throw new BusinessRuleException("Unknown theory component format");
            }

            newFormat.Activate();
            // TODO: Confirm that only one is active?

            _context.SaveChanges();
        }

        

        #endregion

        #region CRUD Examiner
        
        private Examiner fetchExaminer(Guid examinerId) 
        {
            return _context.People.OfType<Examiner>().Include("ExaminerAuthorities").Include("User").First(e => e.Id == examinerId);
        }

        private Examiner fetchExaminerToDelete(Guid examinerId)
        {
            return _context.People.OfType<Examiner>().Include("CandidatePilots").Include("CandidatePackers").Include("ExaminerAuthorities").Include("User").First(e => e.Id == examinerId);
        }

        public IExaminer FetchExaminer(Guid examinerId)
        {
            return fetchExaminer(examinerId);
        }

        // Used in examiner controller to fetch examiner based on User ID
        public IExaminer FetchExaminer(int userId)
        {
            var examiner = _context.People.OfType<Examiner>().Include("ExaminerAuthorities").Include("User").FirstOrDefault(e => e.UserId == userId);
            if (examiner == null)
            {
                throw new BusinessRuleException("Unknown Examiner Id");
            }
            return examiner;
        }

        public void CreateExaminer(ExaminerDetails examinerDetails)
        {
            Membership membership = new Membership();
            examinerDetails.UserName = examinerDetails.APFNumber;
            int userId = membership.RegisterExaminer(examinerDetails.UserName, examinerDetails.Password);
            if (userId == -1)
            {
                throw new BusinessRuleException(String.Format("APF number {0} already exists.", examinerDetails.APFNumber));
            }
            
            // TODO: Need to validate APF Number
            Examiner examiner = new Examiner(examinerDetails, userId);
            _context.People.Add(examiner);
            _context.SaveChanges();
        }

        public void EditExaminer(Guid examinerId, ExaminerDetails examinerDetails)
        {
            Examiner examiner = fetchExaminer(examinerId);
            examiner.EditExaminer(examinerDetails);
            _context.SaveChanges();

            if (examinerDetails.OldPassword != null && examinerDetails.Password != null)
            {
                Membership membership = new Membership();
                if (!membership.ChangePassword(examiner.Username, examinerDetails.OldPassword, examinerDetails.Password))
                {
                    throw new BusinessRuleException("Error changing password");
                }
            }
        }

        public void DeleteExaminer(Guid examinerId)
        {
            string username;
            Examiner examiner = fetchExaminerToDelete(examinerId);
            username = examiner.Username;
            examiner.Delete(deleteEntity);
            _context.SaveChanges();
           
            Membership membership = new Membership();
            if (!membership.DeleteExaminer(username))
            {
                throw new BusinessRuleException("Cannot delete the examiner from membership");
            }
        }

        public void EditExaminerActiveStatus(Guid examinerId, bool isActive)
        {
            Examiner examiner = fetchExaminer(examinerId);
            examiner.EditActiveStatus(isActive);
            _context.SaveChanges();
        }

        public IEnumerable<IExaminer> FetchAllExaminers()
        {
            return _context.People.OfType<Examiner>();
        }

        #endregion

        #region CRUD Pilot Practical Template

        public IPracticalComponentTemplatePilot FetchPracticalTemplatePilotById(Guid templateId)
        {
            return fetchPracticalTemplatePilotById(templateId);
        }

        private PracticalComponentTemplatePilot fetchPracticalTemplatePilotById(Guid templateId)
        {
            var template = _context.PracticalComponentTemplates.OfType<PracticalComponentTemplatePilot>().Include("AssessmentTaskPilots").Include("PracticalComponentPilots").FirstOrDefault(t => t.Id == templateId);
            if (template == null)
            {
                throw new BusinessRuleException("Invalid Template ID");
            }
            return template;
        }

        public Guid CreatePracticalComponentTemplatePilot(IEnumerable<Guid> taskIds)
        {
            examManager = ManagerFactory.CreatePracticalExamMananger(ExamType.PilotExam);
            var selectedTasks = fetchSelectedTasks(taskIds);
            var newTemplate = (examManager as ExamManagerPilot).CreatePracticalComponentTemplatePilot(selectedTasks);
            _context.PracticalComponentTemplates.Add(newTemplate);
            _context.SaveChanges();
            return newTemplate.Id;
        }

        public Guid EditPracticalComponentTemplatePilot(Guid templateId, IEnumerable<Guid> taskIds)
        {
            if (taskIds.Count() < 1)
            {
                throw new BusinessRuleException("You must select at least one task for a template.");
            }
            var template = fetchPracticalTemplatePilotById(templateId);
            var selectedTasks = fetchSelectedTasks(taskIds);
            template.Edit(selectedTasks);
            _context.SaveChanges();
            return template.Id;
        }

        private List<AssessmentTaskPilot> fetchSelectedTasks(IEnumerable<Guid> taskIds)
        {
            var allTasks = _context.AssessmentTasks.OfType<AssessmentTaskPilot>();
            var selectedTasks = new List<AssessmentTaskPilot>();
            foreach (var taskId in taskIds)
            {
                var task = allTasks.FirstOrDefault(t => t.Id == taskId);
                if (task == null)
                {
                    throw new BusinessRuleException("Invalid Task ID");
                }
                selectedTasks.Add(task);
            }
            return selectedTasks;
        }

        public void DeletePracticalTemplatePilot(Guid templateId)
        {
            var template = fetchPracticalTemplatePilotById(templateId);
            template.Delete(deleteEntity);
            _context.SaveChanges();
        }

        public void SetActivePracticalTemplatePilot(Guid templateId)
        {
            var practicalComponentTemplates = _context.PracticalComponentTemplates.OfType<PracticalComponentTemplatePilot>();
            var newTemplate = practicalComponentTemplates.FirstOrDefault(t => t.Id == templateId);
            if (newTemplate == null)
            {
                throw new BusinessRuleException("Invalid Template ID");
            }

            // Ensuring all formats are not active prior to activating only one.
            practicalComponentTemplates.Where(f => f.IsActive).ToList().ForEach(t => t.Deactivate());
            newTemplate.Activate();
            // TODO: Confirm that only one is active?

            _context.SaveChanges();
        }

        #endregion

        #region CRUD Packer Practical Template

        public void CreatePracticalComponentTemplatePacker(int numOfRequiredAssessmentTasks)
        {
            examManager = ManagerFactory.CreatePracticalExamMananger(ExamType.PackerExam);
            var template = (examManager as ExamManagerPacker).CreatePracticalComponentTemplatePacker(numOfRequiredAssessmentTasks);
            _context.PracticalComponentTemplates.Add(template);
            _context.SaveChanges();
        }

        public IPracticalComponentTemplatePacker FetchPracticalTemplatePackerById(Guid templateId)
        {
            return fetchPracticalTemplatePackerById(templateId);
        }

        private PracticalComponentTemplatePacker fetchPracticalTemplatePackerById(Guid templateId)
        {
            var template = _context.PracticalComponentTemplates.OfType<PracticalComponentTemplatePacker>().Include("PracticalComponentPackers").FirstOrDefault(t => t.Id == templateId);
            if (template == null)
            {
                throw new BusinessRuleException("Invalid Template ID");
            }
            return template;
        }

        public void EditPracticalComponentTemplatePacker(Guid templateId, int numOfRequiredAssessmentTasks)
        {
            var template = fetchPracticalTemplatePackerById(templateId);
            template.Edit(numOfRequiredAssessmentTasks);
            _context.SaveChanges();
        }

        public void DeletePracticalTemplatePacker(Guid templateId)
        {
            var template = fetchPracticalTemplatePackerById(templateId);
            template.Delete(deleteEntity);
            _context.SaveChanges();
        }

        public void SetActivePracticalTemplatePacker(Guid templateId)
        {
            var practicalComponentTemplates = _context.PracticalComponentTemplates.OfType<PracticalComponentTemplatePacker>();
            var newTemplate = practicalComponentTemplates.FirstOrDefault(t => t.Id == templateId);
            if (newTemplate == null)
            {
                throw new BusinessRuleException("Invalid Template ID");
            }

            // Ensuring all formats are not active prior to activating only one.
            practicalComponentTemplates.Where(f => f.IsActive).ToList().ForEach(t => t.Deactivate());
            newTemplate.Activate();
            // TODO: Confirm that only one is active?

            _context.SaveChanges();
        }

        #endregion

        //Do not expose this method to UI by putting its definition in IFacade. This function is called by email service callback ONLY - Pradipna
        //Can we add this to Finalise? Maybe using to determine if it has been sent or not (new status ExamArchieved)
        public void FinaliseExamUpdateStatus(Guid examId, bool success)
        {
            Exam exam = _context.Exams.First(e => e.Id == examId);
            exam.ExamStatus = (success) ? ExamStatus.ExamCompleted : ExamStatus.SendingEmailFailed;
            _context.SaveChanges();
        }
		
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        internal void deleteEntity<T>(T entity)
        {
            var dbSet = _context.Set(entity.GetType());
            dbSet.Remove(entity);
        }
    }
}

