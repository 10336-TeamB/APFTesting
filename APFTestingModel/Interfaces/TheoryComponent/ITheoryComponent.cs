using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    /// <summary>
    /// Interface that exposes theory component
    /// </summary>
    public interface ITheoryComponent
    {
        /// <summary>
        /// Id of the theory component
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// Id of the theory component format that the theory exam used
        /// </summary>
        Guid FormatId { get; }
        /// <summary>
        /// Index of the question index that is currently displayed
        /// </summary>
        int CurrentQuestionIndex { get; }
        /// <summary>
        /// Achieved score
        /// </summary>
        float Score { get; }
        /// <summary>
        //Creation date of the theory component
        /// </summary>
        DateTime Date { get; }
        /// <summary>
        /// List of all the theory questions for the theory component
        /// </summary>
        IEnumerable<ISelectedTheoryQuestion> SelectedTheoryQuestions { get; }
        /// <summary>
        /// If true, candidate has successfully passed the theory component
        /// </summary>
        bool IsCompetent { get; }
    }
}
