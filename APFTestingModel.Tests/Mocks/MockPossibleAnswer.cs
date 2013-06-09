using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel.Tests
{
    internal class MockPossibleAnswer : IPossibleAnswer
    {
        
        public string Description
        {
            get { return "This is a PossibleAnswer description"; }
        }

        public int DisplayOrderIndex
        {
            get { return 1; }
        }

        public bool IsCorrect
        {
            get { return false; }
        }

        public bool IsChecked
        {
            get { return false; }
        }
    }
}
