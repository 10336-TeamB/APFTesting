using System;

namespace APFTestingModel
{
    /// <summary>
    /// Interface that exposes Answer fields
    /// </summary>
    public interface IAnswer
    {
        /// <summary>
        /// Id of the Answer
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// Description of the Answer
        /// </summary>
        string Description { get; }
        /// <summary>
        /// Order index of the Answer
        /// </summary>
        int DisplayOrderIndex { get; }
        /// <summary>
        /// True if the Answer is correct answer, otherwise false
        /// </summary>
        bool IsCorrect { get; }
    }
}
