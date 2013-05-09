using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Areas.Administration.Models.PracticalTemplatePilot
{
    public class PilotTemplateTask
    {
        public PilotTemplateTask(IAssessmentTaskPilot task)
        {
            Title = task.Title;
            Details = task.Details;
            MaxScore = task.MaxScore;
        }
        public string Title { get; set;  }
        public string Details { get; set; }
        public int MaxScore { get; set; }
    }
}