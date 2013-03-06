using System;
using System.Collections.Generic;

namespace APFTestingModel
{
    public interface IPracticalComponentPilot
    {
        Guid Id { get; }
        DateTime CreationDate { get; }
        bool IsCompetent { get; }
        IEnumerable<ISelectedAssessmentTask> AssessmentTasks { get; }
    }
}
