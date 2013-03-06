using System;
using System.Collections.Generic;

namespace APFTestingModel
{
    public interface IPracticalComponentPacker
    {
        Guid Id { get; }
        DateTime CreationDate { get; }
        bool IsCompetent { get; }
        int NumOfRequiredAssessmentTasks { get; }
        IEnumerable<IAssessmentTaskPacker> AssessmentTasks { get; }
    }
}
