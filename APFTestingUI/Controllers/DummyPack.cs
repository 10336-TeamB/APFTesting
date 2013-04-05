using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APFTestingUI.Controllers
{
    public class DummyPack : IAssessmentTaskPacker
    {
        public Guid Id { get; set; }
        
        public DateTime Date { get; set; }
        
        public string CanopyType { get; set; }
        
        public string CanopyTypeSerialNumber { get; set; }
        
        public string SupervisorId { get; set; }
        
        public string HarnessContainerType { get; set; }
        
        public string HarnessContainerSerialNumber { get; set; }

        public string Note { get; set; }
        
    }
}
