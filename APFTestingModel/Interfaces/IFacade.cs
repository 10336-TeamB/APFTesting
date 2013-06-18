using System;
using System.Collections.Generic;

namespace APFTestingModel
{
    /// <summary>
    /// Interface that exposes Facade
    /// </summary>
    public interface IFacade : IDisposable
    {
        /// <summary>
        /// Answer the specific question pointed by the question index
        /// </summary>
        /// <param name="examId">Guid id of the exam in progress</param>
        /// <param name="questionIndex">Question index of the question to be fetched</param>
        /// <param name="selectedAnswers">Answer index</param>
        /// <param name="markForReview">True if question was marked for review else false</param>
        void AnswerQuestion(Guid examId, int questionIndex, int[] selectedAnswers, bool markForReview);
        /// <summary>
        /// Checks whether or not the candidate has any incomplete exam and returns the incomplete exam. If candidate doesn't have any incomplete exam, then it creates a new exam and return it.
        /// </summary>
        /// <param name="examinerId">Guid Id of the examiner who created the exam</param>
        /// <param name="candidateId">Guid id of the candidate who is going to take the exam</param>
        /// <returns>Guid id of the exam</returns>
		Guid StartTheoryComponent(Guid examinerId, Guid candidateId);
        //ITheoryComponentFormat CreateTheoryComponentFormat(ExamType examType, int numberOfQuestions, int passMark);

        /// <summary>
        /// Retrieves a list of candidates for the examiner with the id of examinerId
        /// </summary>
        /// <param name="examinerId">Guid id of the examiner</param>
        /// <returns>Readonly list of the candidates</returns>
		IEnumerable<ICandidate> FetchCandidates(Guid examinerId);
        /// <summary>
        /// Fetches the first question of the exam. 
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
        /// <returns>First question of the exam</returns>
        ISelectedTheoryQuestion FetchFirstQuestion(Guid examId);
        /// <summary>
        /// Fetches the next question pointed by the question index of the exam that is in progress
        /// </summary>
        /// <param name="examId">Guid id of the exam in progress</param>
        /// <returns>The next question</returns>
        ISelectedTheoryQuestion FetchNextQuestion(Guid examId);
        /// <summary>
        /// Fetches the previous question pointed by the question index of the exam that is in progress
        /// </summary>
        /// <param name="examId">Guid id of the exam in progress</param>
        /// <returns>The previous question</returns>
        ISelectedTheoryQuestion FetchPreviousQuestion(Guid examId);

        /// <summary>
        /// Fetches the specific question pointed by the questionIndex passed in the parameter
        /// </summary>
        /// <param name="examId">Guid id of the exam in progress</param>
        /// <param name="questionIndex">Question index of the question to be fetched</param>
        /// <returns>The fetched question</returns>
        ISelectedTheoryQuestion FetchSpecificQuestion(Guid examId, int questionIndex);
        /// <summary>
        /// Fetches the theory component format of the particular exam
        /// </summary>
        /// <param name="examId">Guid id of the exam that the theory component format belongs to</param>
        /// <returns>Theory component format that was fetched</returns>
        ITheoryComponentFormat FetchTheoryComponentFormatForExam(Guid examId);
        /// <summary>
        /// Resumes the Theory Component part of the incomplete exam
        /// </summary>
        /// <param name="examId">Guid id of the incomplete exam</param>
        /// <returns>The question that is pointed by the current question index counter</returns>
        ISelectedTheoryQuestion ResumeTheoryComponent(Guid examId);
        /// <summary>
        /// Fetches the result of theory component part of the exam
        /// </summary>
        /// <param name="examId">Guid id of the exam that we want theory componenet of</param>
        /// <returns>Theory component of the exam</returns>
        ITheoryComponent FetchTheoryComponentResult(Guid examId);

        //Guid StartExam(Guid examinerId, Guid candidateId);
        //ISelectedTheoryQuestion ResumeTheoryExam(Guid examId);

        /// <summary>
        /// Creates a Pilot candidate
        /// </summary>
        /// <param name="details">Details such as Name, APF Number etc</param>
        /// <param name="createdBy">Guid id of the examiner who created the candidate</param>
        /// <returns>Guid id of the newly created examiner</returns>
        Guid CreateCandidate(CandidatePilotDetails details, Guid createdBy);
        /// <summary>
        /// Creates a Packer candidate
        /// </summary>
        /// <param name="details">Details such as Name, APF Number etc</param>
        /// <param name="createdBy">Guid id of the examiner who created the candidate</param>
        /// <returns>Guid id of the newly created examiner</returns>
        Guid CreateCandidate(CandidatePackerDetails details, Guid createdBy);

