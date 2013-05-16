using APFTestingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APFTestingUI.Areas.Administration.Models.PracticalTemplatePilot
{
    public class PilotTemplateTaskDisplayItem
    {
        public PilotTemplateTaskDisplayItem() { }
        public PilotTemplateTaskDisplayItem(IAssessmentTaskPilot task)
        {
            Id = task.Id;
            Title = task.Title;
            Details = task.Details;
            MaxScore = task.MaxScore.ToString();
        }

        public Guid Id { get; set; }
        public string Title { get; set;  }
        public string Details { get; set; }
        public string MaxScore { get; set; }
        public bool Selected { get; set; }
    }
}