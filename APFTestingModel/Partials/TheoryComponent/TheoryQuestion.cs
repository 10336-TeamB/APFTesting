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

        public TheoryQuestion(List<Answer> answers)
        {
            Answers = answers;
        }

        #endregion

        IEnumerable<IAnswer> ITheoryQuestion.PossibleAnswers
        {
            get { return Answers; }
        }

        public int QuestionNumber
        {
            get { throw new NotImplementedException(); }
        }
    }
}
