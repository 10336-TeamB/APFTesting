using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APFTestingModel
{
    public interface ISelectedAssessmentTask
    {
        Guid Id { get; set; }
        string Comment { get; set; }
        int Score { get; set; }
        string Title { get; }
        string Details { get; }
        int MaxScore { get; }
    }
}
