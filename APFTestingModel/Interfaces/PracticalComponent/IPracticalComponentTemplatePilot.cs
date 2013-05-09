using System;
using System.Collections.Generic;

namespace APFTestingModel
{
    public interface IPracticalComponentTemplatePilot
    {
        Guid Id { get; }
        bool IsActive { get; }
        IEnumerable<IAssessmentTaskPilot> Tasks { get; }
        bool AllowEditOrDelete { get; }
    }
}