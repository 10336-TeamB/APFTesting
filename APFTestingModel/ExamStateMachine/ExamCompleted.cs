﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class ExamCompleted : ExamState
    {
        internal override void ArchiveExam(Action action)
        {
            action();
        }
    }
}
