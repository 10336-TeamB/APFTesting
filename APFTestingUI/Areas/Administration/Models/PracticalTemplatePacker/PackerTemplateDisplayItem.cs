using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Areas.Administration.Models.PracticalTemplatePacker
{
    public class PackerTemplateDisplayItem
    {
        public PackerTemplateDisplayItem(IPracticalComponentTemplatePacker template)
        {
            Id = template.Id;
            IsActive = template.IsActive;
            NumOfRequiredAssessmentTasks = template.NumOfRequiredAssessmentTasks;
            AllowEditOrDelete = template.AllowEditOrDelete;
        }

        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public int NumOfRequiredAssessmentTasks { get; set; }
        public bool AllowEditOrDelete { get; set; }
    }
}