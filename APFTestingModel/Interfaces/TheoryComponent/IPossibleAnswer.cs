using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    /// <summary>
    /// Interface that exposes possible answer
    /// </summary>
    public interface IPossibleAnswer
    {
        /// <summary>
        /// Description of the possible answer
        /// </summary>
        string Description { get; }
        /// <summary>
        /// Order index in which the possible answer is displayed
        /// </summary>
        int DisplayOrderIndex { get; }
        /// <summary>
        /// If true, the possible answer is the correct answer
        /// </summary>
        bool IsCorrect { get; }
        /// <summary>
        /// If true, the candidate has selected the possible answer
        /// </summary>
        bool IsChecked { get; }
    }
}
