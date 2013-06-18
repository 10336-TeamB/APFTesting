using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    /// <summary>
    /// Interface that exposes theory question
    /// </summary>
    public interface ITheoryQuestion
    {
        /// <summary>
        /// Id of the theory question
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// Number of correct answers
        /// </summary>
        int NumberOfCorrectAnswers { get; }
        /// <summary>
        /// If true, the theory question is currently active and maybe used by a theory exam
        /// </summary>
        bool IsActive { get; }
        /// <summary>
        /// Image path if the question needs to display an image, otherwise null
        /// </summary>
		string ImagePath { get; }
        /// <summary>
        /// Description of the theory question
        /// </summary>
		string Description { get; }
        /// <summary>
        /// Category of the theory question
        /// </summary>
		TheoryQuestionCategory Category { get; }
        /// <summary>
        /// List of all the options for the theory question
        /// </summary>
		IEnumerable<IAnswer> Answers { get; }
        /// <summary>
        /// If true, the theory question can be updated
        /// </summary>
        bool EditableOrDeletable { get; }
    }
}
