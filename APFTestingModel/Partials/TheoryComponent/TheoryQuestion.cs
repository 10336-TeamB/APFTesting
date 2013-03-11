using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal abstract partial class TheoryQuestion : ITheoryQuestion
    {
        #region Constructors

        public TheoryQuestion(List<PossibleAnswer> possibleAnswers)
        {
            PossibleAnswers = possibleAnswers;
        }

        #endregion

        IEnumerable<IPossibleAnswer> ITheoryQuestion.PossibleAnswers
        {
            get { return PossibleAnswers; }
        }

        public int QuestionNumber
        {
            get { throw new NotImplementedException(); }
        }
    }
}
