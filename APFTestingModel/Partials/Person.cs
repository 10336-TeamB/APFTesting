using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal abstract partial class Person
    {
        public virtual bool NewExamPossible
        {
            get
            {
                return false;
            }
        }

        public virtual Guid LatestExamId
        {
            get
            {
                return Guid.Empty;
            }
        }
    }
}
