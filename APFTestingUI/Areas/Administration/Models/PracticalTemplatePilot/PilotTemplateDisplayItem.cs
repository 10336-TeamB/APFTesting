using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Areas.Administration.Models.PracticalTemplatePilot
{
    public class PilotTemplateDisplayItem
    {
        public PilotTemplateDisplayItem(IPracticalComponentTemplatePilot template)
        {
            Id = template.Id;
            IsActive = template.IsActive;
            IsActiveText = template.IsActive ? "Yes" : "No";
            Tasks = template.Tasks.Select(t => new PilotTemplateTaskDisplayItem(t)).ToList();
            AllowEditOrDelete = template.AllowEditOrDelete;
        }

        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public string IsActiveText { get; set; }
        public List<PilotTemplateTaskDisplayItem> Tasks { get; set; }
        public bool AllowEditOrDelete { get; set; }
    }
}