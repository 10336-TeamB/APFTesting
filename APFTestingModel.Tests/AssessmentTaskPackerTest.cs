using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APFTestingModel.Tests
{
    [TestClass]
    public class AssessmentTaskPackerTest
    {
        [TestMethod]
        public void AssessmentTaskConstructionWithResult()
        {
            // Assemble
            var date = new DateTime(2012, 8, 12);
            var canopyType = "My CanopyType";
            var canopySerial = "123";
            var harnessType = "My Harness Type";
            var harnessSerial = "234";
            var note = "This pack was successful";
            var supervisorId = "567891";

            var dummyResult = new PackerPracticalResult() { Date = date, CanopyType = canopyType, CanopyTypeSerialNumber = canopySerial, HarnessContainerType = harnessType, HarnessContainerSerialNumber = harnessSerial, Note = note, SupervisorId = supervisorId };
            
            // Act
            var assessmentTask = new AssessmentTaskPacker(dummyResult);

            // Assert
            Assert.AreEqual(assessmentTask.Date, date);
            Assert.AreEqual(assessmentTask.CanopyType, canopyType);
            Assert.AreEqual(assessmentTask.CanopyTypeSerialNumber, canopySerial);
            Assert.AreEqual(assessmentTask.HarnessContainerType, harnessType);
            Assert.AreEqual(assessmentTask.HarnessContainerSerialNumber, harnessSerial);
            Assert.AreEqual(assessmentTask.Note, note);
            Assert.AreEqual(assessmentTask.SupervisorId, supervisorId);

        }

        [TestMethod]
        public void AssessmentTaskEditResult()
        {
            // Assemble
            var dateOld = new DateTime(2012, 8, 12);
            var canopyTypeOld = "My CanopyType";
            var canopySerialOld = "123";
            var harnessTypeOld = "My Harness Type";
            var harnessSerialOld = "234";
            var noteOld = "This pack was successful";
            var supervisorIdOld = "567891";

            var dateNew = DateTime.Now;
            var canopyTypeNew = "New CanopyType";
            var canopySerialNew = "987";
            var harnessTypeNew = "My Harness Type";
            var harnessSerialNew = "876";
            var noteNew = "Good pack";
            var supervisorIdNew = "567892";

            var dummyResult = new PackerPracticalResult() { Date = dateOld, CanopyType = canopyTypeOld, CanopyTypeSerialNumber = canopySerialOld, HarnessContainerType = harnessTypeOld, HarnessContainerSerialNumber = harnessSerialOld, Note = noteOld, SupervisorId = supervisorIdOld };
            var dummyResult2 = new PackerPracticalResult() { Date = dateNew, CanopyType = canopyTypeNew, CanopyTypeSerialNumber = canopySerialNew, HarnessContainerType = harnessTypeNew, HarnessContainerSerialNumber = harnessSerialNew, Note = noteNew, SupervisorId = supervisorIdNew };
            var assessmentTask = new AssessmentTaskPacker(dummyResult);

            // Act
            assessmentTask.Edit(dummyResult2);

            // Assert
            Assert.AreEqual(assessmentTask.Date, dateNew);
            Assert.AreEqual(assessmentTask.CanopyType, canopyTypeNew);
            Assert.AreEqual(assessmentTask.CanopyTypeSerialNumber, canopySerialNew);
            Assert.AreEqual(assessmentTask.HarnessContainerType, harnessTypeNew);
            Assert.AreEqual(assessmentTask.HarnessContainerSerialNumber, harnessSerialNew);
            Assert.AreEqual(assessmentTask.Note, noteNew);
            Assert.AreEqual(assessmentTask.SupervisorId, supervisorIdNew);
        }
    }
}
