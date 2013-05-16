using APFTestingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APFTestingUI.Areas.Administration.Models.PracticalTemplatePilot
{
    public class Create
    {
        public Create() { }
        public Create(IEnumerable<IAssessmentTaskPilot> tasks)
        {
            Tasks = tasks.Select(t => new PilotTemplateTaskDisplayItem(t)).ToList();
        }

        public List<PilotTemplateTaskDisplayItem> Tasks { get; set; }

        public IEnumerable<Guid> SelectedTasks
        {
            get
            {
                return Tasks.Where(t => t.Selected).Select(t => t.Id).ToList();
            }
        }
    }
}