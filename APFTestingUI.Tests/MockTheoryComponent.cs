using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingUI.Tests
{
    internal class MockTheoryComponent : ITheoryComponent
    {
        public Guid Id
        {
            get { return Guid.NewGuid(); }
        }

        public Guid FormatId
        {
            get { return Guid.NewGuid(); }
        }

        public int CurrentQuestionIndex
        {
            get { return 0; }
        }

        public float Score
        {
            get { return 0.8f; }
        }

        public DateTime Date
        {
            get { return DateTime.Now; }
        }

        public IEnumerable<ISelectedTheoryQuestion> SelectedTheoryQuestions
        {
            get { 
                yield return new MockSelectedTheoryQuestion();
                yield return new MockSelectedTheoryQuestion();
                yield return new MockSelectedTheoryQuestion();
            }
        }

        public bool IsCompetent
        {
            get { return true; }
        }
    }
}
