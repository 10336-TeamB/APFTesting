using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public class Facade : IFacade
    {
        private APFTestingDBEntities _context = new APFTestingDBEntities();
        private ExamManager examManager;

        private Candidate fetchCandidate(Guid candidateId)
        {
            Candidate candidate = (Candidate)_context.People.First(c => c.Id == candidateId);
            _context.Entry(candidate).Collection<Exam>("Exams").Load();
            return candidate;
        }

        

		//=====================================
		//      INITIATE THEORY COMPONENT 
		//=====================================
        
		#region Initiate Theory Component
        
        private void createExamManager(ExamType examType)
        {
            TheoryComponentFormat activeTheoryFormat;
            PracticalComponentTemplate activePracticalTemplate;

            if (examType == ExamType.PackerExam)
            {
                activeTheoryFormat = _context.TheoryComponentFormats.OfType<TheoryComponentFormatPacker>().FirstOrDefault(f => f.IsActive);
                activePracticalTemplate = _context.PracticalComponentTemplates.OfType<PracticalComponentTemplatePacker>().FirstOrDefault(t => t.IsActive);
            }
            else
            {
                activeTheoryFormat = _context.TheoryComponentFormats.OfType<TheoryComponentFormatPilot>().FirstOrDefault(f => f.IsActive);
                activePracticalTemplate = _context.PracticalComponentTemplates.OfType<PracticalComponentTemplatePilot>().FirstOrDefault(t => t.IsActive);
            }
            examManager = ManagerFactory.CreateExamManager(_context.TheoryQuestions.Include("Answers"), activeTheoryFormat, activePracticalTemplate, examType);
        }
        
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

			return exam.FetchCurrentQuestion();
		}
		
		private Guid CreateExam(Guid examinerId, Candidate candidate)
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
		
        #endregion


		//=========================
		//      FETCH METHODS 
		//=========================
		#region Fetch Methods

		public ITheoryComponentFormat FetchTheoryComponentFormat(Guid examId)
		{
			var exam = _context.Exams.Include("TheoryComponent").Include("TheoryComponent.TheoryComponentFormat").First(e => e.Id == examId);
			
			return exam.FetchTheoryComponentFormat();
		}

		#endregion



		private Exam fetchExam(Guid examId)
        {
            // Need to catch null value from FirstOrDefault
			var exam = _context.Exams.Include("TheoryComponent").Include("TheoryComponent.TheoryComponentFormat").Include("TheoryComponent.SelectedTheoryQuestions").Include("TheoryComponent.SelectedTheoryQuestions.TheoryQuestion").Include("TheoryComponent.SelectedTheoryQuestions.PossibleAnswers").Include("TheoryComponent.SelectedTheoryQuestions.TheoryQuestion.Answers").FirstOrDefault(e => e.Id == examId);
            //exam.OnStatusChanged();

			return exam;
        }

        public ISelectedTheoryQuestion FetchNextQuestion(Guid examId)
        {
            Exam exam = fetchExam(examId);
            ISelectedTheoryQuestion nextQuestion = exam.FetchNextQuestion();
            _context.SaveChanges();
            return nextQuestion;
        }

        public ISelectedTheoryQuestion FetchPreviousQuestion(Guid examId)
        {
            Exam exam = fetchExam(examId);
            ISelectedTheoryQuestion previousQuestion = exam.FetchPreviousQuestion();
            _context.SaveChanges();
            return previousQuestion;
        }

        public ISelectedTheoryQuestion FetchSpecificQuestion(Guid examId, int questionIndex) 
        {
            Exam exam = fetchExam(examId);

            if (questionIndex == 0 && exam.ExamStatus == ExamStatus.ExamCreated)
            {
                exam.StartTheoryExam();
            }

            ISelectedTheoryQuestion question = exam.FetchSpecificQuestion(questionIndex);
			
			_context.SaveChanges();
            return question;
        }

        

        public void AnswerQuestion(Guid examId, int questionIndex, int[] selectedAnswers, bool markForReview)
        {
            Exam exam = fetchExam(examId);
            exam.AnswerQuestion(questionIndex, selectedAnswers, markForReview);
            _context.SaveChanges();
        }

        public IEnumerable<ISelectedTheoryQuestion> FetchTheoryComponentSummary(Guid examId)
        {
            Exam exam = fetchExam(examId);
            return exam.SelectedTheoryQuestions.OrderBy(q => q.QuestionIndex);
        }

        public ITheoryComponent FetchTheoryComponentResult(Guid examId)
        {
            Exam exam = fetchExam(examId);
            return exam.FetchTheoryExamResult();
        }

        public void VoidExam(Guid examId)
        {
            Exam exam = fetchExam(examId);
            exam.VoidExam();
            _context.SaveChanges();
        }

        public IEnumerable<ICandidate> FetchCandidates(Guid examinerId)
        {
            //TODO: Work out how to do this in one DB query....
            // Return all candidates assocaiated with the examiner.
            var examiner = _context.People.Include("Candidates").OfType<Examiner>().First(e => e.Id == examinerId);
            //_context.Entry(examiner).Collection<Candidate>("Candidates").Load();
            foreach (var c in examiner.Candidates)
            {
                _context.Entry(c).Collection<Exam>("Exams").Load();
            }
            return examiner.Candidates;
        }

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
                    throw new Exception("ExamType invalid");
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

        public void SubmitTheoryComponent(Guid examId)
        {
            //TODO: Wrap in try-catch block
            var exam = _context.Exams.Include("TheoryComponent")
                .Include("TheoryComponent.SelectedTheoryQuestions")
                .Include("TheoryComponent.SelectedTheoryQuestions.PossibleAnswers")
                .Include("TheoryComponent.SelectedTheoryQuestions.PossibleAnswers.Answer")
                .Include("TheoryComponent.TheoryComponentFormat")
                .First(e => e.Id == examId);
            
            //TODO: Maybe this logic should be in Exam itself? - ADAM
            //Yeah, now it's done - Pradipna
            //exam.ExamStatus = (exam.TheoryComponentCompetency) ? ExamStatus.TheoryComponentCompleted : ExamStatus.TheoryComponentFailed;
            exam.SubmitTheoryComponent();

            _context.SaveChanges();
        }

        //Hook-in test method
        public string TestDBConnection()
        {
           return _context.TheoryQuestions.FirstOrDefault().Description;
        }

        // HACK- Temporary method for resetting the theory exam status for demonstration purposes
        public void ResetTheoryComponent()
        {
            var candidate = _context.People.Include("Exams").Include("Exams.TheoryComponent.SelectedTheoryQuestions")
                .Include("Exams.TheoryComponent.SelectedTheoryQuestions.PossibleAnswers")
                .Include("Exams.TheoryComponent.SelectedTheoryQuestions.PossibleAnswers.Answer").OfType<Candidate>().First(); 
            var exam = candidate.LatestExam;
            exam.TheoryComponent.SelectedTheoryQuestions.ToList()
                .ForEach(q => {
                    q.PossibleAnswers.ToList().ForEach(pa => pa.IsChecked = false);
                    q.IsMarkedForReview = false;
                    });
            exam.AdamsAwesomeResetHack();
            _context.SaveChanges();
        }


		#region Old Code

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

		#endregion


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