        /// <summary>
        /// Fetched the summary of the theory component of the specific exam
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
        /// <returns>Readonly list of the theory questions</returns>
        IEnumerable<ISelectedTheoryQuestion> FetchTheoryComponentSummary(Guid examId);
        /// <summary>
        /// Submits the theory component of the exam by changing its status to Passed or Failed
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
        void SubmitTheoryComponent(Guid examId);

        /// <summary>
        /// Fetches the practical assessment task from an exam 
        /// </summary>
        /// <param name="examId">Guid id of the exam to fetch assessment task from</param>
        /// <returns>Assessment task of the exam</returns>
        IEnumerable<ISelectedAssessmentTask> FetchAssessmentTasksPilot(Guid examId);
        /// <summary>
        /// Fetches the assessment tasks of the packer exam
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
        /// <param name="isCompetent">Referenced variable that returns whether or not the packer candidate has passed the practical assessment</param>
        /// <param name="requiredNumberOfTasks">Referenced variable that returns how many tasks are required to pass the practical component</param>
        /// <returns>Readonly list of the practical assessment tasks of the packer exam</returns>
        IEnumerable<IAssessmentTaskPacker> FetchAssessmentTasksPacker(Guid examId, out bool isCompetent, out int requiredNumberOfTasks);
        /// <summary>
        /// Retrieves a specific practical assessment task of the packer exam
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
        /// <param name="taskId">Guid id of the task</param>
        /// <returns>The fetched assessment task</returns>
        IAssessmentTaskPacker FetchSingleAssessmentTaskPacker(Guid examId, Guid taskId);

        /// <summary>
        /// Checks whether or not the theory exam format can be activated and if it can be activated, activates it otherwise throws an exception
        /// </summary>
        /// <param name="formatId">Guid id of the format being activated</param>
        void SetActiveTheoryComponentFormat(Guid formatId);
        /// <summary>
        /// Voids an exam by changing its status to Voided
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
        /// <param name="username">Username of the examiner who is voiding the exam</param>
        /// <param name="password">Password of the examiner who is voiding the exam</param>
        void VoidExam(Guid examId, string username, string password);
        /// <summary>
        /// Reset exam (used as a hack while testing our system)
        /// </summary>
        /// <param name="examId">Exam Id</param>
        void ResetTheoryComponent(Guid examId);

        /// <summary>
        /// Submits the practical component results of the pilot candidate and updates the exam status
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
        /// <param name="results">Readonly list of the results</param>
        void SubmitPilotPracticalResults(Guid examId, IEnumerable<PilotPracticalResult> results);
        /// <summary>
        /// Submits the practical component results of the packer candidate and updates the exam status
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
        /// <param name="results">Readonly list of the results</param>
        void SubmitPackerPracticalResult(Guid examId, PackerPracticalResult result);
        /// <summary>
        /// Edits a specific task in the practical component of the packer exam
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
        /// <param name="taskId">Guid id of the task to be updated</param>
        /// <param name="result">Result of the task</param>
        void EditPackerPracticalResult(Guid examId, Guid taskId, PackerPracticalResult result);

        /// <summary>
        /// Finalises the practical component by changing its exam status
        /// </summary>
        /// <param name="examId">Guid id of the exam</param>
        void FinalisePractical(Guid examId);

