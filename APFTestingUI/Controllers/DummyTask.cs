using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APFTestingUI.Controllers
{
    public class DummyTask : ISelectedAssessmentTask
    {
        public string Title { get; set; }

        public string Details { get; set; }

        public int MaxScore { get; set; }

        public Guid Id { get; set; }

        public string Comment { get; set; }

        public Nullable<int> Score { get; set; }
    }
}
