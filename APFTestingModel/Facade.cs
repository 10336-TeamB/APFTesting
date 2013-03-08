using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public class Facade : IDisposable
    {
        private APFTestingDBEntities _context = new APFTestingDBEntities();
        private ExamManager examManager;

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
                activePracticalTemplate = _context.PracticalComponentTemplates.OfType<PracticalComponentTemplatePacker>().FirstOrDefault(t => t.IsActive);
            }
            examManager = ManagerFactory.CreateExamManager(_context.TheoryQuestions, activeTheoryFormat, activePracticalTemplate, examType);
        }

        public IExam CreateExam(Guid examinerId, Guid candidateId, ExamType examType)
        {
            createExamManager(examType);

            Exam exam = examManager.GenerateExam(candidateId, examinerId);
            _context.Exams.Add(exam);
            _context.SaveChanges();
            return exam;
        }

        private Exam fetchExam(Guid examId)
        {
            
            return _context.Exams.Include("TheoryComponent").Include("TheoryComponent.SelectedTheoryQuestions").Include("TheoryComponent.SelectedTheoryQuestions.TheoryQuestion").Include("TheoryComponent.SelectedTheoryQuestions.TheoryQuestion.PossibleAnswers").FirstOrDefault(e => e.Id == examId);
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
            ISelectedTheoryQuestion question = exam.FetchSpecificQuestion(questionIndex);
            _context.SaveChanges();
            return question;
        }

        public void SelectAnswers(Guid examId, List<Guid> selectedAnswer, bool isMarkedForReview)
        {
            Exam exam = fetchExam(examId);
            exam.SelectAnswers(selectedAnswer, isMarkedForReview);
            _context.SaveChanges();
        }

        public IEnumerable<ISelectedTheoryQuestion> FetchTheoryComponentSummary(Guid examId)
        {
            Exam exam = fetchExam(examId);
            return exam.SelectedTheoryQuestions;
        }

        public ITheoryComponentResult FetchTheoryComponentResult(Guid examId)
        {
            Exam exam = fetchExam(examId);
            return exam.TheoryComponent;
        }

        public void VoidExam(Guid examId)
        {
            Exam exam = fetchExam(examId);
            exam.ExamStatusId = (int)ExamStatus.ExamVoided;
            _context.SaveChanges();
        }

        #region AddedByAlanAndAdam
        public IEnumerable<ICandidate> FetchCandidates(Guid examinerId)
        {
            // Return all candidates assocaiated with the examiner.

            // Returning dummy Candidate
            yield return new Candidate();
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
    }
}