        /// <summary>
        /// Fetches the packer candidate
        /// </summary>
        /// <param name="candidateId">Guid id of the candidate we want to fetch</param>
        /// <returns>Candidate that was fetched</returns>
        ICandidatePacker FetchPacker(Guid candidateId);
        /// <summary>
        /// Fetches the pilot candidate
        /// </summary>
        /// <param name="candidateId">Guid id of the candidate we want to fetch</param>
        /// <returns>Candidate that was fetched</returns>
        ICandidatePilot FetchPilot(Guid candidateId);
        /// <summary>
        /// Edits the specific pilot candidate
        /// </summary>
        /// <param name="candidateId">Guid of the pilot candidate</param>
        /// <param name="details">Pilot candidate details such as Name, APF Number etc</param>
        void EditPilot(Guid candidateId, CandidatePilotDetails details);
        /// <summary>
        /// Edits the specific packer candidate
        /// </summary>
        /// <param name="candidateId">Guid of the packer candidate</param>
        /// <param name="details">Packer candidate details such as Name, APF Number etc</param>
        void EditPacker(Guid candidateId, CandidatePackerDetails details);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        IAssessmentTaskPilot CreateAssessmentTaskPilot(AssessmentTaskPilotDetails details);
        /// <summary>
        /// Edits a specific practical assessment task of pilot exam
        /// </summary>
        /// <param name="id">Guid id of the assessment task</param>
        /// <param name="details">Contains the result and details of assessment task</param>
        /// <returns>Assessment task that was edited</returns>
        IAssessmentTaskPilot EditAssessmentTaskPilot(Guid id, AssessmentTaskPilotDetails details);
        /// <summary>
        /// Deletes a specific assessment task of pilot exam
        /// </summary>
        /// <param name="id">Guid id of the assessment task that needs to be deleted</param>
        void DeleteAssessmentTaskPilot(Guid id);
        /// <summary>
        /// Returns a list of all the practical assessment task for pilot exam
        /// </summary>
        /// <returns>Readonly list of all the assessment task for pilot exam</returns>
        IEnumerable<IAssessmentTaskPilot> FetchAllAssessmentTaskPilot();
        /// <summary>
        /// Fetches specific practical assessment task of pilot exam
        /// </summary>
        /// <param name="assessmentTaskId">Guid id of the practical assessment task</param>
        /// <returns>Practical assessment task that was retrieved</returns>
        IAssessmentTaskPilot FetchAssessmentTaskPilot(Guid assessmentTaskId);

        /// <summary>
        /// Retrieves a list of all the theory questions for pilot
        /// </summary>
        /// <returns>Readonly list of all the questions for pilot</returns>
        IEnumerable<ITheoryQuestion> FetchAllTheoryQuestionsPilot();

        /// <summary>
        /// Retrieves a list of all the practical component template for the pilot candidates
        /// </summary>
        /// <returns>Readonly list of all the practical component template for the pilot candidates</returns>
        IEnumerable<IPracticalComponentTemplatePilot> FetchAllPracticalComponentTemplatePilots();
        /// <summary>
        /// Retrieves a list of all the practical component template for the packer candidates
        /// </summary>
        /// <returns>Readonly list of all the practical component template for the packer candidates</returns>
        IEnumerable<IPracticalComponentTemplatePacker> FetchAllPracticalComponentTemplatePackers();

        /// <summary>
        /// Creates a new examiner
        /// </summary>
        /// <param name="examinerDetails">Details such as Name, APF Number etc of the examiner</param>
        void CreateExaminer(ExaminerDetails examinerDetails);
        /// <summary>
        /// Edits a specific examiner
        /// </summary>
        /// <param name="examinerId">Guid id of the examiner</param>
        /// <param name="examinerDetails">Details such as Name, APF Number etc of the examiner</param>
        void EditExaminer(Guid examinerId, ExaminerDetails examinerDetails);
        /// <summary>
        /// Deletes a specific examiner
        /// </summary>
        /// <param name="examinerId">Guid id of the examiner that needs to be deleted</param>
        void DeleteExaminer(Guid examinerId);
        /// <summary>
        /// Edits the active status of the examiner
        /// </summary>
        /// <param name="examinerId">Guid id of the examiner</param>
        /// <param name="isActive">True if we want to activate the examiner otherwise false</param>
        void EditExaminerActiveStatus(Guid examinerId, bool isActive);

