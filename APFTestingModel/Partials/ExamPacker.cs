using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class ExamPacker : IExamPacker
    {
        public new IPracticalComponentPacker PracticalComponent
        {
            get { return base.PracticalComponent as PracticalComponentPacker; }
        }
    }
}
