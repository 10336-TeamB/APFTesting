using System;
using System.Collections.Generic;

namespace APFTestingModel
{
    public interface IPracticalComponentTemplatePacker
    {
        Guid Id { get; set; }
        int NumOfRequiredAssessmentTasks { get; }
    }
}