using System;
using System.Collections.Generic;

namespace APFTestingModel
{
    public interface IPracticalComponentTemplatePilot
    {
        Guid Id { get; set; }
        IEnumerable<IAssessmentTaskPilot> Tasks { get; }
    }
}