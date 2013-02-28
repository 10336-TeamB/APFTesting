using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class PracticalComponent
    {
        public PracticalComponent(Guid examinerId, Guid practicalTemplateId)
        {
            this.ExaminerId = examinerId;
            this.PracticalTemplateId = practicalTemplateId;
        }
    }
}
