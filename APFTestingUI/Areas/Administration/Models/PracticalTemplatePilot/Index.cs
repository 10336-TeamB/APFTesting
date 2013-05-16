using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Areas.Administration.Models.PracticalTemplatePilot
{
    public class Index
    {
        public Index(IEnumerable<IPracticalComponentTemplatePilot> templates)
        {
            Templates = templates.Select(t => new PilotTemplateDisplayItem(t)).ToList();
        }

        public List<PilotTemplateDisplayItem> Templates { get; set; }
    }
}