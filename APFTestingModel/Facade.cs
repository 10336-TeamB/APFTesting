using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public class Facade : IFacade
    {
        private APFTestingDBEntities _context = new APFTestingDBEntities();
        private ExamManager examManager;



        /*=====================================*/
        /*      INITIATE THEORY COMPONENT      */
        /*=====================================*/
        
		#region Initiate Theory Component
        
        public Guid StartTheoryComponent(Guid examinerId, Guid candidateId)
        {
            var candidate = fetchCandidate(candidateId);
            
            return (candidate.NewExamPossible) ? CreateExam(examinerId, candidate) : candidate.LatestExamId;
        }

		public ISelectedTheoryQuestion ResumeTheoryComponent(Guid examId)
		{
            var exam = fetchExamForQuestionFetching(examId);

			return exam.FetchCurrentQuestion();
		}

        //REFACTORED
        private void createExamManager(ExamType examType)
        {
            TheoryComponentFormat activeTheoryFormat;
            PracticalComponentTemplate activePracticalTemplate;

            switch (examType)
            {

                case ExamType.PilotExam:
                    activeTheoryFormat = _context.TheoryComponentFormats.OfType<TheoryComponentFormatPilot>().FirstOrDefault(f => f.IsActive);
                    activePracticalTemplate = _context.PracticalComponentTemplates.Include("AssessmentTaskPilots").OfType<PracticalComponentTemplatePilot>().FirstOrDefault(t => t.IsActive);
                    break;
                case ExamType.PackerExam:
                    activeTheoryFormat = _context.TheoryComponentFormats.OfType<TheoryComponentFormatPacker>().FirstOrDefault(f => f.IsActive);
                    activePracticalTemplate = _context.PracticalComponentTemplates.OfType<PracticalComponentTemplatePacker>().FirstOrDefault(t => t.IsActive);
                    break;
                default:
                    throw new BusinessRuleException("Invalid exam type provided");
            }

            examManager = ManagerFactory.CreateExamManager(_context.TheoryQuestions.Include("Answers"), activeTheoryFormat, activePracticalTemplate, examType);
        }
		
        //REFACTORED
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
		public void ResetTheoryComponent()
		{
			var candidate = _context.People
				.Include("ExamPackers")
                .Include("ExamPackers.TheoryComponent")
                .Include("ExamPackers.TheoryComponent.SelectedTheoryQuestions")
                .Include("ExamPackers.TheoryComponent.SelectedTheoryQuestions.PossibleAnswers")
                .Include("ExamPackers.TheoryComponent.SelectedTheoryQuestions.PossibleAnswers.Answer")
				.OfType<CandidatePacker>().First();

			var exam = candidate.LatestExam;

			exam.TheoryComponent.SelectedTheoryQuestions.ToList()
				.ForEach(q =>
				{
					q.PossibleAnswers.ToList().ForEach(pa => pa.IsChecked = false);
					q.IsMarkedForReview = false;
				});
			exam.ResetTheoryComponent();
			_context.SaveChanges();
		}


        #endregion

        

        /*================================*/
        /*      SIT THEORY COMPONENT      */
        /*================================*/

        #region Sit Theory Component

        public ISelectedTheoryQuestion FetchNextQuestion(Guid examId)
        {
            var exam = fetchExamForQuestionFetching(examId);
            var question = exam.FetchNextQuestion();
            _context.SaveChanges();

            return question;
        }

        public ISelectedTheoryQuestion FetchPreviousQuestion(Guid examId)
        {
            var exam = fetchExamForQuestionFetching(examId);
            var question = exam.FetchPreviousQuestion();
            _context.SaveChanges();
            
            return question;
        }

        public ISelectedTheoryQuestion FetchSpecificQuestion(Guid examId, int questionIndex)
        {
            var exam = fetchExamForQuestionFetching(examId);
            var question = exam.FetchSpecificQuestion(questionIndex);
            _context.SaveChanges();

            return question;
        }

        public void AnswerQuestion(Guid examId, int questionIndex, int[] selectedAnswers, bool markForReview)
        {
			var exam = fetchExamForQuestionFetching(examId);

            exam.AnswerQuestion(questionIndex, selectedAnswers, markForReview);
            _context.SaveChanges();
        }

		public IEnumerable<ISelectedTheoryQuestion> FetchTheoryComponentSummary(Guid examId)
		{
			Exam exam = fetchExamForQuestionFetching(examId);
			return exam.SelectedTheoryQuestions.OrderBy(q => q.QuestionIndex);
		}

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

		public void VoidExam(Guid examId)
		{
			Exam exam = _context.Exams.First(e => e.Id == examId);
			exam.VoidExam();
			_context.SaveChanges();
		}

        #endregion



        /*=========================*/
        /*      FETCH METHODS      */
        /*=========================*/

        #region Fetch Methods

        public ITheoryComponentFormat FetchTheoryComponentFormat(Guid examId)
        {
            var exam = _context.Exams.Include("TheoryComponent").Include("TheoryComponent.TheoryComponentFormat").First(e => e.Id == examId);

            return exam.FetchTheoryComponentFormat();
        }
		
        public ISelectedTheoryQuestion FetchFirstQuestion(Guid examId)
        {
            var exam = fetchExamForQuestionFetching(examId);
            var question = exam.FetchFirstQuestion();
            _context.SaveChanges();

            return question;
        }
		
		public IEnumerable<ICandidate> FetchCandidates(Guid examinerId)
		{
            var examiner = _context.People.Include("CandidatePackers").Include("CandidatePilots").Include("CandidatePackers.ExamPackers").Include("CandidatePilots.ExamPilots").OfType<Examiner>().First(e => e.Id == examinerId);

            List<ICandidate> candidates = new List<ICandidate>();
            candidates.AddRange(examiner.CandidatePackers);
            candidates.AddRange(examiner.CandidatePilots);
            return candidates;
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

		public ITheoryComponent FetchTheoryComponentResult(Guid examId)
		{
			var exam = _context.Exams
						.Include("TheoryComponent")
						.Include("TheoryComponent.SelectedTheoryQuestions")
						.Include("TheoryComponent.SelectedTheoryQuestions.PossibleAnswers")
						.Include("TheoryComponent.SelectedTheoryQuestions.PossibleAnswers.Answer")
						.Include("TheoryComponent.TheoryComponentFormat")
						.First(e => e.Id == examId);

			return exam.FetchTheoryComponentResult();
		}

        public IEnumerable<ISelectedAssessmentTask> FetchAssessmentTasksPilot(Guid examId)
        {
            var exam = _context.Exams
                               .OfType<ExamPilot>()
                               .FirstOrDefault(e => e.Id == examId);
            List<SelectedAssessmentTask> selectedAssessmentTasks = _context.SelectedAssessmentTasks.Where(t => t.PracticalComponentId == exam.PracticalComponentId).ToList();

            return selectedAssessmentTasks;
        }
        
        #endregion



		/*=========================*/
		/*      OTHER METHODS      */
		/*=========================*/

		#region Other Methods
		
        //REFACTORED
		public ITheoryComponentFormat CreateTheoryComponentFormat(ExamType examType, int numberOfQuestions, int passMark)
		{
			switch (examType)
			{
				case ExamType.PilotExam:
					var theoryComponentFormatPilot = new TheoryComponentFormatPilot(numberOfQuestions, passMark);
					_context.TheoryComponentFormats.Add(theoryComponentFormatPilot);
					_context.SaveChanges();
					return theoryComponentFormatPilot;
				case ExamType.PackerExam:
					var theoryComponentFormatPacker = new TheoryComponentFormatPacker(numberOfQuestions, passMark);
					_context.TheoryComponentFormats.Add(theoryComponentFormatPacker);
					_context.SaveChanges();
					return theoryComponentFormatPacker;
				default:
                    throw new BusinessRuleException("Invalid exam type provided");
			}
		}

		public void SetActiveTheoryComponentFormat(Guid theoryComponentFormatId)
		{
			//TODO : Find all TheoryComponentFormat[type] and set as inactive then set one as active -- AL
			var theoryComponentFormat = _context.TheoryComponentFormats.FirstOrDefault(f => f.Id == theoryComponentFormatId).GetType();
			if (theoryComponentFormat.GetType() == typeof(TheoryComponentFormatPilot))
			{
				//_context.TheoryComponentFormats.Where(f => f)
			}
		}

        public Guid CreateCandidate(CandidatePilotDetails details, Guid createdBy)
        {
            CandidatePilot candidatePilot = new CandidatePilot(details, createdBy);
            _context.People.Add(candidatePilot);
            _context.SaveChanges();
            return candidatePilot.Id;
        }

        public Guid CreateCandidate(CandidatePackerDetails details, Guid createdBy)
        {
            CandidatePacker candidatePacker = new CandidatePacker(details, createdBy);
            _context.People.Add(candidatePacker);
           _context.SaveChanges();
            return candidatePacker.Id;
        }

        public void SubmitPilotPracticalResults(Guid examId, List<PilotPracticalResult> results)
        {
            var exam = _context.Exams.OfType<ExamPilot>().Include("PracticalComponentPilot").Include("PracticalComponentPilot.SelectedAssessmentTasks").First(e => examId == e.Id);

            var tasks = exam.SelectedAssessmentTasks;
            foreach (var r in results)
            {
                try
                {
                    tasks.First(t => t.Id == r.Id).RecordResult(r);
                }
                catch (ArgumentNullException e)
                {
                    //TODO: Log exception
                    throw new BusinessRuleException("Error while recording results. The requested result could not be found");
                }
            }
            _context.SaveChanges();
        }


        // TODO: These 3 methods need completing
        public void SubmitPackerPracticalResult(Guid examId, PackerPracticalResult result)
        {
            
        }

        public void FinalisePractical(Guid examId)
        {
            // Change exam status to finalise practical component

        }

        public IEnumerable<IAssessmentTaskPacker> FetchAssessmentTasksPacker(Guid examId)
        {

            return null;
        }

        #endregion
		

        //Hook-in test method
        public string TestDBConnection()
        {
           return _context.TheoryQuestions.FirstOrDefault().Description;
        }
		
        public void Dispose()
        {
            _context.Dispose();
        }

		#region Old Code


		//private Exam fetchExam(Guid examId)
		//{
		//	// Need to catch null value from FirstOrDefault
		//	var exam = _context.Exams.Include("TheoryComponent").Include("TheoryComponent.TheoryComponentFormat").Include("TheoryComponent.SelectedTheoryQuestions").Include("TheoryComponent.SelectedTheoryQuestions.TheoryQuestion").Include("TheoryComponent.SelectedTheoryQuestions.PossibleAnswers").Include("TheoryComponent.SelectedTheoryQuestions.TheoryQuestion.Answers").FirstOrDefault(e => e.Id == examId);
		//	//exam.OnStatusChanged();

		//	return exam;
		//}


		/*
        public Guid StartTheoryComponent(Guid examinerId, Guid candidateId)
        {

			var candidate = _context.People.Include("Exams").OfType<Candidate>().First(c => c.Id == candidateId);

            //var candidate = fetchCandidate(candidateId);

            
            //Not right now... - Pradipna
            return (candidate.NewExamPossible) ? CreateExam(examinerId, candidate) : candidate.LatestExamId;
        }

		public ISelectedTheoryQuestion ResumeTheoryComponent(Guid examId)
		{
			var exam = _context.Exams.Include("TheoryComponent")
				.Include("TheoryComponent.SelectedTheoryQuestions")
				.Include("TheoryComponent.SelectedTheoryQuestions.TheoryQuestion")
				.Include("TheoryComponent.SelectedTheoryQuestions.PossibleAnswers")
				.Include("TheoryComponent.SelectedTheoryQuestions.PossibleAnswers.Answer")
				.First(e => e.Id == examId);
		*/

		//public ISelectedTheoryQuestion ResumeTheoryExam(Guid examId)
		//{
		//	Exam exam = fetchExam(examId);
		//	ISelectedTheoryQuestion question = exam.FetchSpecificQuestion(exam.TheoryComponent.CurrentQuestionIndex);
		//	return question;
		//}

		//public Guid CreateExam(Guid examinerId, Guid candidateId, ExamType examType)
		//{
		//    createExamManager(examType);

		//    //HACK:
		//    //Candidate candidate = new CandidatePilot();
		//    //Candidate candidate = _context.Candidates.Include("Exams").First(c => c.id == candidateId);
		//    Candidate candidate = fetchCandidate(candidateId);

		//    Exam exam;
		//    if (candidate.LatestExam == null)
		//    {
		//        exam = examManager.GenerateExam(examinerId, candidateId);
		//        // TODO: We may not need this line, as the Exam is associated with context objects already (Format and Template)...
		//        _context.Exams.Add(exam);
		//        _context.SaveChanges();
		//    }
		//    else
		//    {
		//        exam = candidate.LatestExam;
		//    }

		//    return exam.Id;
		//}

		//public ISelectedTheoryQuestion FetchSpecificQuestion(Guid examId, int questionIndex) 
		//{
		//    Exam exam = fetchExam(examId);

		//    //if (questionIndex == 0 && exam.ExamStatus == ExamStatus.ExamCreated)
		//    //{
		//    //    exam.StartTheoryExam();
		//    //}

		//    ISelectedTheoryQuestion question = exam.FetchSpecificQuestion(questionIndex);

		//    _context.SaveChanges();
		//    return question;
		//}

		#endregion




    }
}

