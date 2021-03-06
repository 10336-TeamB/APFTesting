﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APFTestingModel.Tests
{
    [TestClass]
    public class AssessmentTaskPackerTest
    {
        [TestMethod]
        public void Construction_SetsCorrectValues()
        {
            // Assemble
            var date = new DateTime(2012, 8, 12);
            var canopyType = "My CanopyType";
            var harnessType = "My Harness Type";
            var note = "This pack was successful";
            var supervisorId = "567891";

            //var dummyResult = new PackerPracticalResult() { Date = date, CanopyType = canopyType, CanopyTypeSerialNumber = canopySerial, HarnessContainerType = harnessType, HarnessContainerSerialNumber = harnessSerial, Note = note, SupervisorId = supervisorId };
            var dummyResult = new PackerPracticalResult() { Date = date, CanopyType = canopyType, HarnessContainerType = harnessType, Note = note, SupervisorId = supervisorId };
            
            // Act
            var assessmentTask = new AssessmentTaskPacker(dummyResult);

            // Assert
            Assert.AreEqual(date, assessmentTask.Date);
            Assert.AreEqual(canopyType, assessmentTask.CanopyType);
            Assert.AreEqual(harnessType, assessmentTask.HarnessContainerType);
            Assert.AreEqual(note, assessmentTask.Note);
            Assert.AreEqual(supervisorId, assessmentTask.SupervisorId);

        }

        [TestMethod]
        public void Edit_UpdatesToCorrectValues()
        {
            // Assemble
            var dateOld = new DateTime(2012, 8, 12);
            var canopyTypeOld = "My CanopyType";
            var harnessTypeOld = "My Harness Type";
            var noteOld = "This pack was successful";
            var supervisorIdOld = "567891";

            var dateNew = DateTime.Now;
            var canopyTypeNew = "New CanopyType";
            var harnessTypeNew = "My Harness Type";
            var noteNew = "Good pack";
            var supervisorIdNew = "567892";

            var dummyResult = new PackerPracticalResult() { Date = dateOld, CanopyType = canopyTypeOld, HarnessContainerType = harnessTypeOld, Note = noteOld, SupervisorId = supervisorIdOld };
            
            var dummyResult2 = new PackerPracticalResult() { Date = dateNew, CanopyType = canopyTypeNew, HarnessContainerType = harnessTypeNew, Note = noteNew, SupervisorId = supervisorIdNew };
            
            var assessmentTask = new AssessmentTaskPacker(dummyResult);

            // Act
            assessmentTask.Edit(dummyResult2);

            // Assert
            Assert.AreEqual(dateNew, assessmentTask.Date);
            Assert.AreEqual(canopyTypeNew, assessmentTask.CanopyType);
            Assert.AreEqual(harnessTypeNew, assessmentTask.HarnessContainerType);
            Assert.AreEqual(noteNew, assessmentTask.Note);
            Assert.AreEqual(supervisorIdNew, assessmentTask.SupervisorId);
        }
    }
}
