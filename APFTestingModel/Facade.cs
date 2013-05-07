using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APFTestingMembership;

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

        public ICandidatePilot FetchPilot(Guid candidateId)
        {
            return _context.People.OfType<CandidatePilot>().Include("Address").First(c => c.Id == candidateId);
        }

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

        public IEnumerable<ISelectedAssessmentTask> FetchAssessmentTasksPilot(Guid examId)
        {
            var exam = _context.Exams.OfType<ExamPilot>().Include("PracticalComponentPilot")
                .Include("PracticalComponentPilot.SelectedAssessmentTasks")
                .Include("PracticalComponentPilot.SelectedAssessmentTasks.AssessmentTaskPilot")
                .FirstOrDefault(e => e.Id == examId);

            FinalisePractical(examId);

            return exam.SelectedAssessmentTasks;
        }
        
        #endregion


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

			_context.TheoryQuestions.Add(examManager.CreateTheoryQuestion(questionDetails));
			_context.SaveChanges();
		}

        public IEnumerable<ITheoryQuestion> FetchAllTheoryQuestionsPilot()
        {
            return _context.TheoryQuestions;
        }


		/*=========================*/
		/*      OTHER METHODS      */
		/*=========================*/

		#region Other Methods
		
      

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

        public void SubmitPackerPracticalResult(Guid examId, PackerPracticalResult result)
        {
            var exam = _context.Exams.OfType<ExamPacker>().Include("PracticalComponentPacker").Include("PracticalComponentPacker.AssessmentTaskPackers").First(e => e.Id == examId);
            exam.AddPracticalComponentResult(result);
            _context.SaveChanges();
        }

        public void EditPackerPracticalResult(Guid examId, Guid taskId, PackerPracticalResult result)
        {
            var exam = _context.Exams.OfType<ExamPacker>().Include("PracticalComponentPacker").Include("PracticalComponentPacker.AssessmentTaskPackers").First(e => e.Id == examId);

            AssessmentTaskPacker assessmentTask = exam.AssessmentTasks.First(t => t.Id == taskId);
            assessmentTask.Edit(result);
            _context.SaveChanges();
        }

        public void FinalisePractical(Guid examId)
        {
            // Change exam status to finalise practical component
            var exam = _context.Exams.First(e => e.Id == examId);
            exam.ExamStatus = ExamStatus.PracticalEntered;  
            //Or is it Exam Finalized? - Pradipna 
            //I think we will add it as a seperate action so the examiner can confirm final submission - Adam
            //... :) - Josh
            _context.SaveChanges();
        }

        public IEnumerable<IAssessmentTaskPacker> FetchAssessmentTasksPacker(Guid examId, out bool isCompetent)
        {
            var exam = _context.Exams.OfType<ExamPacker>().Include("PracticalComponentPacker").Include("PracticalComponentPacker.AssessmentTaskPackers").Include("PracticalComponentPacker.PracticalComponentTemplatePacker").First(e => e.Id == examId);
            isCompetent = exam.PracticalComponentIsCompetent;
            return exam.AssessmentTasks;
        }

        public IAssessmentTaskPacker FetchSingleAssessmentTaskPacker(Guid examId, Guid taskId)
        {
            var exam = _context.Exams.OfType<ExamPacker>().Include("PracticalComponentPacker").Include("PracticalComponentPacker.AssessmentTaskPackers").First(e => e.Id == examId);
            
            return exam.AssessmentTasks.First(at => at.Id == taskId);
        }

        public void EditPacker(Guid candidateId, CandidatePackerDetails details)
        {
            var candidate = _context.People.OfType<CandidatePacker>().First(c => c.Id == candidateId);
            candidate.Edit(details);
            _context.SaveChanges();
        }

        public void EditPilot(Guid candidateId, CandidatePilotDetails details)
        {
            var candidate = _context.People.OfType<CandidatePilot>().Include("Address").First(c => c.Id == candidateId);
            candidate.Edit(details);
            _context.SaveChanges();
        }

        #endregion

        /*=======================================*/
        /*   CREATE PRACTICAL ASSESSMENT TASKS   */
        /*=======================================*/

        #region CRUD Pilot Practical Assessment tasks

        public IAssessmentTaskPilot CreateAssessmentTaskPilot(AssessmentTaskPilotDetails details)
        {
            return (IAssessmentTaskPilot)createAssessmentTask(details);
        }

        private AssessmentTask createAssessmentTask(AssessmentTaskPilotDetails details)
        {
            examManager = ManagerFactory.CreatePracticalExamManangerPilot();
            AssessmentTask assessmentTask = (examManager as ExamManagerPilot).CreateAssessmentTask(details);
            _context.AssessmentTasks.Add(assessmentTask);
            _context.SaveChanges();
            return assessmentTask;
        }

        public IAssessmentTaskPilot FetchAssessmentTaskPilot(Guid id)
        {
            return fetchAssessmentTaskPilot(id);
        }

        private AssessmentTaskPilot fetchAssessmentTaskPilot(Guid id)
        {
            return _context.AssessmentTasks.OfType<AssessmentTaskPilot>().Include("SelectedAssessmentTasks").FirstOrDefault(a => a.Id == id);
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
            deleteAssessmentTaskPilot(id);
        }

        private void deleteAssessmentTaskPilot(Guid id)
        {
            try
            {
                _context.AssessmentTasks.Remove(fetchAssessmentTaskPilot(id));
            }
            catch (Exception)
            {
                throw new BusinessRuleException("Assessment task is used by one or more templates. It cannot be deleted.");
            }
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

            var formats = _context.TheoryComponentFormats.ToList();
            var pilotFormats = formats.OfType<TheoryComponentFormatPilot>().ToArray();
            var packerFormats = formats.OfType<TheoryComponentFormatPacker>().ToArray();

            result = new ITheoryComponentFormat[2][];

            result[0] = new ITheoryComponentFormat[pilotFormats.Length];
            result[0] = pilotFormats;

            result[1] = new ITheoryComponentFormat[packerFormats.Length];
            result[1] = packerFormats;

            return result;
        }

        public void CreateTheoryExamFormat(ExamType examType, int numberOfQuestions, int passMark, int timeLimit)
        {
            // Creates a theory exam manager with no associated data (i.e. existing formats or templates)
            examManager = ManagerFactory.CreateTheoryExamManager(examType);
            TheoryComponentFormat format;
            switch (examType)
            {
                case ExamType.PilotExam:
                    format = examManager.CreateTheoryExamFormat(numberOfQuestions, passMark, timeLimit);
                    break;
                case ExamType.PackerExam:
                    format = examManager.CreateTheoryExamFormat(numberOfQuestions, passMark, timeLimit);
                    break;
                default:
                    throw new BusinessRuleException("Invalid exam type provided");
            }
            
            _context.TheoryComponentFormats.Add(format);
            _context.SaveChanges();
        }

        public void EditTheoryExamFormat(Guid formatId, int numberOfQuestions, int passMark, int timeLimit)
        {
            var format = _context.TheoryComponentFormats.Include("TheoryComponents").FirstOrDefault(f => f.Id == formatId);
            if (format == null)
            {
                throw new BusinessRuleException("Invalid FormatID");
            }
            format.Edit(numberOfQuestions, passMark, timeLimit);
            _context.SaveChanges();
        }

        public void DeleteTheoryExamFormat(Guid formatId)
        {
            var format = _context.TheoryComponentFormats.Include("TheoryComponents").FirstOrDefault(f => f.Id == formatId);
            if (format == null)
            {
                throw new BusinessRuleException("Invalid FormatID");
            }
            format.Delete(this);
        }

        internal void deleteTheoryExamFormat(TheoryComponentFormat format)
        {
            _context.TheoryComponentFormats.Remove(format);
            _context.SaveChanges();
        }
        
        #endregion

        /*=====================*/
        /*   CREATE EXAMINER   */
        /*=====================*/

        #region CRUD Examiner
        
        private Examiner fetchExaminer(Guid examinerId) 
        {
            return _context.People.OfType<Examiner>().Include("ExaminerAuthorities").First(e => e.Id == examinerId);
        }

        public void CreateExaminer(ExaminerDetails examinerDetails)
        {
            Membership membership = new Membership();
            int userId = membership.RegisterExaminer(examinerDetails.UserName, examinerDetails.Password);
            Examiner examiner = new Examiner(examinerDetails, userId);
            _context.People.Add(examiner);
            _context.SaveChanges();
        }

        public void EditExaminer(Guid examinerId, ExaminerDetails examinerDetails)
        {
            Examiner examiner = fetchExaminer(examinerId);
            examiner.EditExaminer(examinerDetails);
            _context.SaveChanges();
        }

        public void DeleteExaminer(Guid examinerId)
        {
            Examiner examiner = fetchExaminer(examinerId);
            _context.People.Remove(examiner);
            _context.SaveChanges();
        }

        public void EditExaminerActiveStatus(Guid examinerId, bool isActive)
        {
            Examiner examiner = fetchExaminer(examinerId);
            examiner.EditActiveStatus(isActive);
            _context.SaveChanges();
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

