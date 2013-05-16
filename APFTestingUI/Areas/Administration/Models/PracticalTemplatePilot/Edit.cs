using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Areas.Administration.Models.PracticalTemplatePilot
{
    public class Edit
    {
        public Edit(IPracticalComponentTemplatePilot template)
        {
            Id = template.Id;
            Tasks = template.Tasks.Select(t => new PilotTemplateTaskDisplayItem(t)).ToList();
        }

        public Guid Id { get; set; }
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