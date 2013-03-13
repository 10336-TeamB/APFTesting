using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingUI.Tests
{
    internal class MockTheoryComponentFormat : ITheoryComponentFormat
    {
        public Guid Id
        {
            get { return Guid.NewGuid(); }
        }

        public int NumberOfQuestions
        {
            get { return 10; }
        }

        public int PassMark
        {
            get { return 80; }
        }

        public bool IsActive
        {
            get { return true; }
        }

        public int TimeLimit
        {
            get { return 0; }
        }
    }
}
