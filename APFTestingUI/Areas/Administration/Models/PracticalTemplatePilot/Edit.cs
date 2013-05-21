using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Areas.Administration.Models.PracticalTemplatePilot
{
    public class Edit
    {
        public Edit() { }
        public Edit(IPracticalComponentTemplatePilot template, IEnumerable<IAssessmentTaskPilot> allTasks)
        {
            Id = template.Id;
            CurrentTasks = template.Tasks.Select(t => new PilotTemplateTaskDisplayItem(t, true)).ToList();
            AvailableTasks = allTasks.Except(template.Tasks).Select(t => new PilotTemplateTaskDisplayItem(t)).ToList();
        }

        public Guid Id { get; set; }
        public List<PilotTemplateTaskDisplayItem> CurrentTasks { get; set; }
        public List<PilotTemplateTaskDisplayItem> AvailableTasks { get; set; }

        public IEnumerable<Guid> SelectedTasks
        {
            get
            {
                IEnumerable<Guid> list1 = new List<Guid>();
                IEnumerable<Guid> list2 = new List<Guid>();
                if (CurrentTasks != null)
                {
                    list1 = CurrentTasks.Where(t => t.Selected).Select(t => t.Id).ToList();
                }
                if (AvailableTasks != null)
                {
                    list2 = AvailableTasks.Where(t => t.Selected).Select(t => t.Id).ToList();
                }
                if (list1.Any() && list2.Any())
                {
                    return list1.Union(list2);
                }
                if (list1.Any())
                {
                    return list1;
                }
                return list2;
            }
        }
    }
}