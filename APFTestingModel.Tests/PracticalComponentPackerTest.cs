using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APFTestingModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APFTestingModel.Tests
{
    [TestClass]
    public class PracticalComponentPackerTest
    {
        #region IsCompetent
        /*
         * Valid Zero
         * Valid Fail
         * Valid Pass Exact
         * Valid Pass Excess
         * Invalid Content exceeds max integer
         */

        [TestMethod]
        public void IsCompetent_True()
        {
            //Arrange
            var fixture = new PracticalComponentPacker(new PracticalComponentTemplatePacker() { Id = Guid.NewGuid(), IsActive = true, NumOfRequiredAssessmentTasks = 10 });

            int passAmount = 10;
            ICollection<AssessmentTaskPacker> assessmentTaskPackers = new List<AssessmentTaskPacker>();
            for (int i = 0; i < passAmount; i++)
            {
                assessmentTaskPackers.Add(new AssessmentTaskPacker());
            }
            fixture.AssessmentTaskPackers = assessmentTaskPackers;

            //Act
            var actual = fixture.IsCompetent;

            //Assert
            Assert.IsTrue(actual);
        }



        #endregion
        




        //PracticalComponentPacker fixture = new PracticalComponentPacker();
        //for (int i = 0; i < length; i++)
        //{
                
        //}


    }
}
