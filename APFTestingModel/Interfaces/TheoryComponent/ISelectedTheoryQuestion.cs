using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    /// <summary>
    /// Interface that exposes selected theory question
    /// </summary>
    public interface ISelectedTheoryQuestion
    {
        /// <summary>
        /// Id of the selected theory question
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// Description of the theory question
        /// </summary>
        string Description { get; }
        /// <summary>
        /// Type of the theory question
        /// </summary>
        ExamType ExamType { get; }
        /// <summary>
        /// Number of correct answer for the theory question
        /// </summary>
        int NumberOfCorrectAnswers { get; }
        /// <summary>
        /// List of all the possible answers for the theory question
        /// </summary>
        IEnumerable<IPossibleAnswer> PossibleAnswers { get; }
        /// <summary>
        /// Order index of the selected theory question
        /// </summary>
        int QuestionIndex { get; }
        /// <summary>
        /// If true, the selected theory question has been marked for review
        /// </summary>
        bool IsMarkedForReview { get; }
        /// <summary>
        /// If true, the selected theory question was answered by the candidate
        /// </summary>
        bool IsAnswered { get; }
        /// <summary>
        /// If true, the selected theory question is the last question of the theory exam
        /// </summary>
        bool IsLastQuestion { get; }
        /// <summary>
        /// If true, the selected theory question was correctly answered by the candidate
        /// </summary>
        bool IsCorrect { get; }
        /// <summary>
        /// Total number of the questions in the theory exam
        /// </summary>
        int TotalNumOfQuestions { get; }
        /// <summary>
        /// Image path if the question requires an image to be displayed, otherwise null
        /// </summary>
        string ImagePath { get; }
    }
}
