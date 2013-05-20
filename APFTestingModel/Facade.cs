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
        /*      FINALISE EXAM      */
        /*=========================*/

        #region Finalise Exam

        internal Exam fetchExam(Guid examId, ExamType examType)
        {

            Exam exam;
            if (examType == ExamType.PackerExam)
            {
                exam = _context.Exams.Include("TheoryComponent").Include("TheoryComponent.TheoryComponentFormat").OfType<ExamPacker>().Include("CandidatePacker").Include("PracticalComponentPacker").Include("PracticalComponentPacker.PracticalComponentTemplatePacker").FirstOrDefault(e => e.Id == examId);
            }
            else
            {
                exam = _context.Exams.Include("TheoryComponent").Include("TheoryComponent.TheoryComponentFormat").OfType<ExamPacker>().Include("CandidatePilot").Include("PracticalComponentPilot").Include("PracticalComponentPilot.PracticalComponentTemplatePilot").FirstOrDefault(e => e.Id == examId);
            }

            if (exam == null)
            {
                throw new BusinessRuleException("Exam not found");
            }
            return exam;
        }

        public void FinaliseExam(Guid examId, ExamType examType)
        {
            Exam exam = fetchExam(examId, examType);
            //Create new report
            //Send report
            exam.FinaliseExam();

        }

        #endregion 


        /*=========================*/
        /*      FETCH METHODS      */
        /*=========================*/

        #region Fetch Methods

        public ITheoryComponentFormat FetchTheoryComponentFormatForExam(Guid examId)
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

            return exam.SelectedAssessmentTasks;
        }

        public IEnumerable<IPracticalComponentTemplatePilot> FetchAllPracticalComponentTemplatePilots()
        {
            return _context.PracticalComponentTemplates.OfType<PracticalComponentTemplatePilot>().Include("PracticalComponentPilots").Include("AssessmentTaskPilots").OrderByDescending(t => t.IsActive).ToList();
        }

        public IEnumerable<IPracticalComponentTemplatePacker> FetchAllPracticalComponentTemplatePackers()
        {
            return _context.PracticalComponentTemplates.OfType<PracticalComponentTemplatePacker>().Include("PracticalComponentPackers").OrderByDescending(t => t.IsActive).ToList();
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

			var newQuestion = examManager.CreateTheoryQuestion(questionDetails);

			_context.TheoryQuestions.Add(newQuestion);
			_context.SaveChanges();
		}

		//
        public IEnumerable<ITheoryQuestion> FetchAllTheoryQuestionsPilot()
        {
            return _context.TheoryQuestions.OfType<TheoryQuestionPilot>().Include("SelectedTheoryQuestions").ToList();
        }

		public IEnumerable<ITheoryQuestion> FetchAllTheoryQuestionsPacker()
		{
			return _context.TheoryQuestions.OfType<TheoryQuestionPacker>().Include("SelectedTheoryQuestions").ToList();
		}


        public ITheoryQuestion FetchTheoryQuestion(Guid questionId)
        {
            var question = _context.TheoryQuestions.Include("Answers").Include("SelectedTheoryQuestions").First(q => q.Id == questionId);
			
			question.Answers = question.Answers.OrderBy(a => a.DisplayOrderIndex).ToList();

			

			return question;
        }

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

        public void DeleteTheoryQuestion(Guid questionId)
        {
            var question = _context.TheoryQuestions.Include("Answers").Include("SelectedTheoryQuestions").First(q => q.Id == questionId);
            question.Delete(deleteEntity, deleteEntity);

            _context.SaveChanges();
        }

        public void ToggleTheoryQuestionActivation(Guid questionId)
        {
            var question = _context.TheoryQuestions.First(q => q.Id == questionId);
            question.toggleActivation();

            _context.SaveChanges();
        }


        //public void DeleteTheoryQuestion(Guid questionId)
        //{
        //    //var exam = _context.Exams.Include("TheoryComponent").Include("TheoryComponent.TheoryComponentFormat").First(e => e.Id == examId);
        //    var question = _context.TheoryQuestions.Include("Answers").First(q => q.Id == questionId);


        //}
        //internal void DeleteTheoryQuestion(TheoryQuestion question)
        //{

        //}
        //internal void DeleteAnswer(Answer answer)
        //{

        //}

		/*=========================*/
		/*      OTHER METHODS      */
		/*=========================*/

		#region Other Methods
		
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
            exam.SubmitPilotPracticalResults(results);
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

            exam.EditPackerPracticalResult(taskId, result);
            _context.SaveChanges();
        }

        public void FinalisePractical(Guid examId)
        {
            var exam = _context.Exams.First(e => e.Id == examId);
            exam.FinalisePractical();
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

        public bool Login(string username, string password, bool rememberMe)
        {
            Membership membership = new Membership();
            return membership.Login(username, password, rememberMe);
        }

        public void Logout()
        {
            Membership membership = new Membership();
            membership.Logout();
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
            examManager = ManagerFactory.CreatePracticalExamMananger(ExamType.PilotExam);
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
            var assessmentTask = _context.AssessmentTasks.OfType<AssessmentTaskPilot>().Include("SelectedAssessmentTasks").FirstOrDefault(a => a.Id == id);
            if (assessmentTask == null)
            {
                throw new BusinessRuleException("Invalid AssessmentTaskId");
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
            var format = fetchTheoryExamFormatById(formatId);
            format.Edit(numberOfQuestions, passMark, timeLimit);
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
            var theoryComponentFormats = _context.TheoryComponentFormats.ToList();
            var newFormat = theoryComponentFormats.FirstOrDefault(f => f.Id == formatId);
            if (newFormat == null)
            {
                throw new BusinessRuleException("Invalid FormatID");
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

        /*=====================*/
        /*   CREATE EXAMINER   */
        /*=====================*/

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

        public void CreateExaminer(ExaminerDetails examinerDetails)
        {
            Membership membership = new Membership();
            examinerDetails.UserName = examinerDetails.APFNumber;
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
           
            Membership membership = new Membership();
            if (!membership.DeleteExaminer(username))
            {
                throw new BusinessRuleException("Cannot delete the examiner from membership");
            }
            _context.SaveChanges();
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
            var template = _context.PracticalComponentTemplates.OfType<PracticalComponentTemplatePilot>().Include("AssessmentTaskPilots").FirstOrDefault(t => t.Id == templateId);
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
            var template = _context.PracticalComponentTemplates.OfType<PracticalComponentTemplatePilot>().FirstOrDefault(t => t.Id == templateId);
            if (template == null)
            {
                throw new BusinessRuleException("Invalid Template ID");
            }
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
                throw new BusinessRuleException("Invalid FormatID");
            }

            // Ensuring all formats are not active prior to activating only one.
            practicalComponentTemplates.Where(f => f.IsActive).ToList().ForEach(t => t.Deactivate());
            newTemplate.Activate();
            // TODO: Confirm that only one is active?

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

        public void TestCode()
        {
            IEnumerable<TheoryQuestion> questions = _context.TheoryQuestions.Include("SelectedTheoryQuestions").ToList();

            
            foreach (var question in questions)
            {
                if (question.editableOrDeletable == true)
                {
                    Console.WriteLine("{0}\n\n",question.Description);
                }
            }

            Console.Read();
        }

        internal void deleteEntity<T>(T entity)
        {
            var dbSet = _context.Set(entity.GetType());
            dbSet.Remove(entity);
            //_context.SaveChanges();
        }
    }
}

