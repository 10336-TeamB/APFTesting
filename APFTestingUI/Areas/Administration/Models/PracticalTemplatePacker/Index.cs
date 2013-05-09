using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Areas.Administration.Models.PracticalTemplatePacker
{
    public class Index
    {
        public Index(IEnumerable<IPracticalComponentTemplatePacker> templates)
        {
            Templates = templates.Select(t => new PackerTemplateDisplayItem(t)).ToList();
        }

        public IEnumerable<PackerTemplateDisplayItem> Templates { get; set; }
    }
}