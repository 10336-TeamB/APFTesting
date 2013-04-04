﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    //public enum ExamType
    //{
    //    PilotExam = 1, PackerExam = 2
    //}

    abstract internal class ExamManager
    {
        protected PracticalComponentManager practicalComponentManager;
        protected TheoryComponentManager theoryComponentManager;

        abstract public Exam GenerateExam(Guid examinerId, Guid candidateId);
    }
}