        /// <summary>
        /// Retrieves all the theory component format from the database
        /// </summary>
        /// <returns>2 dimensional array where the '0' index contains pilot formats while '1' index contains packer formats</returns>
        ITheoryComponentFormat[][] FetchAllTheoryExamFormats();
        /// <summary>
        /// Fetches a specific theory exam format
        /// </summary>
        /// <param name="formatId">Guid id of the format</param>
        /// <returns>Theory component format that was retrieved</returns>
        ITheoryComponentFormat FetchTheoryExamFormatById(Guid formatId);
        /// <summary>
        /// Creates a new theory component format
        /// </summary>
        /// <param name="examType">Type of the exam for which the format is being created</param>
        /// <param name="numberOfQuestions">Total number of questions for the theory exam</param>
        /// <param name="passMark">Pass Mark for the theory exam</param>
        /// <param name="timeLimit">Time limit for the theory exam (Unused by the system right now)</param>
        void CreateTheoryExamFormat(ExamType examType, int numberOfQuestions, int passMark, int timeLimit);
        /// <summary>
        /// Edits a specific theory component format
        /// </summary>
        /// <param name="formatId">Guid id of the format being edited</param>
        /// <param name="numberOfQuestions">Number of question for the theory exam</param>
        /// <param name="passMark">Pass Mark for the theory exam</param>
        /// <param name="timeLimit">Time limit for the theory exam (Unused by the system right now)</param>
        void EditTheoryExamFormat(Guid formatId, int numberOfQuestions, int passMark, int timeLimit);
        /// <summary>
        /// Deletes a specific theory component format
        /// </summary>
        /// <param name="formatId">Guid id of the format being deleted</param>
        void DeleteTheoryExamFormat(Guid formatId);

        /// <summary>
        /// Fetches a specific practical template for pilot exam
        /// </summary>
        /// <param name="templateId">Guid id of the template</param>
        /// <returns>Practical template that was fetched</returns>
        IPracticalComponentTemplatePilot FetchPracticalTemplatePilotById(Guid templateId);
        /// <summary>
        /// Creates practical component template for pilot exam
        /// </summary>
        /// <param name="taskIds">List of task that will be added to the newly created practical template</param>
        /// <returns>Guid id of the new practical template</returns>
        Guid CreatePracticalComponentTemplatePilot(IEnumerable<Guid> taskIds);
        /// <summary>
        /// Modifies the list of all the tasks of a specific practical component template for pilot exam
        /// </summary>
        /// <param name="templateId">Guid id of the template that needs to be edited</param>
        /// <param name="taskIds">List of tasks that will be in the practical component template</param>
        /// <returns>Guid id of the practical template that was modified</returns>
        Guid EditPracticalComponentTemplatePilot(Guid templateId, IEnumerable<Guid> taskIds);
        /// <summary>
        /// Deletes a specific practical component template
        /// </summary>
        /// <param name="templateId">Guid id of the template</param>
        void DeletePracticalTemplatePilot(Guid templateId);
        /// <summary>
        /// Checks whether or not the practical template can be activated and if it can be activated, activates it otherwise throws an exception
        /// </summary>
        /// <param name="templateId">Guid id of the template</param>
        void SetActivePracticalTemplatePilot(Guid templateId);

        /// <summary>
        /// Fetches a specific practical template for packer exam
        /// </summary>
        /// <param name="templateId">Guid id of the template</param>
        /// <returns>Practical template that was retrieved</returns>
        IPracticalComponentTemplatePacker FetchPracticalTemplatePackerById(Guid templateId);
        /// <summary>
        /// Creates practical component template for packer exam
        /// </summary>
        /// <param name="numOfRequiredAssessmentTasks">Number of assessment task required to successfully complete the practical component of the packer exam</param>
        void CreatePracticalComponentTemplatePacker(int numOfRequiredAssessmentTasks);
        /// <summary>
        /// Modifies a specific practical component template for packer exam
        /// </summary>
        /// <param name="templateId">Guid id of the template</param>
        /// <param name="numOfRequiredAssessmentTasks">Number of assessment task required to successfully complete the practical component of the packer exam</param>
        void EditPracticalComponentTemplatePacker(Guid templateId, int numOfRequiredAssessmentTasks);
        /// <summary>
        /// Deletes a specific practical component template for packer exam
        /// </summary>
        /// <param name="templateId">Guid id of the template</param>
        void DeletePracticalTemplatePacker(Guid templateId);
        /// <summary>
        /// Activates a specific practical component template for packer exam
        /// </summary>
        /// <param name="templateId">Guid id of the template</param>
        void SetActivePracticalTemplatePacker(Guid templateId);

