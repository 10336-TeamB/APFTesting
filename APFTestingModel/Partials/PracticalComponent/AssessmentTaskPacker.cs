﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class AssessmentTaskPacker : IAssessmentTaskPacker
    {
        public AssessmentTaskPacker() { }

        public AssessmentTaskPacker(PackerPracticalResult result)
        {
            Edit(result);
        }

        public void Edit(PackerPracticalResult result) 
        {
            Date = result.Date; 
            CanopyType = result.CanopyType;
            //CanopyTypeSerialNumber = result.CanopyTypeSerialNumber;
            SupervisorId = result.SupervisorId;
            HarnessContainerType = result.HarnessContainerType;
            //HarnessContainerSerialNumber = result.HarnessContainerSerialNumber;
            Note = result.Note;
        }
    }
}
