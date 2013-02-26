using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal abstract class Manager
    {
        protected static APFTestingEntities context = new APFTestingEntities();
    }
}
