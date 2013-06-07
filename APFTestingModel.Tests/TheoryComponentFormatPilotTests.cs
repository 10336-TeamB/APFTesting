using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel.Tests
{
    [TestClass]
    class TheoryComponentFormatPilotTests
    {
        [TestMethod]
        public void ConstructorIntIntInt_InitializeProperties()
        {
            //Act
            var expectedQuestionCount = 10;
            var expectedPassMark = 10;
            var expectedTimeLimit = 0;
            var format = new TheoryComponentFormatPilot(expectedQuestionCount, expectedPassMark, expectedTimeLimit);

            //Assert


        }
    }
}
