using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public interface IAssessmentTaskPilot
    {
        Guid Id { get; }
        string Title { get; }
        string Details { get; }
        int MaxScore { get; }
        bool EnableChange { get; }
    }
}
