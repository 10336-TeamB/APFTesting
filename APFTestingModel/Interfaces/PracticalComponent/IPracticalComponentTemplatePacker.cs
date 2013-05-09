using System;
using System.Collections.Generic;

namespace APFTestingModel
{
    public interface IPracticalComponentTemplatePacker
    {
        Guid Id { get; }
        bool IsActive { get; }
        int NumOfRequiredAssessmentTasks { get; }
        bool AllowEditOrDelete { get; }
    }
}