        /// <summary>
        /// Creates a theory question for a particular exam type and adds it to the database
        /// </summary>
        /// <param name="questionDetails">Data structure which contains description, options and correct answers of the question that is being created</param>
        /// <param name="examType">Exam type of the question that is being created</param>
		void CreateTheoryQuestion(TheoryQuestionDetails questionDetails, ExamType examType);
        /// <summary>
        /// Fetches all the examiners in the database
        /// </summary>
        /// <returns>Readonly list of all the examiner in the database</returns>
        IEnumerable<IExaminer> FetchAllExaminers();
        /// <summary>
        /// Fetches a specific examiner
        /// </summary>
        /// <param name="examinerId">Guid id of the examiner</param>
        /// <returns>Examiner that was retrieved</returns>
        IExaminer FetchExaminer(Guid examinerId);
        /// <summary>
        /// Fetches a specific examiner based on their User Id
        /// </summary>
        /// <param name="userId">Userid of the examiner</param>
        /// <returns>Examiner that was retrieved</returns>
        IExaminer FetchExaminer(int userId);

        /// <summary>
        /// Fetches theory question
        /// </summary>
        /// <param name="questionId">Guid id of the theory question to be fetched</param>
        /// <returns>Theory question that was fetched</returns>
        ITheoryQuestion FetchTheoryQuestion(Guid questionId);
        /// <summary>
        /// Edits theory question
        /// </summary>
        /// <param name="questionDetails">Data structure which contains updated description, options and correct answers of the question that is being edited</param>
        /// <param name="questionId">Guid id of the question to be edited</param>
        void EditTheoryQuestion(TheoryQuestionDetails questionDetails, Guid questionId);

        /// <summary>
        /// Logs in users to the system
        /// </summary>
        /// <param name="username">Username of the user that is logging in</param>
        /// <param name="password">Password of the user that is logging in</param>
        /// <param name="rememberMe">If set to true, temporatily stores credentials</param>
        /// <returns>Success or failure while logging the user to the system</returns>
        bool Login(string username, string password, bool rememberMe);

        /// <summary>
        /// Logs out the user from the system
        /// </summary>
        void Logout();

        /// <summary>
        /// Deletes theory question if it is not referenced by any exam otherwise throws an exception
        /// </summary>
        /// <param name="questionId">Guid id of the question to be deleted</param>
        void DeleteTheoryQuestion(Guid questionId, ExamType examType, out string imagePath);

        /// <summary>
        /// Toggles the activation status of the question
        /// </summary>
        /// <param name="questionId">Guid id of the question</param>
        void ToggleTheoryQuestionActivation(Guid questionId, ExamType examType);

        /// <summary>
        /// Changes the exam status to 'EmailInProgress' and sends an asynchronous message to WCF email service for sending the exam report to APF Headquaters. WCF service will trigger a callback when it has finished sending email and if it failed to send an email, exam status is changed to 'SendingEmailFailed' otherwise the exam status is changed to 'ExamCompleted'
        /// </summary>
        /// <param name="examId">Guid id of the exam that needs to be finalised</param>
        /// <param name="examType">Exam type of the exam that needs to be finalised</param>
        void FinaliseExam(Guid examId, ExamType examType);

        /// <summary>
        /// Retrieves a list of all the theory questions for packer
        /// </summary>
        /// <returns>Readonly list of all the questions for packer</returns>
        IEnumerable<ITheoryQuestion> FetchAllTheoryQuestionsPacker();

        /// <summary>
        /// Counts the number of questions with images
        /// </summary>
        /// <returns>Number of questions with images</returns>
        int CountQuestionsWithImages();

        
        //WORK IN PROGRESS
        
        /// <summary>
        /// Fetches a single exam from database by passing the Guid id of the exam
        /// </summary>
        /// <param name="examId">Guid id of the exam to fetch</param>
        /// <param name="examType">Exam Type of the exam to fetch</param>
        /// <returns>Exam that was fetched from the database</returns>
        IExam FetchExam(Guid examId, ExamType examType);
        /// <summary>
        /// Returns whether the practical component was successfully completed or not
        /// </summary>
        /// <param name="examId">Guid if of the exam</param>
        /// <param name="examType">Type of the exam</param>
        /// <returns>True if the practical component was successfully completed, otherwise false</returns>
        bool HasPassedPractical(Guid examId, ExamType examType);
        /// <summary>
        /// Fetches the examiner Id by passing the username of an examiner
        /// </summary>
        /// <param name="username">Username of the examiner</param>
        /// <returns>Guid id of the examiner</returns>
        Guid FetchExaminerIdByUsername(string username);

    }
}
